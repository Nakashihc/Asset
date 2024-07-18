using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalamRuangan : MonoBehaviour
{
    public float delayTime = 3f; // time delay in seconds
    private bool isNPCInside = false; // flag to check if NPC is inside the trigger
    private float timer = 0f; // timer for the delay
    public int upiahnambah;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            isNPCInside = true;
            timer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            isNPCInside = false;
        }
    }

    void Update()
    {
        if (isNPCInside)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                AddUpiah();
                isNPCInside = false;
            }
        }
    }

    void AddUpiah()
    {
        UpiahManager.instance.AddCoins(upiahnambah);
    }

}
