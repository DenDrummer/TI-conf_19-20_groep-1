using UnityEngine;

static public class InputManager : MonoBehaviour
{

    public Vector2 touchPos;
    int SCount; // Count of started touches
    int MCount; // Count of ended touches
    int ECount; // Count of moved touches
    int LastPhaseHappend; // 1 = S, 2 = M, 3 = E
    float TouchTime; // Time elapsed between touch beginning and ending
    float StartTouchTime; // Time.realtimeSinceStartup at start of touch
    float EndTouchTime; // Time.realtimeSinceStartup at end of touch

    public bool Tap()
    {
        touchPos = Vector3.zero;
        if (Input.touchCount != 0)
        {
            Touch currentTouch = Input.GetTouch(0);
            switch (currentTouch.phase)
            {
                case TouchPhase.Began:
                    if (LastPhaseHappend != 1)
                    {
                        SCount++;
                        StartTouchTime = Time.realtimeSinceStartup;
                    }
                    LastPhaseHappend = 1;
                    break;

                case TouchPhase.Moved:
                    if (LastPhaseHappend != 2)
                    {
                        MCount++;
                    }
                    LastPhaseHappend = 2;
                    break;

                case TouchPhase.Ended:
                    if (LastPhaseHappend != 3)
                    {
                        ECount++;
                        EndTouchTime = Time.realtimeSinceStartup;
                        TouchTime = EndTouchTime - StartTouchTime;
                    }
                    LastPhaseHappend = 3;
                    break;
            }
            if (SCount == ECount && ECount != MCount && TouchTime < 1)
                // TouchTime for a tap can be further defined
            {
                //Tap has happened;
                touchPos = currentTouch.position;
                MCount++;
                return true;
            }
        }
    }
}