using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    #region timeChanged
    static private bool timeChanged;

    static public void SetTimeChanged()
    {
        timeChanged = true;
    }

    static public bool IsTimeChanged()
    {
        return timeChanged;
    }
    #endregion

    private void LateUpdate()
    {
        timeChanged = false;
    }
}
