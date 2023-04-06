using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnduranceGameManager : MonoBehaviour{
    public GameObject[] doors;
    public GameObject[] plates;
    public GameObject[] enemies;
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
        CompletedEndurance();
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
            if (doors[1].transform.position.y < 3.74){
                doors[1].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if (activatedPlates < 3){
            if (doors[1].transform.position.y > 1.25){
                doors[1].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 3
        if(activatedPlates == 5){
            if(doors[2].transform.position.y < 3.74){
                doors[2].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 5){
            if(doors[2].transform.position.y > 1.25){
                doors[2].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 4
        if(activatedPlates == 10){
            if(doors[3].transform.position.y < 3.74){
                doors[3].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 10){
            if(doors[3].transform.position.y > 1.25){
                doors[3].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 5
        if(activatedPlates == 16){
            if(doors[4].transform.position.y < 3.74){
                doors[4].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 16){
            if (doors[4].transform.position.y > 1.25){
                doors[4].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 6
        if(activatedPlates == 22){
            if(doors[5].transform.position.y < 3.74){
                doors[5].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 22){
            if(doors[5].transform.position.y > 1.25){
                doors[5].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        //Section 7
        if(activatedPlates == 31){
            if(doors[6].transform.position.y < 3.74)
            {
                doors[6].transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }

        if(activatedPlates < 31){
            if(doors[6].transform.position.y > 1.25){
                doors[6].transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
            }
        }
    }

    public void LoadScene(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Endurance");
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
            for (int i = 0; i < 1; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for (int i = 1; i < 3; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[1].transform.position = new Vector3(doors[1].transform.position.x, 1.25f, doors[1].transform.position.z);

            //Reset enemy postions
            enemies[0].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[0].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[0].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[0].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[0].gameObject.GetComponent<EnduranceEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 20);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 3){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 3; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 3; i < 5; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[2].transform.position = new Vector3(doors[2].transform.position.x, 1.25f, doors[2].transform.position.z);

            //Reset enemy postions
            enemies[1].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[1].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[1].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[1].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[1].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 48);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 4){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 5; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 5; i < 10; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[3].transform.position = new Vector3(doors[3].transform.position.x, 1.25f, doors[3].transform.position.z);

            //Reset enemy postions
            enemies[2].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[2].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[2].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[2].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[2].gameObject.GetComponent<EnduranceEnemy>().isDead = false;
            enemies[3].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[3].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[3].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[3].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[3].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 79);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 5){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 10; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 10; i < 16; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[4].transform.position = new Vector3(doors[4].transform.position.x, 1.25f, doors[4].transform.position.z);

            //Reset enemy postions
            enemies[4].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[4].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[4].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[4].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[4].gameObject.GetComponent<EnduranceEnemy>().isDead = false;
            enemies[5].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[5].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[5].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[5].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[5].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[6].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.position = enemies[6].gameObject.GetComponent<EnduranceTimedEnemy>().startPosition;
            enemies[6].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[6].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.useGravity = true;
            enemies[6].gameObject.GetComponent<EnduranceTimedEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 121);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 6){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for (int i = 0; i < 16; i++)
            {
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 16; i < 22; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[5].transform.position = new Vector3(doors[5].transform.position.x, 1.25f, doors[5].transform.position.z);

            //Reset enemy postions
            enemies[7].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[7].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[7].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[7].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[7].gameObject.GetComponent<EnduranceEnemy>().isDead = false;
            enemies[8].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[8].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[8].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[8].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[8].gameObject.GetComponent<EnduranceEnemy>().isDead = false;
            enemies[9].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[9].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[9].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[9].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[9].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[10].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[10].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[10].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[10].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[10].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[11].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.position = enemies[11].gameObject.GetComponent<EnduranceTimedEnemy>().startPosition;
            enemies[11].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[11].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.useGravity = true;
            enemies[11].gameObject.GetComponent<EnduranceTimedEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 162);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if(section == 7){
            activatedPlates = 0;

            //Loop over the plates in all previous sections
            for(int i = 0; i < 22; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = true;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().ActivatePlate();
            }

            //Set the plates are door in that section to their default
            for(int i = 22; i < 31; i++){
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().activated = false;
                plates[i].gameObject.GetComponent<EndurancePressurePlate>().transform.GetComponent<Renderer>().material = plates[i].gameObject.GetComponent<EndurancePressurePlate>().deactivatedMaterial;
            }
            doors[6].transform.position = new Vector3(doors[6].transform.position.x, 1.25f, doors[6].transform.position.z);

            //Reset enemy postions
            enemies[12].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[12].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[12].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[12].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[12].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[13].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[13].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[13].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[13].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[13].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[14].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.position = enemies[14].gameObject.GetComponent<EnduranceStealEnemy>().startPosition;
            enemies[14].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[14].gameObject.GetComponent<EnduranceStealEnemy>().enemyRigidbody.useGravity = true;
            enemies[14].gameObject.GetComponent<EnduranceStealEnemy>().isDead = false;
            enemies[15].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.position = enemies[15].gameObject.GetComponent<EnduranceTimedEnemy>().startPosition;
            enemies[15].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[15].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.useGravity = true;
            enemies[15].gameObject.GetComponent<EnduranceTimedEnemy>().isDead = false;
            enemies[16].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.position = enemies[16].gameObject.GetComponent<EnduranceTimedEnemy>().startPosition;
            enemies[16].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[16].gameObject.GetComponent<EnduranceTimedEnemy>().enemyRigidbody.useGravity = true;
            enemies[16].gameObject.GetComponent<EnduranceTimedEnemy>().isDead = false;
            enemies[17].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[17].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[17].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[17].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[17].gameObject.GetComponent<EnduranceEnemy>().isDead = false;
            enemies[18].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.position = enemies[18].gameObject.GetComponent<EnduranceEnemy>().startPosition;
            enemies[18].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.velocity = Vector3.zero;
            enemies[18].gameObject.GetComponent<EnduranceEnemy>().enemyRigidbody.useGravity = true;
            enemies[18].gameObject.GetComponent<EnduranceEnemy>().isDead = false;

            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.position = new Vector3(0, 0.75f, 196);
            player.gameObject.GetComponent<EndurancePlayerController>().playerRigidbody.velocity = Vector3.zero;

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
        if(!gameOver && player.gameObject.GetComponent<EndurancePlayerController>().transform.position.y < -1){
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

    public void CompletedEndurance(){
        if(section == 8 && !completed){
            completed = true;
            completionFirstButton.Select();
            completionScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
