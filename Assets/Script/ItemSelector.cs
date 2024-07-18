using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public GameObject[] items;
    public GridManager gridManager;
    private GameObject selectedItem;

    public void SelectItem(int index)
    {
        if (index >= 0 && index < items.Length)
        {
            selectedItem = items[index];
            gridManager.showGrid = true;
            gridManager.DrawGrid();
        }
    }

    public GameObject GetSelectedItem()
    {
        return selectedItem;
    }

    public void ClearSelectedItem()
    {
        selectedItem = null;
        gridManager.showGrid = false;
        gridManager.ClearGrid();
    }
}
