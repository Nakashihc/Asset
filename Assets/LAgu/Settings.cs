using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    public UnityEvent ditekan;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ditekan?.Invoke();
        }
    }

}
