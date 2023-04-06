using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class SurvivalGameManager : MonoBehaviour{
    public GameObject pauseScreen;
    public GameObject helpScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI stageUI;
    public Button pauseFirstButton;
    public Button gameOverFirstButton;
    public GameObject player;

    public bool paused = false;
    public bool help = false;
    private bool gameOver = false;

    public int stage = 0;

    void Update(){
        PauseMenu();
        CloseHelpMenu();
        PlayerFell();
    }

    public void UpdateScore(){
        stageUI.text = "Stage: " + stage;
    }

    public void LoadScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Survival");
    }

    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    void PauseMenu(){
        if(!paused && !help && !gameOver && Input.GetKeyDown(KeyCode.JoystickButton9)){
            paused = true;
            pauseScreen.SetActive(true);
            pauseFirstButton.Select();
            Time.timeScale = 0;
        }
        else if(paused && !help && !gameOver && Input.GetKeyDown(KeyCode.JoystickButton2)){
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void CloseHelpMenu(){
        if(help && paused && Input.GetKeyDown(KeyCode.JoystickButton2)){
            help = false;
            pauseFirstButton.Select();
            pauseScreen.SetActive(true);
            helpScreen.SetActive(false);
        }
    }

    public void ClickedHelp(){
        if(!help){
            help = true;
            pauseScreen.SetActive(false);
            helpScreen.SetActive(true);
        }
    }

    public void PlayerFell(){
        if(!gameOver && player.gameObject.GetComponent<SurvivalPlayerController>().transform.position.y < -4){
            gameOver = true;
            gameOverScreen.SetActive(true);
            gameOverFirstButton.Select();
            Time.timeScale = 0;
        }
    }
}
