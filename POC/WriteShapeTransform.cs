using System;
using be.kdg.spatialos;
using Improbable;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class WriteShapeTransform : MonoBehaviour
{
    [Require] private ShapeTransformWriter _writer;

    private void Update()
    {
        var update = new ShapeTransform.Update
        {
            Position = Vector3f.FromUnityVector(transform.position),
            Rotation = Vector3f.FromUnityVector(transform.rotation.eulerAngles),
            Scale = Vector3f.FromUnityVector(transform.scale)
        };

        _writer.SendUpdate(update);
    }
}