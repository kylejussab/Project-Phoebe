using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillGameManager : MonoBehaviour{
    public GameObject[] doors;
    public GameObject[] plates;
    public GameObject player;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject helpScreen;
    public GameObject completionScreen;
    public Button pauseFirstButton;
    public Button gameOverFirstButton;
    public Button completionFirstButton;

    public bool paused = false;
    private bool gameOver = false;
    private bool help = false;
    private bool completed = false;

    public int activatedPlates = 0;
    public int section = 1;

    void Update(){
        HandleDoors();
        PauseMenu();
        CloseHelpMenu();
        PlayerFell();
        CompletedSkill();
    }

    void HandleDoors(){
        //Section 1
        if(activatedPlates == 1){
            if(doors[0].transform.position.y < 3.74){
                doors[0].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 1){
            if(doors[0].transform.position.y > 1.25){
                doors[0].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 2
        if(activatedPlates == 3){
            if(doors[1].transform.position.y < 3.74){
                doors[1].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 3){
            if(doors[1].transform.position.y > 1.25){
                doors[1].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 3
        if(activatedPlates == 6){
            if(doors[2].transform.position.y < 3.74){
                doors[2].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 6){
            if(doors[2].transform.position.y > 1.25){
                doors[2].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 4
        if(activatedPlates == 11){
            if(doors[3].transform.position.y < 3.74){
                doors[3].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 11){
            if(doors[3].transform.position.y > 1.25){
                doors[3].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 5
        if(activatedPlates == 15){
            if(doors[4].transform.position.y < 3.74){
                doors[4].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 15){
            if(doors[4].transform.position.y > 1.25){
                doors[4].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 6
        if(activatedPlates == 16){
            if(doors[5].transform.position.y < 3.74){
                doors[5].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 16){
            if(doors[5].transform.position.y > 1.25){
                doors[5].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 7
        if(activatedPlates == 18){
            if(doors[6].transform.position.y < 3.74){
                doors[6].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 18){
            if(doors[6].transform.position.y > 1.25){
                doors[6].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }
    }

    public void LoadScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Skill");
    }

    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartCheckpoint(){
        if(section == 1){
            LoadScene();
        }

        if(section == 2){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for (int i = 0; i < 1; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 1; i < 2; ++i) {
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[1].transform.position = new Vector3(doors[1].transform.position.x, 1.25f, doors[1].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 20);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 3){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 3; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for (int i = 3; i < 5; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[2].transform.position = new Vector3(doors[2].transform.position.x, 1.25f, doors[2].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 45);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 4){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 6; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for (int i = 6; i < 10; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[3].transform.position = new Vector3(doors[3].transform.position.x, 1.25f, doors[3].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 77);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 5){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 11; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for (int i = 11; i < 14; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[4].transform.position = new Vector3(doors[4].transform.position.x, 1.25f, doors[4].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 106);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 6){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 15; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 15; i < 16; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[5].transform.position = new Vector3(doors[5].transform.position.x, 1.25f, doors[5].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 138);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if (section == 7)
        {
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 16; ++i){
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for (int i = 16; i < 18; ++i)
            {
                plates[i].gameObject.GetComponent<SkillPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<SkillPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<SkillPressurePlate>().deactivatedMaterial;
            }
            doors[6].transform.position = new Vector3(doors[6].transform.position.x, 1.25f, doors[6].transform.position.z);

            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 165);
            player.gameObject.GetComponent<SkillPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
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
        if(!gameOver && player.gameObject.GetComponent<SkillPlayerController>().transform.position.y < -1){
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

    public void CompletedSkill(){
        if(section == 8 && !completed){
            completed = true;
            completionScreen.SetActive(true);
            completionFirstButton.Select();
            Time.timeScale = 0;
        }
    }
}