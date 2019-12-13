// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using Improbable.Gdk.Core;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerHeartbeatClient
    {
        public class PlayerHeartbeatCommandMetaDataStorage : ICommandMetaDataStorage, ICommandPayloadStorage<global::Improbable.Gdk.Core.Empty>
        {
            private readonly Dictionary<long, CommandContext<global::Improbable.Gdk.Core.Empty>> requestIdToRequest =
                new Dictionary<long, CommandContext<global::Improbable.Gdk.Core.Empty>>();

            private readonly Dictionary<long, long> internalRequestIdToRequestId = new Dictionary<long, long>();

            public uint GetComponentId()
            {
                return ComponentId;
            }

            public uint GetCommandId()
            {
                return 1;
            }

            public void RemoveMetaData(long internalRequestId)
            {
                var requestId = internalRequestIdToRequestId[internalRequestId];
                internalRequestIdToRequestId.Remove(internalRequestId);
                requestIdToRequest.Remove(requestId);
            }

            public void SetInternalRequestId(long internalRequestId, long requestId)
            {
                internalRequestIdToRequestId.Add(internalRequestId, requestId);
            }

            public void AddRequest(in CommandContext<global::Improbable.Gdk.Core.Empty> context)
            {
                requestIdToRequest[context.RequestId] = context;
            }

            public CommandContext<global::Improbable.Gdk.Core.Empty> GetPayload(long internalRequestId)
            {
                var id = internalRequestIdToRequestId[internalRequestId];
                return requestIdToRequest[id];
            }
        }

    }
}
