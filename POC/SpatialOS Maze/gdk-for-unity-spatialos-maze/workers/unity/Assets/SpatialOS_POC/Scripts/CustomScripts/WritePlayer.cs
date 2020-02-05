using Assets.SpatialOS_POC.Scripts.CustomScripts;
using Be.Kdg.SpatialosMaze.Player;
using Improbable.Gdk.Subscriptions;
using System;
using UnityEngine;
using UnityEngine.UI;

public class WritePlayer : MonoBehaviour
{
    [Require]
    private PlayerWriter _writer;

    [SerializeField]
    private Text namePlate;

    // Start is called before the first frame update
    void Start()
    {
        string[] exampleNames = Enum.GetNames(typeof(ExampleName));
        System.Random r = new System.Random();
        string username = (string)exampleNames.GetValue(r.Next(exampleNames.Length)) + r.Next(4);
        namePlate.text = username;
    }

    // Update is called once per frame
    void Update()
    {
        Player.Update update = new Player.Update
        {
            // TODO: generate random name/id or ask name (asking brings risk of trolls during demo) ~Jorden
            Name = namePlate.text
        };

        _writer.SendUpdate(update);
    }
}
