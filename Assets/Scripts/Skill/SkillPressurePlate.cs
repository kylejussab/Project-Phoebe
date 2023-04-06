using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPressurePlate : MonoBehaviour{
    public Material activatedMaterial;
    public Material deactivatedMaterial;
    public GameObject gameManager;

    public bool activated = false;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            activated = !activated;
            ActivatePlate();
        }
    }

    public void ActivatePlate(){
        if(activated){
            transform.GetComponent<Renderer>().material = activatedMaterial;
            gameManager.GetComponent<SkillGameManager>().activatedPlates++;
        }
        else{
            transform.GetComponent<Renderer>().material = deactivatedMaterial;
            gameManager.GetComponent<SkillGameManager>().activatedPlates--;
        }
    }
}
