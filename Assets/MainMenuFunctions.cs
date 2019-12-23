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

    private void CheckEventSystem()
    {
        if (eventSystem.currentSelectedGameObject == null || activePanelHistory.name != currentActivePanel.name)
        {
            UpdateEventSystem();
        }
        activePanelHistory = currentActivePanel;
    }

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

    public void GoToScene(int sceneNum)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneNum);
    }

    public void EndGame()
    {
        Application.Quit();
    }

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
}
