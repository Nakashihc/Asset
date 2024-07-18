using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNPCRandom : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    private NPCManager npcManager; // reference to the NPCManager script
    private int randomSpot;

    void Start()
    {
        npcManager = GameObject.FindObjectOfType<NPCManager>(); // find the NPCManager script
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, npcManager.moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, npcManager.moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, npcManager.moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, npcManager.moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

}
