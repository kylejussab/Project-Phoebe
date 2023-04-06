using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSectionTrigger : MonoBehaviour{
    public GameObject gameManager;

    [SerializeField] private int sectionID;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(gameManager.GetComponent<TimeGameManager>().section < sectionID){
                gameManager.GetComponent<TimeGameManager>().section = sectionID;
            }
        }
    }
}
