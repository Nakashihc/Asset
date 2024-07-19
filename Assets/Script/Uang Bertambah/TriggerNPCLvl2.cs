using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNPCLvl2 : MonoBehaviour
{
    public List<GameObject> NPCsInTrigger = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && other.CompareTag("NPCcewek"))
        {
            NPCsInTrigger.Add(other.gameObject);
            Debug.Log("NPC masuk trigger: " + other.gameObject.name);

            StartCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl2());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && other.CompareTag("NPCcewek"))
        {
            NPCsInTrigger.Remove(other.gameObject);
            Debug.Log("NPC keluar trigger: " + other.gameObject.name);
            StopCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl2());
        }
    }

}
