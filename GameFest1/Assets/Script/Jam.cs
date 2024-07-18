using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jam : MonoBehaviour
{
    public TextMeshProUGUI waktuTextMesh;
    public TextMeshProUGUI hariTextMesh;

    public GameObject menuObject;
    public Button lanjutkanButton;

    public int jam;
    private int menit;
    private bool waktuBerhenti;

    private string[] hariArray = { "Senin", "Selasa", "Rabu", "Kamis" };
    private int hariIndex;

    private void Start()
    {
        jam = 7;
        menit = 0;
        hariIndex = 0;
        waktuBerhenti = false;

        lanjutkanButton.onClick.AddListener(LanjutkanWaktu);

        UpdateWaktu();
        UpdateHari();
    }

    private void Update()
    {
        if (waktuBerhenti)
            return;

        if (Time.time % 0.5f < Time.deltaTime)
        {
            menit += 1;
        }

        if (menit >= 60)
        {
            menit = 0;
            jam += 1;
        }

        if (jam >= 17)
        {
            jam = 7;
            waktuBerhenti = true;
            menuObject.SetActive(true);
        }

        UpdateWaktu();
    }

    private void LanjutkanWaktu()
    {
        menuObject.SetActive(false);
        waktuBerhenti = false;
        hariIndex = (hariIndex + 1) % hariArray.Length;
        UpdateHari();
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
