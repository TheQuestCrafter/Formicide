using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    //Current Scene Number for GoToScene to change to. Default to the tutorial.
    [SerializeField]
    private int sceneNum = 1;

    [SerializeField]
    private Button MainMenuSelect;

    //First Selected Object in each menu
    [SerializeField]
    private GameObject mainMenuFirstSelected;
    [SerializeField]
    private GameObject loadMenuFirstSelected;
    [SerializeField]
    private GameObject settingsFirstSelected;
    [SerializeField]
    private GameObject creditsFirstSelected;

    //Each of the panels on the Main Menu so the event system can detect when object menus are switched.
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject loadGamePanel;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject creditsPanel;

    //Grabbing UI Objects which will help us store settings.
    private Toggle fullscreen;
    private Slider volume;
    private Dropdown screenSize;

    private EventSystem eventSystem;
    private GameObject activePanelHistory;
    private GameObject currentActivePanel;
    //Main Menu is 0, Load Menu is 1, Settings Menu is 2, and Credits Menu is 3
    private int menuSwitch;
    
    private void Awake()
    {
        eventSystem = (EventSystem)FindObjectOfType(typeof(EventSystem));
    }
    private void Start()
    {
        eventSystem.SetSelectedGameObject(mainMenuFirstSelected);
        activePanelHistory = mainMenuFirstSelected;
        menuSwitch = 0;
    }

    private void FixedUpdate()
    {
        CheckActivePanel();
        CheckEventSystem();
    }

    //Checks if the EventSystem is either null or if the active menu is changed, if so then it will prompt further action.
    private void CheckEventSystem()
    {
        if (eventSystem.currentSelectedGameObject == null || activePanelHistory.name != currentActivePanel.name)
        {
            UpdateEventSystem();
        }
        activePanelHistory = currentActivePanel;
    }

    //Checks which panel is currently active and changes the currently active panel so it can be compared to the history.
    private void CheckActivePanel()
    {
        if (mainMenuPanel.activeInHierarchy)
        {
            currentActivePanel = mainMenuPanel;
            menuSwitch = 0;
        }
        else if (loadGamePanel.activeInHierarchy)
        {
            currentActivePanel = loadGamePanel;
            menuSwitch = 1;
        }
        else if (settingsPanel.activeInHierarchy)
        {
            currentActivePanel = settingsPanel;
            menuSwitch = 2;
        }
        else if (creditsPanel.activeInHierarchy)
        {
            currentActivePanel = creditsPanel;
            menuSwitch = 3;
        }
    }

    //Takes input scene number and unloads this scene and loads a new one.
    public void GoToScene(int sceneNum)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneNum);
    }

    //Quits the game
    public void EndGame()
    {
        Application.Quit();
    }

    //Called if the event system needs to detect that a new submenu is opened so it resets the currently selected GameObject
    private void UpdateEventSystem()
    {
        GameObject newSelected;
        switch (menuSwitch)
        {
            case 1:
                newSelected = loadMenuFirstSelected;
                break;
            case 2:
                newSelected = settingsFirstSelected;
                break;
            case 3:
                newSelected = creditsFirstSelected;
                break;
            default:
                newSelected = mainMenuFirstSelected;
                break;
        }
        eventSystem.SetSelectedGameObject(newSelected);
    }
    
    //Finds the settings manager in the scene and takes the player input and sends that data to the manager.
    public void SaveSettings()
    {
        SettingsManager settingsManager = (SettingsManager)FindObjectOfType(typeof(SettingsManager));
        fullscreen = (Toggle)FindObjectOfType(typeof(Toggle));
        volume = (Slider)FindObjectOfType(typeof(Slider));
        screenSize = (Dropdown)FindObjectOfType(typeof(Dropdown));
        settingsManager.fullscreen = fullscreen.isOn;
        settingsManager.volume = volume.value;
        if(screenSize.value == 0)
        {
            settingsManager.screenWidth = 1920;
            settingsManager.screenHeight = 1080;
        }
        else if(screenSize.value == 1)
        {
            settingsManager.screenWidth = 1366;
            settingsManager.screenHeight = 768;
        }
        else if(screenSize.value == 2)
        {
            settingsManager.screenWidth = 1600;
            settingsManager.screenHeight = 900;
        }
        settingsManager.ApplySettings();
    }
}
