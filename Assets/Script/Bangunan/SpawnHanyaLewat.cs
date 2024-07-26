using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHanyaLewat : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    public GameObject[] Cowok;
    public GameObject[] Cewek;
    public Transform[] spawnPoints; // Dua spawn points
    public Transform[] cumaLewatPoints; // Dua cuma lewat points

    private float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    private float spawnInterval;
    private float nextSpawnTime;

    private List<GameObject> npcs = new List<GameObject>();

    void Start()
    {
        spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnNPC();
            spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnNPC()
    {
        // Pilih spawn point secara acak
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Transform cumaLewatPoint = (spawnIndex == 0) ? cumaLewatPoints[1] : cumaLewatPoints[0];

        // Pilih prefab cowok atau cewek secara acak dari array
        GameObject npcPrefab;
        if (Random.value > 0.5f)
        {
            npcPrefab = Cowok[Random.Range(0, Cowok.Length)];
        }
        else
        {
            npcPrefab = Cewek[Random.Range(0, Cewek.Length)];
        }

        GameObject npc = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
        HanyaLewat patrolScript = npc.GetComponent<HanyaLewat>();

        if (patrolScript != null)
        {
            patrolScript.SetCumaLewat(cumaLewatPoint);
        }

        npcs.Add(npc);
    }
}
