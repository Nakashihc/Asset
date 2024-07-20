using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNPCLvl1 : MonoBehaviour
{
    private Dictionary<GameObject, Coroutine> CowokCoroutines = new Dictionary<GameObject, Coroutine>();
    private Dictionary<GameObject, Coroutine> CewekCoroutines = new Dictionary<GameObject, Coroutine>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            if (!CowokCoroutines.ContainsKey(other.gameObject))
            {
                Coroutine coroutine = StartCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
                CowokCoroutines.Add(other.gameObject, coroutine);
            }
        }
        if (other.CompareTag("NPCcewek"))
        {
            if (!CewekCoroutines.ContainsKey(other.gameObject))
            {
                Coroutine coroutine = StartCoroutine(UpiahManager.instance.AddUpiahWithDelaylvl1());
                CewekCoroutines.Add(other.gameObject, coroutine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            if (CowokCoroutines.ContainsKey(other.gameObject))
            {
                StopCoroutine(CowokCoroutines[other.gameObject]);
                CowokCoroutines.Remove(other.gameObject);
            }
        }
        
        if (other.CompareTag("NPCcewek"))
        {
            if (CewekCoroutines.ContainsKey(other.gameObject))
            {
                StopCoroutine(CewekCoroutines[other.gameObject]);
                CewekCoroutines.Remove(other.gameObject);
            }
        }
    }

}
