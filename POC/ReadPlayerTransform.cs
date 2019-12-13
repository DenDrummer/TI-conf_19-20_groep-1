using System;
using be.kdg.spatialos;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class ReadPlayerTransfor : MonoBehaviour
{
    [Require] private PlayerTransformReader _reader;

    private void Update()
    {
        transform.position = _reader.Data.Position.ToUnityVector();
        transform.rotation = Quaternion.Euler(_reader.Data.Rotation.ToUnityVector());
    }
}
