using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour{
    public GameObject mainMenu;

    void Update(){
        if(Input.GetKeyDown(KeyCode.JoystickButton2)){
            mainMenu.gameObject.GetComponent<MainMenu>().LoadMainMenu();
        }
    }

    public void LoadSkillLevel(){
        SceneManager.LoadScene("Skill");
    }

    public void LoadEnduranceLevel(){
        SceneManager.LoadScene("Endurance");
    }

    public void LoadIntellectLevel(){
        SceneManager.LoadScene("Intellect");
    }

    public void LoadTimeLevel()
    {
        SceneManager.LoadScene("Time");
    }

    public void LoadSurvivalLevel(){
        SceneManager.LoadScene("Survival");
    }
}
