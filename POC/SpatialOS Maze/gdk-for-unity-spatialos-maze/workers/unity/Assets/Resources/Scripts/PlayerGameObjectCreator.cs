using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using UnityEngine;

public class PlayerGameObjectCreator : IEntityGameObjectCreator
{
    private readonly IEntityGameObjectCreator _fallbackCreator;
    private readonly World _world;
    private readonly string _workerType;

    public PlayerGameObjectCreator(
        IEntityGameObjectCreator fallbackCreator,
        World world,
        string workerType)
    {
        _fallbackCreator = fallbackCreator;
        _world = world;
        _workerType = workerType;
    }

    public void OnEntityCreated(SpatialOSEntity entity, EntityGameObjectLinker linker)
    {
        if (!entity.HasComponent<Metadata.Component>())
        {
            return;
        }
        Metadata.Component metadata = entity.GetComponent<Metadata.Component>();
        bool isPlayer = metadata.EntityType.Equals("Player");
        bool hasAuthority = PlayerLifecycleHelper.IsOwningWorker(entity.SpatialOSEntityId, _world);

        // TODO: check if it is a player
        if (isPlayer && hasAuthority)
        {
            string pathToPrefab = $"Prefabs/{_workerType}/Authoratative/Player";
            Object prefab = Resources.Load(pathToPrefab);
            GameObject playerGameObject = (GameObject)Object.Instantiate(prefab);

            var player = playerGameObject.GetComponent<Player>();

            Player.players.Add(player);

            CubeManager.GetCubeManager().CreateCubeEntity(player);

            player.PlayerEntityId = entity.SpatialOSEntityId;

            linker.LinkGameObjectToSpatialOSEntity(entity.SpatialOSEntityId, playerGameObject);
        }
        else
        {
            _fallbackCreator.OnEntityCreated(entity, linker);
        }
        
    }

    public void OnEntityRemoved(EntityId entityId)
    { 
        var cubeEntityID = Player.players.Find(p => p.PlayerEntityId == entityId).CubeEntityId;
        CubeManager.GetCubeManager().DeleteEntity(cubeEntityID);
        _fallbackCreator.OnEntityRemoved(entityId);
    }
}
