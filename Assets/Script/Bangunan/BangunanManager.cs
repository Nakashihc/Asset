using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangunanManager : MonoBehaviour
{
    [Header("Bangunan UI")]
    public ZoomAnimator sudahAda; // UI untuk menunjukkan bahwa bangunan sudah ada

    private HashSet<GameObject> placedBuildings = new HashSet<GameObject>();

    public bool IsBangunanPlaced(GameObject bangunan)
    {
        return placedBuildings.Contains(bangunan);
    }

    public void RegisterBangunan(GameObject bangunan)
    {
        if (!placedBuildings.Contains(bangunan))
        {
            placedBuildings.Add(bangunan);
        }
    }

    public void ShowSudahAdaUI()
    {
        if (sudahAda != null)
        {
            sudahAda.ShowUI();
        }
        else
        {
            Debug.LogWarning("SudahAda ZoomAnimator is not assigned in BangunanManager.");
        }
    }
}
