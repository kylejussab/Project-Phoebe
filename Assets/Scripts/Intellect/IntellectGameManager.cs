using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntellectGameManager : MonoBehaviour{
    public GameObject[] plates;
    public GameObject[] doors;
    public GameObject[] blocks;
    public GameObject[] spinners;
    public GameObject[] spinnerPlates;
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

    public int activatedPlates = 0;
    public int section = 1;

    void Update(){
        HandleDoors();
        PauseMenu();
        CloseHelpMenu();
        PlayerFell();
        CompletedIntellect();
    }

    public void LoadScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Intellect");
    }

    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    void HandleDoors(){
        //Section 1
        if(section == 1){
            Section1Puzzle();

            if(activatedPlates == 3){
                if(doors[0].transform.position.y < 3.74){
                    doors[0].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 3){
                if(doors[0].transform.position.y > 1.25){
                    doors[0].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
        }

        //Section 2
        if(section == 2){
            if (activatedPlates == 5){
                if(doors[1].transform.position.y < 3.74){
                    doors[1].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 5){
                if (doors[1].transform.position.y > 1.25){
                    doors[1].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
        }

        //Section 3
        if(section == 3){
            if(activatedPlates == 6){
                if (doors[2].transform.position.y < 3.74){
                    doors[2].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 6){
                if(doors[2].transform.position.y > 1.25){
                    doors[2].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
        }

        //Section 4
        if(section == 4){
            if(activatedPlates == 7){
                if(doors[3].transform.position.y < 3.74){
                    doors[3].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 7){
                if (doors[3].transform.position.y > 1.25){
                    doors[3].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
        }

        //Section 5
        if(section == 5){
            if(activatedPlates == 9){
                if (doors[4].transform.position.y < 3.74){
                    doors[4].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 9){
                if (doors[4].transform.position.y > 1.25){
                    doors[4].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
        }

        //Section 6
        if(section == 6){
            if(activatedPlates == 13){
                if(doors[5].transform.position.y < 3.74){
                    doors[5].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }

            if(activatedPlates < 13){
                if(doors[5].transform.position.y > 1.25){
                    doors[5].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
                }
            }
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

    public void RestartCheckpoint(){
        if(section == 1){
            LoadScene();
        }

        if(section == 2){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for (int i = 0; i < 3; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }

            //Set the plates and door in that section to their default
            for (int i = 3; i < 4; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<IntellectPressurePlate>().deactivatedMaterial;
            }
            //Set special plates
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().activated = false;
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().transform.GetComponent<Renderer>().material = plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().deactivatedMaterial;

            doors[1].transform.position = new Vector3(doors[1].transform.position.x, 1.25f, doors[1].transform.position.z);

            blocks[0].transform.position = new Vector3(-6, 0.5f, 20);

            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 20);
            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 3){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 4; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }
            //Set special plates
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().activated = false;
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().transform.GetComponent<Renderer>().material = plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().deactivatedMaterial;
            activatedPlates++;

            //Set the plates and door in that section to their default
            for (int i = 5; i < 6; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<IntellectPressurePlate>().deactivatedMaterial;
            }

            doors[2].transform.position = new Vector3(doors[2].transform.position.x, 1.25f, doors[2].transform.position.z);

            //Reset Spinner
            spinners[0].transform.position = new Vector3(-3, 0, 65);
            spinners[0].GetComponent<IntellectSpinner>().isSpinning = true;

            //Reset Spinner Plate
            spinnerPlates[0].GetComponent<IntellectSpinnerPressurePlate>().activated = false;
            spinnerPlates[0].GetComponent<Renderer>().material = spinnerPlates[0].GetComponent<IntellectSpinnerPressurePlate>().playerDeactivatedMaterial;

            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 52);
            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 4){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 4; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }
            //Set special plates
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().activated = false;
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().transform.GetComponent<Renderer>().material = plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().deactivatedMaterial;
            activatedPlates++;

            plates[5].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
            plates[5].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();

            //Set the plates and door in that section to their default
            for (int i = 6; i < 7; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<IntellectPressurePlate>().deactivatedMaterial;
            }

            doors[3].transform.position = new Vector3(doors[3].transform.position.x, 1.25f, doors[3].transform.position.z);

            //Reset Spinner
            spinners[1].transform.position = new Vector3(10, 0, 79);
            spinners[1].GetComponent<IntellectSpinner>().isSpinning = true;
            spinners[2].transform.position = new Vector3(-10, 0, 88);
            spinners[2].GetComponent<IntellectSpinner>().isSpinning = true;

            //Reset Spinner Plate
            spinnerPlates[1].GetComponent<IntellectSpinnerPressurePlate>().activated = false;
            spinnerPlates[1].GetComponent<Renderer>().material = spinnerPlates[1].GetComponent<IntellectSpinnerPressurePlate>().playerDeactivatedMaterial;
            spinnerPlates[2].GetComponent<IntellectSpinnerPressurePlate>().activated = false;
            spinnerPlates[2].GetComponent<Renderer>().material = spinnerPlates[2].GetComponent<IntellectSpinnerPressurePlate>().blockDeactivatedMaterial;

            blocks[1].transform.position = new Vector3(-2, 0.5f, 86);

            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 83);
            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 5){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 4; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }

            //Set special plates
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().activated = false;
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().transform.GetComponent<Renderer>().material = plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().deactivatedMaterial;
            activatedPlates++;

            //Activate any other unaccounted for plates
            for(int i = 5; i < 7; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }

            //Set the plates and door in that section to their default
            plates[7].gameObject.GetComponent<IntellectPressurePlate>().activated = false;
            plates[7].gameObject.GetComponent<IntellectPressurePlate>().transform.GetComponent<Renderer>().material = plates[7].gameObject.GetComponent<IntellectPressurePlate>().deactivatedMaterial;
            plates[8].gameObject.GetComponent<IntellectPropellerPressurePlate>().activated = false;
            plates[8].gameObject.GetComponent<IntellectPropellerPressurePlate>().transform.GetComponent<Renderer>().material = plates[8].gameObject.GetComponent<IntellectPropellerPressurePlate>().deactivatedMaterial;

            doors[4].transform.position = new Vector3(doors[4].transform.position.x, 1.25f, doors[4].transform.position.z);

            //Reset Spinner
            spinners[3].transform.position = new Vector3(10, 0, 118);
            spinners[4].transform.position = new Vector3(-7, 0, 113);
            spinners[4].GetComponent<IntellectSpinner>().isSpinning = true;

            blocks[2].transform.position = new Vector3(-11, 0.5f, 120);
            blocks[3].transform.position = new Vector3(6, 0.5f, 107);

            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 110);
            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 6){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for (int i = 0; i < 4; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }

            //Set special plates
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().activated = false;
            plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().transform.GetComponent<Renderer>().material = plates[4].gameObject.GetComponent<IntellectColourPressurePlate>().deactivatedMaterial;
            activatedPlates++;

            //Activate any other unaccounted for plates
            for(int i = 5; i < 7; i++){
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            }
            plates[7].gameObject.GetComponent<IntellectPressurePlate>().activated = true;
            plates[7].gameObject.GetComponent<IntellectPressurePlate>().ActivatePlate();
            plates[8].gameObject.GetComponent<IntellectPropellerPressurePlate>().activated = true;
            plates[8].gameObject.GetComponent<IntellectPropellerPressurePlate>().ActivatePlate();

            //Set the normal plates and door in that section to their default
            for(int i = 9; i < 13; i++){
                plates[i].gameObject.GetComponent<IntellectSpinnerPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<IntellectSpinnerPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<IntellectSpinnerPressurePlate>().playerDeactivatedMaterial;
            }

            //Set the dud plates back to normal
            for(int i = 13; i < 21; i++){
                plates[i].gameObject.GetComponent<IntellectDudPressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<IntellectDudPressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<IntellectDudPressurePlate>().deactivatedMaterial;
            }

            doors[5].transform.position = new Vector3(doors[5].transform.position.x, 1.25f, doors[5].transform.position.z);

            //Reset Spinner
            spinners[5].transform.position = new Vector3(-12, 0, 148);
            spinners[5].GetComponent<IntellectSpinner>().isSpinning = true;
            spinners[6].transform.position = new Vector3(0, 0, 148);
            spinners[6].GetComponent<IntellectSpinner>().isSpinning = true;
            spinners[7].transform.position = new Vector3(4, 0, 148);
            spinners[7].GetComponent<IntellectSpinner>().isSpinning = true;
            spinners[8].transform.position = new Vector3(8, 0, 148);
            spinners[8].GetComponent<IntellectSpinner>().isSpinning = true;

            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 139);
            player.gameObject.GetComponent<IntellectPlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PlayerFell(){
        if(!gameOver && player.gameObject.GetComponent<IntellectPlayerController>().transform.position.y < -1){
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

    int[] puzzle1Order = { 0, 0, 0 };

    void Section1Puzzle(){
        //Plate 1
        //If you activated the first plate, and no other plate, then set the puzzle order
        //Otherwise reset everything
        if(plates[0].GetComponent<IntellectPressurePlate>().activated == true && plates[1].GetComponent<IntellectPressurePlate>().activated == false && plates[2].GetComponent<IntellectPressurePlate>().activated == false){
            puzzle1Order[0] = 1;
        }
        else if((plates[1].GetComponent<IntellectPressurePlate>().activated == true || plates[2].GetComponent<IntellectPressurePlate>().activated == true) && puzzle1Order[0] == 0){
            puzzle1Order[0] = 0;

            for(int i = 0; i < 3; i++){
                plates[i].transform.GetComponent<IntellectPressurePlate>().DeactivatePlate();
            }
            activatedPlates = 0;
        }

        //Plate 2
        //If you activated the correct second plate, and no other plate, then set the puzzle order
        //Otherwise reset everything
        if(puzzle1Order[0] == 1 && plates[2].GetComponent<IntellectPressurePlate>().activated == true && plates[1].GetComponent<IntellectPressurePlate>().activated == false){
            puzzle1Order[1] = 1;
        }
        else if(plates[1].GetComponent<IntellectPressurePlate>().activated == true && puzzle1Order[1] == 0){
            puzzle1Order[0] = 0;
            puzzle1Order[1] = 0;

            for(int i = 0; i < 3; i++){
                plates[i].transform.GetComponent<IntellectPressurePlate>().DeactivatePlate();
            }
            activatedPlates = 0;
        }

    }

    public void CompletedIntellect(){
        if(section == 7 && !completed){
            completed = true;
            completionFirstButton.Select();
            completionScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}