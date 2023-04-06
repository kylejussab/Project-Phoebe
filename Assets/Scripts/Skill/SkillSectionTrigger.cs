using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSectionTrigger : MonoBehaviour{
    public GameObject gameManager;

    [SerializeField] private int sectionID;

    private void OnTriggerEnter(Collider other){
        if(gameManager.GetComponent<SkillGameManager>().section < sectionID){
            gameManager.GetComponent<SkillGameManager>().section = sectionID;
        }
    }
}
