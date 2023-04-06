using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMenu : MonoBehaviour{
    public GameObject mainMenu;

    void Update(){
        if(Input.GetKeyDown(KeyCode.JoystickButton2)){
            mainMenu.gameObject.GetComponent<MainMenu>().LoadMainMenu();
        }
    }
}
