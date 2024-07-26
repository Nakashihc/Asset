using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClick : MonoBehaviour
{
    [Header("Event Settings")]
    public UnityEvent OnMouseDownEvent;
    public UnityEvent OnMouseUpEvent;

    void OnMouseDown()
    {
        if (!this.enabled) return;
        OnMouseDownEvent.Invoke();
    }

    void OnMouseUp()
    {
        if (!this.enabled) return;
        OnMouseUpEvent.Invoke();
    }

    public void DisableScript()
    {
        this.enabled = false;
    }

    // Function to enable this script
    public void EnableScript()
    {
        this.enabled = true;
    }
}
