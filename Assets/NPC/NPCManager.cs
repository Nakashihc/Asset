using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab; // the NPC prefab to spawn
    public float spawnInterval = 5f; // spawn interval in seconds
    public int maxNPCs = 5; // maximum number of NPCs to spawn

    private float nextSpawnTime; // next spawn time
    private List<GameObject> npcs = new List<GameObject>(); // list of spawned NPCs
    public Transform[] moveSpots; // move spots for the NPCs (using Tag "MoveSpot")
    public Transform pathSpot1; // first special path spot
    public Transform pathSpot2; // second special path spot
    public Transform deadSpot; // second special path spot
    public Transform keluarr;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        // Find all objects with the "MoveSpot" tag
        moveSpots = GameObject.FindObjectsOfType<Transform>().Where(t => t.CompareTag("MoveSpot")).ToArray();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && npcs.Count < maxNPCs)
        {
            SpawnNPC();
            nextSpawnTime = Time.time + spawnInterval;
        }
        moveSpots = GameObject.FindObjectsOfType<Transform>().Where(t => t.CompareTag("MoveSpot")).ToArray();
    }

    void SpawnNPC()
    {
        // spawn the NPC at a random move spot
        Transform randomMoveSpot = moveSpots[Random.Range(0, moveSpots.Length)];
        GameObject npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
        npcs.Add(npc);
        UpdateNPCData(npc);
    }

    public void UpdateNPCData(GameObject npc)
    {
        // Set the tag of the NPC to "NPC"
        npc.tag = "NPC";
    }
}
