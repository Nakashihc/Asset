using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpiahManager : MonoBehaviour
{
    public static UpiahManager instance;

    [Header("Text Upiah")]
    public TextMeshProUGUI upiahText;

    [Header("Jumlah Upiah")]
    public int totalUpiah = 0;

    [Header("Waktu saat dalam Ruangan")]
    public int delayTime;
    public int delaylvl1 = 5;
    public int delaylvl2 = 4;
    public int delaylvl3 = 3;

    [Header("Upiah Bertambah")]
    public int upiahnambah;
    public int bangunanlvl1 = 10;
    public int bangunanlvl2 = 20;
    public int bangunanlvl3 = 30;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        UpiahText();
    }

    public void UpiahTambah(int amount)
    {
        totalUpiah += amount;
        UpiahText();
    }

    private void UpiahText()
    {
        upiahText.text = "Upiah : " + totalUpiah.ToString();
    }

    public void UpiahKurang(int berkurang)
    {
        totalUpiah -= berkurang;
        UpiahText();
    }

    public IEnumerator AddUpiahWithDelaylvl1()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl1);
            UpiahTambah(bangunanlvl1);
        }
    }

    public IEnumerator AddUpiahWithDelaylvl2()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl2);
            UpiahTambah(bangunanlvl2);
        }
    }

    public IEnumerator AddUpiahWithDelaylvl3()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaylvl3);
            UpiahTambah(bangunanlvl3);
        }
    }

}
