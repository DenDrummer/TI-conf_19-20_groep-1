using be.kdg.spatialos;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using UnityEngine;

public class MoveRequestHandler : MonoBehaviour
{

    [Require] private EntityId _entityId;
    [Require] private MoveCommandSender _commandSender;

    const int RaycastRange = 100;
    const float ScaleModifier = 1f;
    const float RotationModifier = 1f;
    const Vector3 InitOffset = new Vector3(7.0E-11f,0,0);

    private Vector3 FingerDistance;
    private Vector3 FingerDistanceDelta = new Vector3(0,0,0);
    private Vector3 FingerAngle;
    private Vector3 FingerAngleDelta = new Vector3(0,0,0);

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

        else if(touchCount == 2)
        {
            Vector3 LastFingerDistance = FingerDistance;
            Vector3 LastFingerAngle = FingerAngle;

            Vector3 finger1Pos = Input.GetTouch(0).position;
            Vector3 finger2Pos = Input.GetTouch(1).position;
            
            FingerDistance = finger1Pos - finger2Pos;
            if(FingerDistanceDelta == new Vector3(0,0,0))
            {
                FingerDistanceDelta = InitOffset;
            }
            else
            {
                FingerDistanceDelta = LastFingerDistance - FingerDistance;
            }

            FingerAngle = Vector3.Angle(finger1Pos, finger2Pos);
            if(FingerAngleDelta == new Vector3(0,0,0))
            {
                FingerAngleDelta == InitOffset;
            }
            else
            {
                FingerAngleDelta = FingerAngle - LastFingerAngle;
            }

            shape.transform.scale = FingerDistanceDelta * ScaleModifier;
            shape.transform.rotation = FingerAngleDelta * RotationModifier;
        }
    }
}
