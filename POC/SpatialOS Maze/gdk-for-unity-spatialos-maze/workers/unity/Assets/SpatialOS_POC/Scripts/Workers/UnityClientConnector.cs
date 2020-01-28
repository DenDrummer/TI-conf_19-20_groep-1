using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using UnityEngine;

namespace SpatialOS_POC
{
    public class UnityClientConnector : WorkerConnector
    {
        public const string WorkerType = "UnityClient";

        private async void Start()
        {
            var connParams = CreateConnectionParameters(WorkerType);

            var builder = new SpatialOSConnectionHandlerBuilder()
                .SetConnectionParameters(connParams);

            if (!Application.isEditor)
            {
                var initializer = new CommandLineConnectionFlowInitializer();
                switch (initializer.GetConnectionService())
                {
                    case ConnectionService.Receptionist:
                        builder.SetConnectionFlow(new ReceptionistFlow(CreateNewWorkerId(WorkerType), initializer));
                        break;
                    case ConnectionService.Locator:
                        builder.SetConnectionFlow(new LocatorFlow(initializer));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                builder.SetConnectionFlow(new ReceptionistFlow(CreateNewWorkerId(WorkerType)));
            }

            await Connect(builder, new ForwardingDispatcher()).ConfigureAwait(false);
        }

        protected override void HandleWorkerConnectionEstablished()
        {
            PlayerLifecycleHelper.AddClientSystems(Worker.World);

            IEntityGameObjectCreator fallbackCreator = new GameObjectCreatorFromMetadata(Worker.WorkerType, Worker.Origin, Worker.LogDispatcher);
            IEntityGameObjectCreator customCreator = new PlayerGameObjectCreator(fallbackCreator, Worker.World, Worker.WorkerType);

            GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, customCreator);
        }
    }
}
