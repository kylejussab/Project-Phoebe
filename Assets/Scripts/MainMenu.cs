using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    public Button playMenuFirstButton;
    public Button mainMenuFirstButton;

    public GameObject playMenu;
    public GameObject aboutMenu;

    public void LoadPlayMenu(){
        playMenu.SetActive(true);
        gameObject.SetActive(false);
        playMenuFirstButton.Select();
    }

    public void LoadMainMenu(){
        mainMenuFirstButton.Select();
        playMenu.SetActive(false);
        aboutMenu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void LoadAboutMenu(){
        aboutMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
