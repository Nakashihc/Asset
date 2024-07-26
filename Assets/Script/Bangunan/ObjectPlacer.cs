using UnityEngine;
using UnityEngine.UI;

public class Objectplacer : MonoBehaviour
{
    [Header ("Object Taruh")]
    public GameObject object2D;

    [Header("Gedung Upgrade")]
    public GameObject Upgrade1Lvl2;
    public GameObject Upgrade2Lvl2;
    public GameObject Upgrade3Lvl2;
    public GameObject Upgrade4Lvl2;
    public GameObject Upgrade5Lvl2;
    public GameObject Upgrade6Lvl2;

    [Header ("Bangunan diBangun")]
    public GameObject bangunan1;
    public GameObject bangunan2;
    public GameObject bangunan3;
    public GameObject bangunan4;
    public GameObject bangunan5;
    public GameObject bangunan6;

    [Header("Harga Bangunan")]
    public int Harga1;
    public int Harga2;
    public int Harga3;
    public int Harga4;
    public int Harga5;
    public int Harga6;

    private UpiahManager upiahManager;
    private XPSystem xpSystem;
    public ZoomAnimator upiahTidakCukup;
    public ZoomAnimator levelTidakSampai;
    public ZoomAnimator BerhasilDibangun;

    void Start()
    {
        upiahManager = GameObject.FindObjectOfType<UpiahManager>();
        xpSystem = GameObject.FindObjectOfType<XPSystem>();
    }

    public void Taruhbangunan1()
    {
        if (upiahManager.totalUpiah <= Harga1)
        {
            upiahTidakCukup.ShowUI();
        }
        else if (xpSystem.Level <= 0)
        {
            levelTidakSampai.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga1);
            Instantiate(bangunan1, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade1Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }
    }

    public void Taruhbangunan2()
    {
        if (xpSystem.Level <= 1)
        {
            levelTidakSampai.ShowUI();
        }
        else if (upiahManager.totalUpiah <= Harga2)
        {
            upiahTidakCukup.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga2);
            Instantiate(bangunan2, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade2Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }

    }

    public void Taruhbangunan3()
    {
        if (xpSystem.Level <= 2)
        {
            levelTidakSampai.ShowUI();
        }
        else if (upiahManager.totalUpiah <= Harga3)
        {
            upiahTidakCukup.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga3);
            Instantiate(bangunan3, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade3Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }
    }
    
    public void Taruhbangunan4()
    {
        if (xpSystem.Level <= 3)
        {
            levelTidakSampai.ShowUI();
        }
        else if (upiahManager.totalUpiah <= Harga4)
        {
            upiahTidakCukup.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga4);
            Instantiate(bangunan4, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade4Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }
    }
    
    public void Taruhbangunan5()
    {
        if (xpSystem.Level <= 4)
        {
            levelTidakSampai.ShowUI();
        }
        else if (upiahManager.totalUpiah <= Harga5)
        {
            upiahTidakCukup.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga5);
            Instantiate(bangunan5, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade5Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }
    }
    
    public void Taruhbangunan6()
    {
        if (xpSystem.Level <= 5)
        {
            levelTidakSampai.ShowUI();
        }
        if (upiahManager.totalUpiah <= Harga6)
        {
            upiahTidakCukup.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(Harga6);
            Instantiate(bangunan6, object2D.transform.position, Quaternion.identity);
            object2D.SetActive(false);
            Upgrade6Lvl2.SetActive(true);
            BerhasilDibangun.ShowUI();
        }
    }
}