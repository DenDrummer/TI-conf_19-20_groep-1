// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Restricted
{
    public partial class System
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 59;
            public string Name => "System";

            public Type Data { get; } = typeof(global::Improbable.Restricted.System.Component);
            public Type Snapshot { get; } = typeof(global::Improbable.Restricted.System.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Restricted.System.Update);

            public Type ReplicationHandler { get; } = typeof(global::Improbable.Restricted.System.ComponentReplicator);
            public Type Serializer { get; } = typeof(global::Improbable.Restricted.System.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Restricted.System.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Restricted.System.DiffComponentStorage);
            public Type ViewStorage { get; } = typeof(global::Improbable.Restricted.System.SystemViewStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Restricted.System.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Restricted.System.SystemDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[] 
            { 
            };
        }
    }
}
