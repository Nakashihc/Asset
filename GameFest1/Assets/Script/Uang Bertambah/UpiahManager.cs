using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpiahManager : MonoBehaviour
{
    public static UpiahManager instance;

    public TextMeshProUGUI upiahText;
    public int totalUpiah = 0;
    public int tambahupiah;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            totalUpiah += tambahupiah;
            UpdateCoinText();
        }
    }

    public void AddCoins(int amount)
    {
        totalUpiah += amount;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        upiahText.text = "Upiah : " + totalUpiah.ToString();
    }
}
