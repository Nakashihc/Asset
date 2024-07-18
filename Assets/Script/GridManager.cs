using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 5;
    public int columns = 5;
    public float cellSize = 1f;
    public GameObject linePrefab; // Prefab yang berisi LineRenderer
    public bool showGrid = false;

    private GameObject[,] grid;
    private List<GameObject> gridLines = new List<GameObject>();

    private void Start()
    {
        grid = new GameObject[columns, rows];
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new GameObject[columns, rows];

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, y * cellSize, 0);
            }
        }
    }

    public bool IsCellOccupied(int x, int y)
    {
        return grid[x, y] != null;
    }

    public void PlaceObjectInCell(GameObject obj, int x, int y)
    {
        grid[x, y] = obj;
    }

    public void DrawGrid()
    {
        ClearGrid();

        for (int x = 0; x <= columns; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, rows * cellSize, 0);
            DrawLine(start, end);
        }

        for (int y = 0; y <= rows; y++)
        {
            Vector3 start = new Vector3(0, y * cellSize, 0);
            Vector3 end = new Vector3(columns * cellSize, y * cellSize, 0);
            DrawLine(start, end);
        }
    }

    public void ClearGrid()
    {
        foreach (GameObject line in gridLines)
        {
            Destroy(line);
        }
        gridLines.Clear();
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject line = Instantiate(linePrefab, transform);
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        gridLines.Add(line);
    }
}
