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
        //Right now each time the main menu is started, another will appear, should fix in future update.
        CurrentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        CheckSceneMatch();
    }

    //Checks to see if the scene has changed.
    private void CheckSceneMatch()
    {
        if(CurrentScene != SceneManager.GetActiveScene())
        {
            ApplySettings();
        }
        CurrentScene = SceneManager.GetActiveScene();
    }

    //Applies the resolution and fullscreen settings, sends for sound to be applied to sound sources.
    public void ApplySettings()
    {
        Screen.SetResolution(screenWidth, screenHeight, fullscreen);
        ApplySound();
    }

    //An array is made and grabs each AudioSource in the scene, then foreach sets it to the desired audio.
    private void ApplySound()
    {
        AudioSource[] soundList = FindObjectsOfType<AudioSource>();
        foreach( AudioSource sound in soundList)
        {
            sound.volume = volume;
        }
    }
}
