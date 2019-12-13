// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerHeartbeatClient
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 13001;
            public string Name => "PlayerHeartbeatClient";

            public Type Data { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Component);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Update);

            public Type ReplicationHandler { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ComponentReplicator);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffComponentStorage);
            public Type ViewStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatClientViewStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatClientDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[] 
            { 
                new PlayerHeartbeatMetaclass(),
            };
        }
 

        public class PlayerHeartbeatMetaclass : ICommandMetaclass 
        {
            public uint CommandIndex => 1;
            public string Name => "PlayerHeartbeat";

            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatDiffCommandDeserializer);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandSerializer);
            
            public Type MetaDataStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandMetaDataStorage);
            public Type SendStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandsToSendStorage);
            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffPlayerHeartbeatCommandStorage);
        }
    }
}
