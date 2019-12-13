using UnityEngine;

static public class InputManager : MonoBehaviour
{


    public Vector2 TouchPost { get; set; }
    int SCount; // Count of started touches
    int MCount; // Count of ended touches
    int ECount; // Count of moved touches
    int LastPhaseHappend;
    const int PhaseS = 1;
    const int PhaseM = 2;
    const int PhaseE = 3;
    float TouchTime; // Time elapsed between touch beginning and ending
    float StartTouchTime; // Time.realtimeSinceStartup at start of touch

    public bool Tap()
    {
        touchPos = Vector3.zero;
        if (Input.touchCount != 0)
        {
            Touch currentTouch = Input.GetTouch(0);
            switch (currentTouch.phase)
            {
                case TouchPhase.Began:
                    SetPhaseS();
                    break;

                case TouchPhase.Moved:
                    SetPhaseM();
                    break;

                case TouchPhase.Ended:
                    SetPhaseE();
                    break;

                default:
                    throw new InvalidOperationException("Unexpected value LastPhaseHappened = " + LastPhaseHappend);
                    break;
            }
            
            if (SCount == ECount && ECount != MCount && TouchTime < 1)
                // TouchTime for a tap can be further defined
            {
                touchPos = currentTouch.position; //Tap has happened
                MCount++;
                return true;
            }
        }
    }

    private void SetPhaseS
    {
        if (LastPhaseHappend != PhaseS)
            {
                SCount++;
                StartTouchTime = Time.realtimeSinceStartup;
            }
        LastPhaseHappend = PhaseS;
    }
    private void SetPhaseM
    {
        if (LastPhaseHappend != PhaseM)
        {
            MCount++;
        }
        LastPhaseHappend = PhaseM;
    }
    private void SetPhaseE
    {
        if (LastPhaseHappend != PhaseE)
        {
            ECount++;
            float EndTouchTime = Time.realtimeSinceStartup; // Time.realtimeSinceStartup at end of touch
            TouchTime = EndTouchTime - StartTouchTime;
        }
        LastPhaseHappend = PhaseE;
    }
}
