using Be.Kdg.SpatialosMaze.Player;
using Improbable.Gdk.Subscriptions;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayer : MonoBehaviour
{
    [Require]
    private PlayerReader _reader;

    [SerializeField]
    private Text namePlate;

    // Update is called once per frame
    void Update()
    {
        namePlate.text = _reader.Data.Name;
    }
}
