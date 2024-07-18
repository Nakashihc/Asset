using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalamRuangan : MonoBehaviour
{
    public float delayTime = 3f; // time delay in seconds
    private bool isNPCInside = false; // flag to check if NPC is inside the trigger
    private float timer = 0f; // timer for the delay
    public int upiahnambah = 10; // amount of upiah to add

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC") && other.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNPCInside = true;
            timer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC") && other.gameObject.layer == LayerMask.NameToLayer("NPC"))
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
                isNPCInside = false; // reset flag to prevent multiple additions
                timer = 0f; // reset timer
            }
        }
    }

    void AddUpiah()
    {
        UpiahManager.instance.AddCoins(upiahnambah);
    }
}
