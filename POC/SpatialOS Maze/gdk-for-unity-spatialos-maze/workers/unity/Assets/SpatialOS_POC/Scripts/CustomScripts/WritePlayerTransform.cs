using Be.Kdg.SpatialosMaze;
using Improbable;
using Improbable.Gdk.Subscriptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePlayerTransform : MonoBehaviour
{
    [Require]
    private PlayerTransformWriter _writer;

    // Update is called once per frame
    void Update()
    {
        PlayerTransform.Update update = new PlayerTransform.Update {
            Position = Coordinates.FromUnityVector(transform.position),
            Rotation = Coordinates.FromUnityVector(transform.rotation.eulerAngles)            
        };
        _writer.SendUpdate(update);
    }
}
