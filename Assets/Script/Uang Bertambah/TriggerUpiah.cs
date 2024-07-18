using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerUpiah : MonoBehaviour
{
    public string targetTag = "NPC"; // tag of the object that triggers the Upiah addition
    public int upiahToAdd;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == targetTag)
        {
            UpiahManager.instance.AddCoins(upiahToAdd); // Add coins to the UpiahManager
            Debug.Log("Koin Bertambah 10");
        }
    }
}
