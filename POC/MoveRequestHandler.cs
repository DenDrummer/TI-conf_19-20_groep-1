using be.kdg.spatialos;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class MoveRequestHandler : MonoBehaviour
{

    [Require] private EntityId _entityId;
    [Require] private MoveCommandSender _commandSender;

    private GameObject shape = null;

    private void Update()
    {
        if(Input.touchCount = 1 && InputManager.Tap())
        {
            var ray = Camera.main.ScreenPointToRay(InputManager.touchPos.x, InputManager.touchPos.y, 0f);

            if(!Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Shapes")))
            {
                shape = null;
            }
            else if(Physics.Raycast(ray, out var hit, 100, LayerMask.GetMask("Shapes")) && hit != shape)
            {
                shape = hit.GameObject
            }
        }
        else if(Input.touchCount = 1)
        {
            shape.transform.position += currentTouch.deltaPosition;
            _commandSender.SendMoveCommand(_entityId, new MoveRequest());
        }
    }
}