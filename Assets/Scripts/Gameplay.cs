using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Gameplay : MonoBehaviour
{
    public enum GameState {
        Playing,
        Paused
    }

    public GameState CurrentState { get; set; }
    

    [Header("Toggle Pause on/off")]
    public UnityEvent m_PauseGame;

    public MenuList FullMenuList;

    public GameObject PauseMenu;

    public GameObject SettingsMenu;

    public GameObject ActiveMenu;
    public GameObject PreviousMenu;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameState.Playing;
        if (m_PauseGame == null)
            m_PauseGame = new UnityEvent();

        m_PauseGame.AddListener(OnPause);

        ActiveMenu = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause() {
        // pause/unpause game
        if (CurrentState == GameState.Playing) {
            CurrentState = GameState.Paused;
            // show pause menu
            PauseMenu.SetActive(true);

        } else {
            CurrentState = GameState.Playing;
            // hide pause/settings menu
            PauseMenu.SetActive(false);
            SettingsMenu.SetActive(false);
        }
    }

    public void OpenSettingsMenu() {
        if (CurrentState != GameState.Paused) {
            return;
        }

        //Debug.Log("Lets do settings");
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ReturnToPauseMenu() {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void ExitGame()
    {
        // do exit stuff
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeVolume() {
        Debug.Log("Changing volume");
    }

    public void OpenMenu(string menuName) {
        if (ActiveMenu != null && ActiveMenu.name == menuName) {
            ActiveMenu.SetActive(false);
            return;
        }

        var menu = transform.Find(menuName).gameObject;
        if (menu != null) {
            ActiveMenu = menu;
            menu.SetActive(true);
        }
    }

    public void CloseActiveMenu() {
        ActiveMenu.SetActive(false);
        ActiveMenu = null;
    }
}
