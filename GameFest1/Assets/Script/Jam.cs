using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Jam : MonoBehaviour
{
    public TextMeshProUGUI waktuTextMesh;
    public TextMeshProUGUI hariTextMesh;

    public int jam;
    private int menit;

    private void Start()
    {
        jam = 7;
        menit = 0;

        UpdateWaktu();
    }

    private void Update()
    {
        if (Time.time % 0.5 < Time.deltaTime)
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
        }

        UpdateWaktu();
    }

    private void UpdateWaktu()
    {
        string waktuString = string.Format("{0:00}:{1:00}", jam, menit);
        waktuTextMesh.text = waktuString;
    }
}