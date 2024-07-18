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
        Debug.Log("Mouse button clicked at (" + mousePosition.x + ", " + mousePosition.y + ")");
        OnMouseDownEvent.Invoke();
    }

    void OnMouseUp()
    {
        Vector3 mousePosition = Input.mousePosition;
        Debug.Log("Mouse button released at (" + mousePosition.x + ", " + mousePosition.y + ")");
        OnMouseUpEvent.Invoke();
    }
}
