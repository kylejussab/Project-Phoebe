using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeGameManager : MonoBehaviour{
    public GameObject pauseScreen;
    public GameObject helpScreen;
    public GameObject gameOverScreen;
    public GameObject completionScreen;

    public Button pauseFirstButton;
    public Button gameOverFirstButton;
    public Button completionFirstButton;
    public GameObject player;

    public bool paused = false;
    public bool help = false;
    public bool gameOver = false;
    public bool completed = false;
    private bool timerOn = false;

    [SerializeField] private TextMeshProUGUI timerText;

    private float timePassed = 0;
    public int section = 0;

    void Update(){
        PauseMenu();
        CloseHelpMenu();
        PlayerFell();
        Timer();
        CompletedEndurance();
    }

    public void LoadScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Time");
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

    public void PlayerFell(){
        if(!gameOver && player.gameObject.GetComponent<TimePlayerController>().transform.position.y < -1){
            gameOver = true;
            gameOverScreen.SetActive(true);
            gameOverFirstButton.Select();
            Time.timeScale = 0;
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

    void Timer(){
        if(section == 1){
            timerOn = true;
        }
        else{
            timerOn = false;
        }

        if(timerOn){
            timePassed += Time.deltaTime;

            float minutes = Mathf.FloorToInt(timePassed / 60);
            float seconds = Mathf.FloorToInt(timePassed % 60);

            if(minutes < 10){
                if(seconds < 10){
                    timerText.text = "Time: 0" + minutes + ":0" + seconds;
                }
                else{
                    timerText.text = "Time: 0" + minutes + ":" + seconds;
                }
            }
            else{
                if (seconds < 10){
                    timerText.text = "Time: 0" + minutes + ":0" + seconds;
                }
                else{
                    timerText.text = "Time: " + minutes + ":" + seconds;
                }
            }
        }
    }

    public void CompletedEndurance(){
        if(section == 2 && !completed){
            completed = true;
            completionFirstButton.Select();
            completionScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
