using UnityEngine;
using UnityEngine.UI;


public class Objectplacer : MonoBehaviour
{
    [Header ("Object Taruh")]
    public GameObject object2D;

    [Header ("Bangunan diBangun")]
    public GameObject bangunan1;
    public GameObject bangunan2;
    public GameObject bangunan3;

    [Header("Harga Bangunan")]
    public int Harga1;
    public int Harga2;
    public int Harga3;

    private UpiahManager upiahManager;
    private XPSystem xpSystem;

    void Start()
    {
        upiahManager = GameObject.FindObjectOfType<UpiahManager>();
        xpSystem = GameObject.FindObjectOfType<XPSystem>();
    }

    public void Taruhbangunan1()
    {
        if (upiahManager.totalUpiah <= Harga3)
        {
            Debug.Log("Tidak Cukup Upiah");
        }
        else if (xpSystem.Level <= 0)
        {
            Debug.Log("Level Tidak Cukup");
        }
        else
        {
            upiahManager.UpiahKurang(Harga1);
            Instantiate(bangunan1, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
        }
    }

    public void Taruhbangunan2()
    {
        if (upiahManager.totalUpiah <= Harga2)
        {
            Debug.Log("Tidak Cukup Upiah");
        }
        else if (xpSystem.Level <= 0)
        {
            Debug.Log("Level Tidak Cukup");
        }
        else
        {
            upiahManager.UpiahKurang(Harga2);
            Instantiate(bangunan2, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
        }

    }

    public void Taruhbangunan3()
    {
        if (upiahManager.totalUpiah <= Harga3)
        {
            Debug.Log("Tidak Cukup Upiah");
        }
        else if (xpSystem.Level <= 0)
        {
            Debug.Log("Level Tidak Cukup");
        }
        else
        {
            upiahManager.UpiahKurang(Harga3);
            Instantiate(bangunan3, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
        }

    }
}