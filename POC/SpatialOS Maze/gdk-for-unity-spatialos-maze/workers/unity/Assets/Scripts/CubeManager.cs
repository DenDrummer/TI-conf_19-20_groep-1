﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Improbable.Gdk.Subscriptions;
using SpatialOS_POC.Scripts.Config;
using Improbable.Worker.CInterop;

public class CubeManager : MonoBehaviour
{
    [Require] private WorldCommandSender commandSender;

    public GameObject cubePrefab;
    private static CubeManager instance;
    private Queue<Player> playerQueue;

    private CubeManager()
    {
        playerQueue = new Queue<Player>();
    }

    static public CubeManager GetCubeManager()
    {
        if(CubeManager.instance == null)
        {
            CubeManager.instance = new CubeManager();
        }
        return CubeManager.instance;
    }

    private EntityTemplate CreateCubeEntityTemplate()
	{
        var template = EntityTemplates.CreateCubeEntityTemplate();
        return template;
    }

    public void CreateCubeEntity(Player player)
	{
        var test = GetCubeManager();
        //TODO: If wrong cube despawns, blame the Queue
        playerQueue.Enqueue(player);
        var exampleEntity = CreateCubeEntityTemplate();
	    var request = new WorldCommands.CreateEntity.Request(exampleEntity);
	    commandSender.SendCreateEntityCommand(request, OnCreateEntityResponse);
	}

    private void OnCreateEntityResponse(WorldCommands.CreateEntity.ReceivedResponse response)
    {
        if (response.StatusCode == StatusCode.Success)
        {
            var createdEntityId = response.EntityId.Value;
            // handle success
            Player player = playerQueue.Dequeue();
            player.CubeEntityId = createdEntityId;

            Instantiate(cubePrefab, 
                player.gameObject.transform.position + new Vector3(0, 0, 2), 
                Quaternion.identity);
        }
        else
        {
            // handle failure
            Debug.Log($"CubeCreation: {response.StatusCode} :')");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Update()
    {

	}

    public void DeleteEntity(EntityId entityId)
    {
	    var request = new WorldCommands.DeleteEntity.Request(entityId);
	    commandSender.SendDeleteEntityCommand(request, OnDeleteEntityResponse);
    }
	 
	private void OnDeleteEntityResponse(WorldCommands.DeleteEntity.ReceivedResponse response)
	{
	    if (response.StatusCode == StatusCode.Success)
	    {
	        // handle success

	    }
	    else
	    {
	        // handle failure
	    }
	}
}
