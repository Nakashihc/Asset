using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public GridManager gridManager;
    public ItemSelector itemSelector;

    private GameObject previewObject;

    void Update()
    {
        if (itemSelector.GetSelectedItem() != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = GetGridPosition(mousePosition);

            if (previewObject == null)
            {
                previewObject = Instantiate(itemSelector.GetSelectedItem());
            }

            AdjustPreviewSize(itemSelector.GetSelectedItem().tag);

            Vector3 placePosition = new Vector3(gridPosition.x * gridManager.cellSize, gridPosition.y * gridManager.cellSize, 0);
            previewObject.transform.position = placePosition;

            if (Input.GetMouseButtonDown(0))
            {
                bool canPlace = CanPlaceObject(gridPosition);

                if (canPlace)
                {
                    PlaceObject(gridPosition);
                    Destroy(previewObject);
                    previewObject = null;
                    itemSelector.ClearSelectedItem();
                }
                else
                {
                    Debug.Log("Object Telah Terisi di Posisi ini");
                }
            }
        }
        else if (previewObject != null)
        {
            Destroy(previewObject);
            previewObject = null;
        }
    }

    void AdjustPreviewSize(string tag)
    {
        switch (tag)
        {
            case "TagObject3x3":
                previewObject.transform.localScale = new Vector3(3f, 3f, 1f);
                break;
            case "TagObject2x5":
                previewObject.transform.localScale = new Vector3(2f, 5f, 1f);
                break;
            default:
                previewObject.transform.localScale = Vector3.one;
                break;
        }
    }

    bool CanPlaceObject(Vector3Int gridPosition)
    {
        Vector3Int objectSize = GetObjectSize(itemSelector.GetSelectedItem().tag);
        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                if (gridManager.IsCellOccupied(gridPosition.x + x, gridPosition.y + y))
                {
                    return false;
                }
            }
        }
        return true;
    }

    Vector3Int GetObjectSize(string tag)
    {
        switch (tag)
        {
            case "Object3x3":
                return new Vector3Int(3, 3, 0);
            case "Object2x5":
                return new Vector3Int(5, 2, 0);
            default:
                return Vector3Int.one;
        }
    }

    void PlaceObject(Vector3Int gridPosition)
    {
        Vector3Int objectSize = GetObjectSize(itemSelector.GetSelectedItem().tag);
        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                Vector3 placePosition = new Vector3((gridPosition.x + x) * gridManager.cellSize, (gridPosition.y + y) * gridManager.cellSize, 0);
                GameObject placedObject = Instantiate(itemSelector.GetSelectedItem(), placePosition, Quaternion.identity);
                gridManager.PlaceObjectInCell(placedObject, gridPosition.x + x, gridPosition.y + y);
            }
        }
    }

    Vector3Int GetGridPosition(Vector3 mousePosition)
    {
        int x = Mathf.FloorToInt(mousePosition.x / gridManager.cellSize);
        int y = Mathf.FloorToInt(mousePosition.y / gridManager.cellSize);
        return new Vector3Int(x, y, 0);
    }
}
