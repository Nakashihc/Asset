using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpiahPenambah : MonoBehaviour
{
    public int initialMoney = 0; // initial money amount
    public int moneyToAdd = 5; // amount of money to add every 5 seconds
    private int currentMoney; // current money amount
    private float timer = 0f; // timer for the delay
    public float waktu; // time interval for adding money

    void Start()
    {
        currentMoney = initialMoney;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waktu)
        {
            AddMoney();
            timer = 0f;
        }
    }

    void AddMoney()
    {
        currentMoney += moneyToAdd;
        UpiahManager.instance.AddCoins(moneyToAdd); // Add coins to the UpiahManager
    }
}
