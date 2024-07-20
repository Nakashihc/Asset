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
        Vector3 mousePosition = Input.mousePosition;
        OnMouseDownEvent.Invoke();
    }

    void OnMouseUp()
    {
        Vector3 mousePosition = Input.mousePosition;
        OnMouseUpEvent.Invoke();
    }
}
