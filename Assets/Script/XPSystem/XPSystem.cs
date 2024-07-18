using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XPSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private int Level;
    private int CurrentXP;
    [SerializeField] private float TargetXP;
    [SerializeField] private Slider XpSlider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentXP += 12;
        }
        ExperienceController();
    }

    public void ExperienceController()
    {
        LevelText.text = Level.ToString();
        XpSlider.value = (float)CurrentXP / TargetXP; // Cast to float

        if (CurrentXP >= TargetXP)
        {
            CurrentXP = CurrentXP - (int)TargetXP; // Cast to int
            Level++;
            TargetXP += 50f; // Use float literal
        }
    }

    public void TambahXP(int tambahXP)
    {
        CurrentXP += tambahXP;
        ExperienceController();
    }
}