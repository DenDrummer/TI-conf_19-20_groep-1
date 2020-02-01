using Be.Kdg.SpatialosMaze;
using Improbable.Gdk.Subscriptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerTransform : MonoBehaviour
{
    [Require]
    private PlayerTransformReader _reader;

    // Update is called once per frame
    void Update()
    {
        transform.position = _reader.Data.Position.ToUnityVector();
        transform.rotation = Quaternion.Euler(_reader.Data.Rotation.ToUnityVector());
    }
}
