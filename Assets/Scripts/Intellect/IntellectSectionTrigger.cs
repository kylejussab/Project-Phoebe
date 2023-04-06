using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectSectionTrigger : MonoBehaviour{
    public GameObject gameManager;

    [SerializeField] private int sectionID;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(gameManager.GetComponent<IntellectGameManager>().section < sectionID){
                gameManager.GetComponent<IntellectGameManager>().section = sectionID;
            }
        }
    }
}
