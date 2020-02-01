using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using UnityEngine;

public class CubeGameObjectCreator : IEntityGameObjectCreator
{
    private readonly IEntityGameObjectCreator _fallbackCreator;
    private readonly World _world;
    private readonly string _workerType;

    public CubeGameObjectCreator(IEntityGameObjectCreator fallbackCreator, World world, string workerType)
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
        bool isCube = metadata.EntityType.Equals("Cube");

        // TODO: check if it is a Cube
        if (isCube)
        {
            string pathToPrefab = $"Prefabs/{_workerType}/Common/Cube";
            Object prefab = Resources.Load(pathToPrefab);
            GameObject cubeGameObject = (GameObject)Object.Instantiate(prefab);

            linker.LinkGameObjectToSpatialOSEntity(entity.SpatialOSEntityId, cubeGameObject);
        }
        else
        {
            _fallbackCreator.OnEntityCreated(entity, linker);
        }

    }

    public void OnEntityRemoved(EntityId entityId)
    {
        _fallbackCreator.OnEntityRemoved(entityId);
    }
}
