using System;
using be.kdg.spatialos;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class ReadShapeTransfor : MonoBehaviour
{
    [Require] private ShapeTransformReader _reader;

    private void Update()
    {
        transform.position = _reader.Data.Position.ToUnityVector();
        transform.rotation = Quaternion.Euler(_reader.Data.Rotation.ToUnityVector());
        transform.scale = _reader.Data.Scale.ToUnityVector();
    }
}