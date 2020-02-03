using Be.Kdg.SpatialosMaze;
using Improbable;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class WritePlayer : MonoBehaviour
{
    [Require]
    private PlayerWriter _writer;

    // Update is called once per frame
    void Update()
    {
        Player.Update update = new Player.Update {
            // TODO: generate random name/id or ask name (asking brings risk of trolls during demo) ~Jorden
            Name = "Guest"          
        };
        _writer.SendUpdate(update);
    }
}
