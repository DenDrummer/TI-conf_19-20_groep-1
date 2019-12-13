using be.kdg.spatialos;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class MoveRequestHandler : MonoBehaviour
{

    [Require] private EntityId _entityId;
    [Require] private MoveCommandSender _commandSender;

    const int RaycastRange = 100;

    private GameObject shape;

    private void Update()
    {
        int touchCount = Input.touchCount;
        if(touchCount == 1 && InputManager.Tap())
        {
            var ray = Camera.main.ScreenPointToRay(InputManager.touchPos.x, InputManager.touchPos.y, 0f);

            if(!Physics.Raycast(ray, out var hit, RaycastRange, LayerMask.GetMask("Shapes")))
            {
                shape = null;
            }
            else if(Physics.Raycast(ray, out var hit, RaycastRange, LayerMask.GetMask("Shapes")) && hit != shape)
            {
                shape = hit.GameObject
            }
        }
        else if(touchCount == 1)
        {
            shape.transform.position += currentTouch.deltaPosition;
            _commandSender.SendMoveCommand(_entityId, new MoveRequest());
        }
    }
}
