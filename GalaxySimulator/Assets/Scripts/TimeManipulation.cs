using UnityEngine;

public class TimeManipulation : MonoBehaviour
{

    static public int timeMultiplier = 1;

    public void StopTime()
    {
        timeMultiplier = 0;
        EventManager.SetTimeChanged();
    }

    public void SetTimeNormal()
    {
        timeMultiplier = 1;
        EventManager.SetTimeChanged();
    }

    public void SetTimeFast()
    {
        timeMultiplier = 10;
        EventManager.SetTimeChanged();
    }

    public void SetTimeFastest()
    {
        timeMultiplier = 100;
        EventManager.SetTimeChanged();
    }

}
