using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNPCRandom : MonoBehaviour
{
    [Header("Kecepatan NPC")]
    public float speed;

    [Header("Waktu Menunggu NPC")]
    public float waitTime;

    private Jam jam;
    private int currentSpotIndex;
    private int currentDeadSpotIndex;
    private float timer;
    private float patrolTimer;

    // Script Sambungan
    private NPCManager npcManager;

    private enum NPCState { Path1, Path2, RandomMove, ExitPath1, ExitPath2, MoveToDeadSpot }
    private NPCState currentState;

    [Header("Waktu NPC Bertahan dalam Museum")]
    public int waktuBertahan;
    public int minimalwaktu;
    private int waktuacak;

    void Start()
    {
        npcManager = GameObject.FindObjectOfType<NPCManager>();
        jam = GameObject.FindObjectOfType<Jam>();

        currentState = NPCState.Path1;
        timer = waitTime;
        patrolTimer = 0;

        SetRandomReturnTime();
    }

    void Update()
    {
        patrolTimer += Time.deltaTime;

        if (jam.jam >= 16 && jam.menit >= 30)
        {
            if (currentState == NPCState.Path1 || currentState == NPCState.Path2 || currentState == NPCState.RandomMove)
            {
                currentState = NPCState.ExitPath1;
            }
        }

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
                        timer = waitTime;
                    }
                }
                if (patrolTimer >= waktuacak)
                {
                    currentState = NPCState.ExitPath1;
                }
                break;
            case NPCState.ExitPath1:
                MoveTo(npcManager.keluarr.position);
                if (Vector2.Distance(transform.position, npcManager.keluarr.position) < 0.2f)
                {
                    currentState = NPCState.ExitPath2;
                }
                break;
            case NPCState.ExitPath2:
                MoveTo(npcManager.keluarr2.position);
                if (Vector2.Distance(transform.position, npcManager.keluarr2.position) < 0.2f)
                {
                    currentState = NPCState.MoveToDeadSpot;
                    SetRandomDeadSpot();
                }
                break;
            case NPCState.MoveToDeadSpot:
                MoveTo(npcManager.deadSpots[currentDeadSpotIndex].position);
                if (Vector2.Distance(transform.position, npcManager.deadSpots[currentDeadSpotIndex].position) < 0.2f)
                {
                    Destroy(gameObject);
                }
                break;
        }

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
        while (newSpotIndex == currentSpotIndex)
        {
            newSpotIndex = Random.Range(0, npcManager.moveSpots.Length);
        }
        currentSpotIndex = newSpotIndex;
    }

    void SetRandomDeadSpot()
    {
        currentDeadSpotIndex = Random.Range(0, npcManager.deadSpots.Length);
    }

    bool IsInLayerMask()
    {
        return (gameObject.layer == LayerMask.NameToLayer("Hilang"));
    }

    void SetRandomReturnTime()
    {
        waktuacak = Random.Range(minimalwaktu, waktuBertahan);
    }
}
