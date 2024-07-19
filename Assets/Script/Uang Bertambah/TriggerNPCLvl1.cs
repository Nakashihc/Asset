using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNPCLvl1 : MonoBehaviour
{
    public List<GameObject> NPCcowokInTrigger = new List<GameObject>();
    public List<GameObject> NPCcewekInTrigger = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            NPCcowokInTrigger.Add(other.gameObject);
            Debug.Log("NPC masuk trigger: " + other.gameObject.name);

            StartCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
        }
        if (other.CompareTag("NPCcewek"))
        {
            NPCcewekInTrigger.Add(other.gameObject);
            Debug.Log("NPC masuk trigger: " + other.gameObject.name);

            StartCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            StopCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
            NPCcowokInTrigger.Remove(other.gameObject);
            Debug.Log("Cowok keluar trigger: " + other.gameObject.name);
        }
        
        if (other.CompareTag("NPCcewek"))
        {
            StopCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
            NPCcewekInTrigger.Remove(other.gameObject);
            Debug.Log("Cewek keluar trigger: " + other.gameObject.name);
        }
    }

}
