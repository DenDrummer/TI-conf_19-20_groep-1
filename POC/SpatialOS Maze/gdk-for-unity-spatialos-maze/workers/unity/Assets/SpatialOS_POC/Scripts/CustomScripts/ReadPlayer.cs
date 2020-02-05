using Assets.SpatialOS_POC.Scripts.CustomScripts;
using Be.Kdg.SpatialosMaze.Player;
using Improbable.Gdk.Subscriptions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayer : MonoBehaviour
{
    [Require]
    private PlayerReader _reader;

    [SerializeField]
    private Text namePlate;
    [SerializeField]
    private Text message;
    [SerializeField]
    private MeshRenderer myRenderer;
    [SerializeField]
    private List<Material> mats;

    // Update is called once per frame
    void Update()
    {
        string username = _reader.Data.Name;
        foreach (string exampleName in Enum.GetNames(typeof(ExampleName)))
        {
            if (username.StartsWith(exampleName))
            {
                if (mats.Count > 0)
                {
                    Material mat = mats.Find(m => m.name.Equals(exampleName));
                    myRenderer.material = mat;
                }
            }
        }
        namePlate.text = username;
        message.text = _reader.Data.Message;
    }
}
