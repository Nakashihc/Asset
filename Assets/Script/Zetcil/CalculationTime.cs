using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CalculationTime : MonoBehaviour
{

    public enum CTimeCalculation { None, Increment, Decrement }
    public enum CTimeFormat { Normal, SS, MMSS, HHMMSS }

    [Header("Current Value")]
    public int CurrentValue;
    public bool Activated;

    [Header("Time Settings")]
    public CTimeCalculation TimeCalculation;
    public CTimeFormat TimeFormat;
    public int MinValue = 0;
    public int MaxValue = 60;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;
    public UnityEvent EndTimeEvents;

    bool isActive;
    int TotalScore;
    bool StartTransfer = false;

    void ExecuteIncrement()
    {
        if (isActive)
        {
            CurrentValue = CurrentValue + 1;
            if (CurrentValue >= MaxValue)
            {
                isActive = false;
                EndTimeEvents.Invoke();
                CancelInvoke();
            }
        }
    }

    void ExecuteDecrement()
    {
        if (isActive)
        {
            CurrentValue = CurrentValue - 1;
            if (CurrentValue <= MinValue)
            {
                isActive = false;
                EndTimeEvents.Invoke();
                CancelInvoke();
            }
        }
    }

    public void StartTimer()
    {
        isActive = true;
        if (MaxValue == 0)
        {
            MaxValue = CurrentValue;
        }

        if (TimeCalculation == CTimeCalculation.Increment)
        {
            InvokeRepeating("ExecuteIncrement", 1, 1);
        }
        if (TimeCalculation == CTimeCalculation.Decrement)
        {
            InvokeRepeating("ExecuteDecrement", 1, 1);
        }
    }

    public void StopTimer()
    {
        isActive = false;
        CancelInvoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (MaxValue == 0)
        {
            MaxValue = CurrentValue;
        }
        if (Activated)
        {
            StartTimer();
        }
        StartEvents?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateEvents?.Invoke();

        if (StartTransfer)
        {
            CurrentValue += 1;
            if (CurrentValue > TotalScore)
            {
                CurrentValue = TotalScore;
                StartTransfer = false;
            }
        }
        if (CurrentValue == MaxValue)
        {
            CurrentValue = 0;
            StartTimer();
        }
    }

    string SetFormatTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(CurrentValue);
        string formattedTime = CurrentValue.ToString();

        if (TimeFormat == CTimeFormat.SS)
        {
            // Format waktu menjadi jam:menit:detik
            formattedTime = string.Format("{0:D2}", time.Seconds);
        }
        else if (TimeFormat == CTimeFormat.MMSS)
        {
            // Format waktu menjadi jam:menit:detik
            formattedTime = string.Format("{0:D2}:{1:D2}",
                time.Minutes,
                time.Seconds);
        }
        else if (TimeFormat == CTimeFormat.HHMMSS)
        {
            // Format waktu menjadi jam:menit:detik
            formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                time.Hours,
                time.Minutes,
                time.Seconds);
        }

        return formattedTime;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(transform.gameObject.name, CurrentValue);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            CurrentValue = PlayerPrefs.GetInt(transform.name);
        }
    }

    public void SetCurrentValue(int aValue)
    {
        CurrentValue = aValue;
        if (CurrentValue <= 0) CurrentValue = 0;
    }

    public void AddToCurrentValue(int aValue)
    {
        CurrentValue += aValue;
    }

    public void SubtractFromCurrentValue(int aValue)
    {
        CurrentValue -= aValue;
        if (CurrentValue <= 0) CurrentValue = 0;
    }
    public void WriteTo(Slider aValue)
    {
        aValue.value = CurrentValue;
    }

    public void WriteTo(InputField aValue)
    {
        aValue.text = CurrentValue.ToString();
        aValue.text = SetFormatTime();
    }

    public void WriteTo(Text aValue)
    {
        aValue.text = CurrentValue.ToString();
        aValue.text = SetFormatTime();
    }

    public void WriteTo(TextMesh aValue)
    {
        aValue.text = CurrentValue.ToString();
        aValue.text = SetFormatTime();
    }

    public void TransferToCurrentValue(int aValue)
    {
        TotalScore = CurrentValue + aValue;
        StartTransfer = true;
        Invoke("ThreeSecond", 3);
    }
    public void ReadFrom(Slider aValue)
    {
        CurrentValue = Mathf.RoundToInt(aValue.value);
    }

    public void ReadFrom(InputField aValue)
    {
        CurrentValue = int.Parse(aValue.text);
    }
    void ThreeSecond()
    {
        CurrentValue = TotalScore;
    }
}

