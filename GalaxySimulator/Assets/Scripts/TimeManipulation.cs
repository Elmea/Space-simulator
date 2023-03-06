using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulation : MonoBehaviour
{

    public int timeMultiplier = 1;

    public void StopTime()
    {
        timeMultiplier = 0;
    }

    public void SetTimeNormal()
    {
        timeMultiplier = 1;
    }

    public void SetTimeFast()
    {
        timeMultiplier = 10;
    }

    public void SetTimeFastest()
    {
        timeMultiplier = 100;
    }

}
