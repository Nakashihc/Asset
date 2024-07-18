using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalk : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    private NPCManager npcManager; // reference to the NPCManager script
    private int currentSpotIndex; // current move spot index
    private float timer; // timer for waiting at each spot
    private NavMeshAgent agent; // NavMeshAgent component

    public float personalSpaceRadius = 1.0f;
    private enum NPCState { Path1, Path2, RandomMove }
    private NPCState currentState;

    void Start()
    {
        npcManager = GameObject.FindObjectOfType<NPCManager>(); // find the NPCManager script
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        currentState = NPCState.Path1;
        timer = startWaitTime;
    }

    void Update()
    {
        switch (currentState)
        {
            case NPCState.Path1:
                agent.SetDestination(npcManager.pathSpot1.position);
                if (Vector2.Distance(transform.position, npcManager.pathSpot1.position) < 0.2f)
                {
                    currentState = NPCState.Path2;
                }
                break;
            case NPCState.Path2:
                agent.SetDestination(npcManager.pathSpot2.position);
                if (Vector2.Distance(transform.position, npcManager.pathSpot2.position) < 0.2f)
                {
                    currentState = NPCState.RandomMove;
                    SetRandomDestination();
                }
                break;
            case NPCState.RandomMove:
                if (Vector2.Distance(transform.position, npcManager.moveSpots[currentSpotIndex].position) < 0.2f)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        SetRandomDestination();
                        timer = startWaitTime;
                    }
                }
                break;
        }

        // Check if NPC enters a layer mask to be destroyed
        if (IsInLayerMask())
        {
            Destroy(gameObject);
        }
    }

    void SetRandomDestination()
    {
        int newSpotIndex = Random.Range(0, npcManager.moveSpots.Length);
        while (newSpotIndex == currentSpotIndex) // make sure it's a different spot
        {
            newSpotIndex = Random.Range(0, npcManager.moveSpots.Length);
        }
        currentSpotIndex = newSpotIndex;
        agent.SetDestination(npcManager.moveSpots[currentSpotIndex].position);
    }

    bool IsInLayerMask()
    {
        // Check if the NPC is in the specific layer mask
        return (gameObject.layer == LayerMask.NameToLayer("Hilang"));
    }
}
