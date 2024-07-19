using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Jam : MonoBehaviour
{
    [Header("Text Waktu dan Hari")]
    public TextMeshProUGUI waktuTextMesh;
    public TextMeshProUGUI hariTextMesh;

    [Header("Pintu Museum")]
    public GameObject menuObject;
    public Animator Pintu1;
    public Animator Pintu2;

    private NPCManager npcManager;

    [Header("Event Jam 16.00")]
    public UnityEvent JamTertentu;

    [Header("Waktu")]
    public int jam;
    public int menit;
    private bool waktuBerhenti;

    private float waktuberjalan = 0.2f;

    private string[] hariArray = { "Senin", "Selasa", "Rabu", "Kamis" };
    private int hariIndex;

    private void Start()
    {
        jam = 7;
        menit = 0;
        hariIndex = 0;
        waktuBerhenti = false;
        UpdateWaktu();
        UpdateHari();
    }

    private void Update()
    {
        if (waktuBerhenti)
            return;

        if (Time.time % waktuberjalan < Time.deltaTime)
        {
            menit += 1;
        }

        if (menit >= 60)
        {
            menit = 0;
            jam += 1;
        }

        if(jam == 16 && menit == 26)
        {
            JamTertentu?.Invoke();
            waktuberjalan = 0.5f;
        }

        if (jam == 16 && menit == 55)
        {
            Debug.Log("Waktunya Tutup Ganteng");
            Pintu1.SetBool("Tutup", true);
            Pintu2.SetBool("Tutup", true);
        }

        if (jam == 7 && menit == 1)
        {
            Pintu1.SetBool("Tutup", false);
            Pintu2.SetBool("Tutup", false);
        }

        if (jam >= 17)
        {
            waktuBerhenti = true;
            menuObject.SetActive(true);
            Time.timeScale = 0;
        }

        UpdateWaktu();
    }

    public void LanjutkanWaktu()
    {
        menuObject.SetActive(false);
        waktuBerhenti = false;
        hariIndex = (hariIndex + 1) % hariArray.Length;
        UpdateHari();
        Time.timeScale = 1;
        jam = 7;
        menit = 0;
        waktuberjalan = 0.2f;
    }

    private void UpdateWaktu()
    {
        string waktuString = string.Format("{0:00}:{1:00}", jam, menit);
        waktuTextMesh.text = waktuString;
    }

    private void UpdateHari()
    {
        hariTextMesh.text = hariArray[hariIndex];
    }
}
