using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    private Scene CurrentScene;

    public float volume;
    public int screenHeight;
    public int screenWidth;
    public bool fullscreen;

    void Start()
    {
        DontDestroyOnLoad(this);
        CurrentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        CheckSceneMatch();
    }

    private void CheckSceneMatch()
    {
        if(CurrentScene != SceneManager.GetActiveScene())
        {
            ApplySettings();
        }
        CurrentScene = SceneManager.GetActiveScene();
    }

    private void ApplySettings()
    {
        Screen.fullScreen = fullscreen;

    }
}
