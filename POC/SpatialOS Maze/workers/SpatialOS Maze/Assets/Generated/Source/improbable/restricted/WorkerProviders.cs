// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.Core;

namespace Improbable.Restricted
{
    public partial class Worker
    {
        internal static class ReferenceTypeProviders
        {
            public static class WorkerIdProvider 
{
    private static readonly Dictionary<uint, string> Storage = new Dictionary<uint, string>();
    private static readonly Dictionary<uint, global::Unity.Entities.World> WorldMapping = new Dictionary<uint, global::Unity.Entities.World>();

    private static uint nextHandle = 0;

    public static uint Allocate(global::Unity.Entities.World world)
    {
        var handle = GetNextHandle();

        Storage.Add(handle, default(string));
        WorldMapping.Add(handle, world);

        return handle;
    }

    public static string Get(uint handle)
    {
        if (!Storage.TryGetValue(handle, out var value))
        {
            throw new ArgumentException($"WorkerIdProvider does not contain handle {handle}");
        }

        return value;
    }

    public static void Set(uint handle, string value)
    {
        if (!Storage.ContainsKey(handle))
        {
            throw new ArgumentException($"WorkerIdProvider does not contain handle {handle}");
        }

        Storage[handle] = value;
    }

    public static void Free(uint handle)
    {
        Storage.Remove(handle);
        WorldMapping.Remove(handle);
    }

    public static void CleanDataInWorld(global::Unity.Entities.World world)
    {
        var handles = WorldMapping.Where(pair => pair.Value == world).Select(pair => pair.Key).ToList();

        foreach (var handle in handles)
        {
            Free(handle);
        }
    }

    private static uint GetNextHandle() 
    {
        nextHandle++;
        
        while (Storage.ContainsKey(nextHandle))
        {
            nextHandle++;
        }

        return nextHandle;
    }
}


            public static class WorkerTypeProvider 
{
    private static readonly Dictionary<uint, string> Storage = new Dictionary<uint, string>();
    private static readonly Dictionary<uint, global::Unity.Entities.World> WorldMapping = new Dictionary<uint, global::Unity.Entities.World>();

    private static uint nextHandle = 0;

    public static uint Allocate(global::Unity.Entities.World world)
    {
        var handle = GetNextHandle();

        Storage.Add(handle, default(string));
        WorldMapping.Add(handle, world);

        return handle;
    }

    public static string Get(uint handle)
    {
        if (!Storage.TryGetValue(handle, out var value))
        {
            throw new ArgumentException($"WorkerTypeProvider does not contain handle {handle}");
        }

        return value;
    }

    public static void Set(uint handle, string value)
    {
        if (!Storage.ContainsKey(handle))
        {
            throw new ArgumentException($"WorkerTypeProvider does not contain handle {handle}");
        }

        Storage[handle] = value;
    }

    public static void Free(uint handle)
    {
        Storage.Remove(handle);
        WorldMapping.Remove(handle);
    }

    public static void CleanDataInWorld(global::Unity.Entities.World world)
    {
        var handles = WorldMapping.Where(pair => pair.Value == world).Select(pair => pair.Key).ToList();

        foreach (var handle in handles)
        {
            Free(handle);
        }
    }

    private static uint GetNextHandle() 
    {
        nextHandle++;
        
        while (Storage.ContainsKey(nextHandle))
        {
            nextHandle++;
        }

        return nextHandle;
    }
}


        }
    }
}