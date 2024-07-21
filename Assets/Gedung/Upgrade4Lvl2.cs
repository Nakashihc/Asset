using UnityEngine;
using UnityEngine.UI;


public class Upgrade4Lvl2 : MonoBehaviour
{
    [Header("Tombolnya")]
    public GameObject Tomboll;
    private GameObject level1;

    [Header("Bangunan diBangun")]
    public GameObject Level2;

    [Header("Harga Bangunan")]
    public int HargaUpgrade;

    private UpiahManager upiahManager;
    private XPSystem xpSystem;

    [Header("Animasi")]
    public ZoomAnimator upiahTidakCukup;
    public ZoomAnimator levelTidakSampai;
    public ZoomAnimator UpgradeSelesai;

    void Start()
    {
        upiahManager = GameObject.FindObjectOfType<UpiahManager>();
        xpSystem = GameObject.FindObjectOfType<XPSystem>();
    }

    public void BangunanLevel2()
    {
        if (upiahManager.totalUpiah <= HargaUpgrade)
        {
            Debug.Log("Tidak Cukup Upiah");
            upiahTidakCukup.ShowUI();
        }
        else if (xpSystem.Level <= 0)
        {
            Debug.Log("Level Tidak Cukup");
            levelTidakSampai.ShowUI();
        }
        else
        {
            upiahManager.UpiahKurang(HargaUpgrade);
            Instantiate(Level2, level1.transform.position, Quaternion.identity);
            level1.SetActive(false);
            Tomboll.SetActive(false);
            UpgradeSelesai.ShowUI();
        }
    }

    public void TemukanObject()
    {
        level1 = GameObject.FindGameObjectWithTag("bangunan3lvl1");
    }
}