// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable
{
    public partial class Metadata
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 53;
            public string Name => "Metadata";

            public Type Data { get; } = typeof(global::Improbable.Metadata.Component);
            public Type Snapshot { get; } = typeof(global::Improbable.Metadata.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Metadata.Update);

            public Type ReplicationHandler { get; } = typeof(global::Improbable.Metadata.ComponentReplicator);
            public Type Serializer { get; } = typeof(global::Improbable.Metadata.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Metadata.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Metadata.DiffComponentStorage);
            public Type ViewStorage { get; } = typeof(global::Improbable.Metadata.MetadataViewStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Metadata.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Metadata.MetadataDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[] 
            { 
            };
        }
    }
}
