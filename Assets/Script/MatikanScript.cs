using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatikanScript : MonoBehaviour
{
    public UnityEvent MatiScript;
    public UnityEvent NyalakanScript;

    public void matiScriptt()
    {
        MatiScript.Invoke();
    }
    public void NyalakanScriptt()
    {
        NyalakanScript.Invoke();
    }
}
