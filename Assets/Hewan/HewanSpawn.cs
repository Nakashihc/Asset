using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HewanSpawn : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    public GameObject Hewan1;
    public GameObject Hewan2;
    public GameObject Hewan3;
    public GameObject Hewan4;

    public Transform[] spawnPoints; // Dua spawn points
    public Transform[] cumaLewatPoints; // Dua cuma lewat points

    private float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    private float spawnInterval;
    private float nextSpawnTime;

    private List<GameObject> npcs = new List<GameObject>();

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnNPC();
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
        nextSpawnTime = Time.time + spawnInterval;
    }

    void SpawnNPC()
    {
        // Pilih spawn point secara acak
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Transform cumaLewatPoint = cumaLewatPoints[Random.Range(0, cumaLewatPoints.Length)];

        // Pilih prefab secara acak
        int hewanIndex = Random.Range(0, 3);
        GameObject npcPrefab;

        if (hewanIndex == 0)
        {
            npcPrefab = Hewan1;
        }
        else if (hewanIndex == 1)
        {
            npcPrefab = Hewan2;
        }
        else if (hewanIndex == 2)
        {
            npcPrefab = Hewan3;
        }
        else
        {
            npcPrefab = Hewan4;
        }

        GameObject npc = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);
        HewanJalan patrolScript = npc.GetComponent<HewanJalan>();

        if (patrolScript != null)
        {
            patrolScript.SetCumaLewat(cumaLewatPoint);
        }

        // Atur skala berdasarkan lokasi spawn
        if (spawnIndex == 0)
        {
            npc.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            npc.transform.localScale = new Vector3(1, 1, 1);
        }

        npcs.Add(npc);
    }
}
