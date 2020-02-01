using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.Subscriptions;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public EntityId PlayerEntityId { get; set; }
    public EntityId CubeEntityId { get; set; }

    public static List<Player> players = new List<Player>();
}
