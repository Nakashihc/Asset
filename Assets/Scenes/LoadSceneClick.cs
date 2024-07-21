﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneClick : MonoBehaviour
{

    [Header("Main Settings")]
    public string TargetScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(TargetScene);
    }
}
