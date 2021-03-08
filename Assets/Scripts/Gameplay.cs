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
    
    public GameObject PauseMenu;

    [Header("Toggle Pause on/off")]
    public UnityEvent m_PauseGame;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameState.Playing;
        PauseMenu.SetActive(false);
        if (m_PauseGame == null)
            m_PauseGame = new UnityEvent();

        m_PauseGame.AddListener(OnPause);
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
            // hide pause menu
            PauseMenu.SetActive(false);
        }
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
}
