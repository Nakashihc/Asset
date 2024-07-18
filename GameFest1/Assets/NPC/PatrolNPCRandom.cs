using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNPCRandom : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    private NPCManager npcManager; // reference to the NPCManager script
    private int currentSpotIndex; // current move spot index
    private float timer; // timer for waiting at each spot
    private float patrolTimer; // timer for total patrol time

    public float personalSpaceRadius = 1.0f;
    private enum NPCState { Path1, Path2, RandomMove, ExitPath, MoveToDeadSpot }
    private NPCState currentState;

    public int waktuBertahan;
    private int waktuacak;
    public int minimalwaktu;

    void Start()
    {
        npcManager = GameObject.FindObjectOfType<NPCManager>(); // find the NPCManager script

        currentState = NPCState.Path1;
        timer = startWaitTime;
        patrolTimer = 0;

        SetRandomReturnTime();
    }

    void Update()
    {
        patrolTimer += Time.deltaTime;

        switch (currentState)
        {
            case NPCState.Path1:
                MoveTo(npcManager.pathSpot1.position);
                if (Vector2.Distance(transform.position, npcManager.pathSpot1.position) < 0.2f)
                {
                    currentState = NPCState.Path2;
                }
                break;
            case NPCState.Path2:
                MoveTo(npcManager.pathSpot2.position);
                if (Vector2.Distance(transform.position, npcManager.pathSpot2.position) < 0.2f)
                {
                    currentState = NPCState.RandomMove;
                    SetRandomDestination();
                }
                break;
            case NPCState.RandomMove:
                MoveTo(npcManager.moveSpots[currentSpotIndex].position);
                if (Vector2.Distance(transform.position, npcManager.moveSpots[currentSpotIndex].position) < 0.2f)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        SetRandomDestination();
                        timer = startWaitTime;
                    }
                }
                if (patrolTimer >= waktuacak)
                {
                    currentState = NPCState.ExitPath;
                }
                break;
            case NPCState.ExitPath:
                MoveTo(npcManager.keluarr.position);
                if (Vector2.Distance(transform.position, npcManager.keluarr.position) < 0.2f)
                {
                    currentState = NPCState.MoveToDeadSpot;
                }
                break;
            case NPCState.MoveToDeadSpot:
                MoveTo(npcManager.deadSpot.position);
                if (Vector2.Distance(transform.position, npcManager.deadSpot.position) < 0.2f)
                {
                    Destroy(gameObject);
                }
                break;
        }

        // Check if NPC enters a layer mask to be destroyed
        if (IsInLayerMask())
        {
            Destroy(gameObject);
        }
    }

    void MoveTo(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    void SetRandomDestination()
    {
        int newSpotIndex = Random.Range(0, npcManager.moveSpots.Length);
        while (newSpotIndex == currentSpotIndex) // make sure it's a different spot
        {
            newSpotIndex = Random.Range(0, npcManager.moveSpots.Length);
        }
        currentSpotIndex = newSpotIndex;
    }

    bool IsInLayerMask()
    {
        // Check if the NPC is in the specific layer mask
        return (gameObject.layer == LayerMask.NameToLayer("Hilang"));
    }

    void SetRandomReturnTime()
    {
        waktuacak = Random.Range(minimalwaktu, waktuBertahan);
    }
}
