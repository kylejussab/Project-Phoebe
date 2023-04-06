using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceSectionTrigger : MonoBehaviour{
    public GameObject gameManager;

    [SerializeField] private int sectionID;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(gameManager.GetComponent<EnduranceGameManager>().section < sectionID){
                gameManager.GetComponent<EnduranceGameManager>().section = sectionID;
            }
        }
    }
}
