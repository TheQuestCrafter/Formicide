using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PauseMenuFunctions : MonoBehaviour
{
    //The Pause Panel that holds all pause menus
    [SerializeField]
    private GameObject PauseMenu;

    //First Selected Object in each menu
    [SerializeField]
    private GameObject mainPauseFirstSelected;
    [SerializeField]
    private GameObject saveMenuFirstSelected;
    [SerializeField]
    private GameObject settingsFirstSelected;
    [SerializeField]
    private GameObject exitFirstSelected;

    //Each of the panels in the pause menu so the event system can detect when object menus are switched.
    [SerializeField]
    private GameObject mainPausePanel;
    [SerializeField]
    private GameObject saveGamePanel;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject exitPanel;

    //Grabbing UI Objects which will help us store settings.
    private Toggle fullscreen;
    private Slider volume;
    private Dropdown screenSize;

    private bool pauseActive = false;
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
        menuSwitch = 0;
    }

    //So the key can be pressed at anytime, the keydown is called in update as opposed to fixed update.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = !pauseActive;
            CheckPausePanel();
            if (pauseActive)
            {
                eventSystem.SetSelectedGameObject(mainPauseFirstSelected);
                activePanelHistory = mainPauseFirstSelected;
            }
        }
    }

    private void FixedUpdate()
    {
        
        if (pauseActive)
        {
            CheckActivePanel();
            CheckEventSystem();
        }
    }

    //Checks if the game is paused and sets the appropriate activation state as such as well as sets the time scale.
    public void CheckPausePanel()
    {
        PauseMenu.SetActive(pauseActive);
        if (pauseActive)
        {
            ResetPause();
        }
        else
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }

    public void changeActive()
    {
        pauseActive = !pauseActive;
        CheckPausePanel();
    }

    //Checks if the EventSystem is either null or if the active menu is changed, if so then it will prompt further action.
    private void CheckEventSystem()
    {
        if (eventSystem.currentSelectedGameObject == null  && pauseActive)
        {
            UpdateEventSystem();
        }
        else if(activePanelHistory.name != currentActivePanel.name && pauseActive)
        {
            UpdateEventSystem();
        }
        activePanelHistory = currentActivePanel;
    }

    //Checks which panel is currently active and changes the currently active panel so it can be compared to the history.
    private void CheckActivePanel()
    {
        if (mainPausePanel.activeInHierarchy)
        {
            currentActivePanel = mainPausePanel;
            menuSwitch = 0;
        }
        else if (saveGamePanel.activeInHierarchy)
        {
            currentActivePanel = saveGamePanel;
            menuSwitch = 1;
        }
        else if (settingsPanel.activeInHierarchy)
        {
            currentActivePanel = settingsPanel;
            menuSwitch = 2;
        }
        else if (exitPanel.activeInHierarchy)
        {
            currentActivePanel = exitPanel;
            menuSwitch = 3;
        }
    }

    //Takes input scene number and unloads this scene and loads a new one.
    public void ToMainMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(0);
    }

    //Quits the game
    public void ExitToDesktop()
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
                newSelected = saveMenuFirstSelected;
                break;
            case 2:
                newSelected = settingsFirstSelected;
                break;
            case 3:
                newSelected = exitFirstSelected;
                break;
            default:
                newSelected = mainPauseFirstSelected;
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
        if (screenSize.value == 0)
        {
            settingsManager.screenWidth = 1920;
            settingsManager.screenHeight = 1080;
        }
        else if (screenSize.value == 1)
        {
            settingsManager.screenWidth = 1366;
            settingsManager.screenHeight = 768;
        }
        else if (screenSize.value == 2)
        {
            settingsManager.screenWidth = 1600;
            settingsManager.screenHeight = 900;
        }
        settingsManager.ApplySettings();
    }

    private void ResetPause()
    {
        mainPausePanel.SetActive(true);
        settingsPanel.SetActive(false);
        saveGamePanel.SetActive(false);
        exitPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(mainPauseFirstSelected);
        activePanelHistory = mainPauseFirstSelected;
    }
}
