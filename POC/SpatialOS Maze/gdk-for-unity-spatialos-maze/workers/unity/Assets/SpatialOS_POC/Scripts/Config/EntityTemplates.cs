using Be.Kdg.SpatialosMaze;
using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.TransformSynchronization;

namespace SpatialOS_POC.Scripts.Config
{
    public static class EntityTemplates
    {
        public static EntityTemplate CreatePlayerEntityTemplate(string workerId, byte[] serializedArguments)
        {
            var clientAttribute = EntityTemplate.GetWorkerAccessAttribute(workerId);
            var serverAttribute = UnityGameLogicConnector.WorkerType;

            var template = new EntityTemplate();
            template.AddComponent(new Position.Snapshot(), clientAttribute);
            template.AddComponent(new Metadata.Snapshot("Player"), serverAttribute);
            template.AddComponent(new PlayerTransform.Snapshot(), clientAttribute);

            TransformSynchronizationHelper.AddTransformSynchronizationComponents(template, clientAttribute);
            PlayerLifecycleHelper.AddPlayerLifecycleComponents(template, workerId, serverAttribute);

            template.SetReadAccess(UnityClientConnector.WorkerType, MobileClientWorkerConnector.WorkerType, serverAttribute);
            template.SetComponentWriteAccess(EntityAcl.ComponentId, serverAttribute);

            return template;
        }

        public static EntityTemplate CreateCubeEntityTemplate(string workerId)
        {
            var clientAttribute = EntityTemplate.GetWorkerAccessAttribute(workerId);
            var serverAttribute = UnityGameLogicConnector.WorkerType;

            var entityTemplate = new EntityTemplate();
            entityTemplate.AddComponent(new Position.Snapshot(), clientAttribute);
            entityTemplate.AddComponent(new Metadata.Snapshot("Cube"), serverAttribute);
            entityTemplate.AddComponent(new Persistence.Snapshot(), serverAttribute);
            entityTemplate.AddComponent(new Cube.Snapshot(
                    workerId, "", 
                    new Coordinates(0d, 1d, 2d), 
                    new Coordinates(0d, 0d, 0d), 
                    new Coordinates(0.5d, 0.5d, 0.5d)
                ), clientAttribute);

            entityTemplate.SetReadAccess(UnityClientConnector.WorkerType, 
                MobileClientWorkerConnector.WorkerType, 
                serverAttribute);
            entityTemplate.SetComponentWriteAccess(EntityAcl.ComponentId, clientAttribute);
            entityTemplate.SetComponentWriteAccess(EntityAcl.ComponentId, serverAttribute);

            return entityTemplate;
        }
    }
}
