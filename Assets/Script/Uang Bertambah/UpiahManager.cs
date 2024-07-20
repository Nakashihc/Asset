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
    public int delaylvl1;
    public int delaylvl2;
    public int delaylvl3;

    [Header("Upiah Bertambah")]
    public int upiahnambah;
    public int bangunanlvl1;
    public int bangunanlvl2;
    public int bangunanlvl3;

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
