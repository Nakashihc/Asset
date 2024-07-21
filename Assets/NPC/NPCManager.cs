using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCManager : MonoBehaviour
{
    [Header("Spawn Prefab")]
    public GameObject[] cowokPrefabs;
    public GameObject[] cewekPrefabs;

    [Header("Waktu Spawn")]
    private float minWaktu = 1f;
    public float maxWaktu = 5f;
    public int maxNPCs = 5;
    private float spawnacakk;

    private float nextSpawnTime;
    private List<GameObject> npcs = new List<GameObject>();

    [Header("Tempat Spawn")]
    public Transform Spawn1;
    public Transform Spawn2;

    [Header("Jalan Masuk")]
    public Transform pathSpot1;
    public Transform pathSpot2;

    [Header("Acak Lokasi Dalam Museum")]
    public Transform[] moveSpots;

    [Header("Jalan Keluar")]
    public Transform keluarr;
    public Transform keluarr2;

    [Header("Tempat Hilang")]
    public Transform[] deadSpots;

    [Header("Cuma Lewat")]
    public Transform cumalewat;

    private Jam jam;

    void Start()
    {
        jam = GameObject.FindObjectOfType<Jam>();
        nextSpawnTime = Time.time + spawnacakk;
        moveSpots = GameObject.FindObjectsOfType<Transform>().Where(t => t.CompareTag("MoveSpot")).ToArray();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && npcs.Count < maxNPCs)
        {
            SpawnNPC();
            nextSpawnTime = Time.time + spawnacakk;
        }
        moveSpots = GameObject.FindObjectsOfType<Transform>().Where(t => t.CompareTag("MoveSpot")).ToArray();
    }

    void SpawnNPC()
    {
        Transform randomSpawnSpot = Random.value > 0.5f ? Spawn1 : Spawn2;

        // Pilih secara acak prefab cowok atau cewek
        GameObject prefabToSpawn;
        if (Random.value > 0.5f)
        {
            prefabToSpawn = cowokPrefabs[Random.Range(0, cowokPrefabs.Length)];
        }
        else
        {
            prefabToSpawn = cewekPrefabs[Random.Range(0, cewekPrefabs.Length)];
        }

        spawnacakk = Random.Range(minWaktu, maxWaktu);

        GameObject npc = Instantiate(prefabToSpawn, randomSpawnSpot.position, Quaternion.identity);
        npcs.Add(npc);
    }
}
