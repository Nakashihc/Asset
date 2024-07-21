using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClick : MonoBehaviour
{
    [Header("Main Settings")]
    public int MouseButton = 0; // This setting is not required anymore

    [Header("Event Settings")]
    public UnityEvent OnMouseDownEvent;
    public UnityEvent OnMouseUpEvent;

    void OnMouseDown()
    {
        if (!this.enabled) return;
        Vector3 mousePosition = Input.mousePosition;
        OnMouseDownEvent.Invoke();
    }

    void OnMouseUp()
    {
        Vector3 mousePosition = Input.mousePosition;
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
