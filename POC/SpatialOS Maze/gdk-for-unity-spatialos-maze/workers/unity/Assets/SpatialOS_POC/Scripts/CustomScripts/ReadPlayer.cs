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
    private Material defaultMaterial;

    private List<Material> mats = new List<Material>();

    [SerializeField]
    private Text namePlate;
    [SerializeField]
    private MeshRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (string exampleName in Enum.GetNames(typeof(ExampleName)))
        {
            mats.Add((Material)Resources.Load($"Materials/{exampleName}Material"));
        }
    }

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
                    Material mat = mats.Find(m => m.name.StartsWith(exampleName));
                    if (mat != null)
                    {
                        myRenderer.material = mat;
                    }
                    else { myRenderer.material = defaultMaterial; }
                }
            }
        }
        namePlate.text = username;
    }
}
