using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    private Camera cam;

    // Batas gerakan kamera
    public float minX, maxX, minY, maxY;
    public float minZoom = 5f, maxZoom = 20f;
    public float zoomSpeed = 0.5f;
    public float panSpeed = 0.1f;

    private Vector3 mouseOrigin;
    private bool isPanning;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            isPanning = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (isPanning)
            {
                Vector3 difference = mouseOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPosition = cam.transform.position + difference * panSpeed;

                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
                newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

                cam.transform.position = newPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPanning = false;
        }
    }

    private void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            float newZoom = cam.orthographicSize - scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
        }
    }
}
