using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public List<EventExplosion> explosionEvent = new List<EventExplosion>();

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
        explosionEvent.Clear();
    }
}

public class EventExplosion
{
    public Vector3 position;
    public Vector3 scale;

    public EventExplosion(Vector3 position, Vector3 scale)
    {
        this.position = position;
        this.scale = scale;
    }
}