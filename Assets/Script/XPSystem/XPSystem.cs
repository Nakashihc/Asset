using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XPSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] public int Level;
    private int CurrentXP;
    [SerializeField] private float TargetXP;
    [SerializeField] private Slider XpSlider;

    void Update()
    {
        ExperienceController();
    }

    public void ExperienceController()
    {
        LevelText.text = Level.ToString();
        XpSlider.value = (float)CurrentXP / TargetXP;

        if (CurrentXP >= TargetXP)
        {
            CurrentXP = CurrentXP - (int)TargetXP;
            Level++;
            TargetXP += 30f;
        }
    }

    public void TambahXP(int tambahXP)
    {
        CurrentXP += tambahXP;
        ExperienceController();
    }
}