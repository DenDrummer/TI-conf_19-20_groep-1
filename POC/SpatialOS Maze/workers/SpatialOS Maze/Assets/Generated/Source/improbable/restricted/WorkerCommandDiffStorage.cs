// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Unity.Entities;

namespace Improbable.Restricted
{
    public partial class Worker
    {
        public class DiffDisconnectCommandStorage : IComponentCommandDiffStorage
            , IDiffCommandRequestStorage<Disconnect.ReceivedRequest>
            , IDiffCommandResponseStorage<Disconnect.ReceivedResponse>
        {
            private readonly MessageList<Disconnect.ReceivedRequest> requestStorage =
                new MessageList<Disconnect.ReceivedRequest>();

            private readonly MessageList<Disconnect.ReceivedResponse> responseStorage =
                new MessageList<Disconnect.ReceivedResponse>();

            private readonly RequestComparer requestComparer = new RequestComparer();
            private readonly ResponseComparer responseComparer = new ResponseComparer();

            private bool requestsSorted;
            private bool responsesSorted;

            public uint GetComponentId()
            {
                return ComponentId;
            }

            public uint GetCommandId()
            {
                return 1;
            }

            public Type GetRequestType()
            {
                return typeof(Disconnect.ReceivedRequest);
            }

            public Type GetResponseType()
            {
                return typeof(Disconnect.ReceivedResponse);
            }

            public void Clear()
            {
                requestStorage.Clear();
                responseStorage.Clear();
                requestsSorted = false;
                responsesSorted = false;
            }

            public void RemoveRequests(long entityId)
            {
                requestStorage.RemoveAll(request => request.EntityId.Id == entityId);
            }

            public void AddRequest(Disconnect.ReceivedRequest request)
            {
                requestStorage.Add(request);
            }

            public void AddResponse(Disconnect.ReceivedResponse response)
            {
                responseStorage.Add(response);
            }

            public MessagesSpan<Disconnect.ReceivedRequest> GetRequests()
            {
                return requestStorage.Slice();
            }

            public MessagesSpan<Disconnect.ReceivedRequest> GetRequests(EntityId targetEntityId)
            {
                if (!requestsSorted)
                {
                    requestStorage.Sort(requestComparer);
                    requestsSorted = true;
                }

                var (firstIndex, count) = requestStorage.GetEntityRange(targetEntityId);
                return requestStorage.Slice(firstIndex, count);
            }

            public MessagesSpan<Disconnect.ReceivedResponse> GetResponses()
            {
                return responseStorage.Slice();
            }

            public MessagesSpan<Disconnect.ReceivedResponse> GetResponse(long requestId)
            {
                if (!responsesSorted)
                {
                    responseStorage.Sort(responseComparer);
                    responsesSorted = true;
                }

                var responseIndex = responseStorage.GetResponseIndex(requestId);
                return responseIndex.HasValue
                    ? responseStorage.Slice(responseIndex.Value, 1)
                    : MessagesSpan<Disconnect.ReceivedResponse>.Empty();
            }

            private class RequestComparer : IComparer<Disconnect.ReceivedRequest>
            {
                public int Compare(Disconnect.ReceivedRequest x, Disconnect.ReceivedRequest y)
                {
                    return x.EntityId.Id.CompareTo(y.EntityId.Id);
                }
            }

            private class ResponseComparer : IComparer<Disconnect.ReceivedResponse>
            {
                public int Compare(Disconnect.ReceivedResponse x, Disconnect.ReceivedResponse y)
                {
                    return x.RequestId.CompareTo(y.RequestId);
                }
            }
        }


        public class DisconnectCommandsToSendStorage : ICommandSendStorage, IComponentCommandSendStorage
            , ICommandRequestSendStorage<Disconnect.Request>
            , ICommandResponseSendStorage<Disconnect.Response>
        {
            private readonly MessageList<CommandRequestWithMetaData<Disconnect.Request>> requestStorage =
                new MessageList<CommandRequestWithMetaData<Disconnect.Request>>();

            private readonly MessageList<Disconnect.Response> responseStorage =
                new MessageList<Disconnect.Response>();

            public uint GetComponentId()
            {
                return ComponentId;
            }

            public uint GetCommandId()
            {
                return 1;
            }

            public Type GetRequestType()
            {
                return typeof(Disconnect.Request);
            }

            public Type GetResponseType()
            {
                return typeof(Disconnect.Response);
            }

            public void Clear()
            {
                requestStorage.Clear();
                responseStorage.Clear();
            }

            public void AddRequest(Disconnect.Request request, Entity entity, long requestId)
            {
                requestStorage.Add(new CommandRequestWithMetaData<Disconnect.Request>(request, entity, requestId));
            }

            public void AddResponse(Disconnect.Response response)
            {
                responseStorage.Add(response);
            }

            internal MessageList<CommandRequestWithMetaData<Disconnect.Request>> GetRequests()
            {
                return requestStorage;
            }

            internal MessageList<Disconnect.Response> GetResponses()
            {
                return responseStorage;
            }
        }

    }
}
