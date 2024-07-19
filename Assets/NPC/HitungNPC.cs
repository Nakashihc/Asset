using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitungNPC : MonoBehaviour
{
    [Header("Text Display")]
    public TextMeshProUGUI AngkaCowok;
    public TextMeshProUGUI AngkaCewek;

    public TextMeshProUGUI TotalPengunjung;

    public TextMeshProUGUI AngkaCowokBanyak;
    public TextMeshProUGUI AngkaCewekBanyak;

    private int totalPengunjung = 0;
    private int currentNPCCowok = 0;
    private int currentNPCCewek = 0;

    private int HariiniCowok = 0;
    private int HariiniCewek = 0;

    private void Update()
    {
        totalPengunjung = currentNPCCewek + currentNPCCowok;
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPCCowok++;
            if (currentNPCCowok > HariiniCowok)
            {
                HariiniCowok = currentNPCCowok;
            }
        }
        else if (other.CompareTag("NPCcewek"))
        {
            currentNPCCewek++;
            if (currentNPCCewek > HariiniCewek)
            {
                HariiniCewek = currentNPCCewek;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPCCowok--;
        }
        else if (other.CompareTag("NPCcewek"))
        {
            currentNPCCewek--;
        }
    }

    private void UpdateText()
    {
        AngkaCowok.text = currentNPCCowok.ToString();
        AngkaCewek.text = currentNPCCewek.ToString();
        TotalPengunjung.text = totalPengunjung.ToString();
        AngkaCowokBanyak.text = HariiniCowok.ToString();
        AngkaCewekBanyak.text = HariiniCewek.ToString();
    }

    public void ResetJumlah()
    {
        currentNPCCowok = 0;
        currentNPCCowok = 0;
        UpdateText();
    }
}
