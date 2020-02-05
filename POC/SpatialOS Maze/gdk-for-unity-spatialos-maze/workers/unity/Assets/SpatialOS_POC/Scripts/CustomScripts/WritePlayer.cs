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
    [SerializeField]
    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        string[] exampleNames = Enum.GetNames(typeof(ExampleName));
        System.Random r = new System.Random();
        string username = (string)exampleNames.GetValue(r.Next(exampleNames.Length));
        string fullName = username + r.Next(10000);
        namePlate.text = fullName;
        Material mat = (Material)Resources.Load($"Materials/{username}Material");
        if (mat != null)
        {
            myRenderer.material = mat;
        }

        Player.Update update = new Player.Update
        {
            Name = fullName
        };

        _writer.SendUpdate(update);
    }


    public void ChangeMessage(InputField inputFieldComponent)
    {
        Player.Update update = new Player.Update
        {
            Message = inputFieldComponent.text
        };
        _writer.SendUpdate(update);
    }
}
