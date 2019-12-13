// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using Improbable.Gdk.Core;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerCreator
    {
        public class CreatePlayerCommandMetaDataStorage : ICommandMetaDataStorage, ICommandPayloadStorage<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>
        {
            private readonly Dictionary<long, CommandContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>> requestIdToRequest =
                new Dictionary<long, CommandContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>>();

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

            public void AddRequest(in CommandContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest> context)
            {
                requestIdToRequest[context.RequestId] = context;
            }

            public CommandContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest> GetPayload(long internalRequestId)
            {
                var id = internalRequestIdToRequestId[internalRequestId];
                return requestIdToRequest[id];
            }
        }

    }
}
