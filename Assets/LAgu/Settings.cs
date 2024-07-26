using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    [Header ("Pause")]
    public UnityEvent Pause1x;

    [Header("UnPause")]
    public UnityEvent Pause2x;
    public float waktupause;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                StartCoroutine(PauseWithDelay());
            }
            else
            {
                Unpause();
                Pause2x?.Invoke();
            }
        }
    }

    private IEnumerator PauseWithDelay()
    {
        Pause1x?.Invoke();
        yield return new WaitForSeconds(waktupause);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
