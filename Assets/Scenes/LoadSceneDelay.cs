using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneDelay : MonoBehaviour
{

    [Header("Main Settings")]
    public string TargetScene;
    public float Delay;

    public void LoadScene()
    {
        Invoke("Scene", Delay);
    }

    void Scene()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
