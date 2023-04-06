using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectPropellerPressurePlate : MonoBehaviour{
    public Material activatedMaterial;
    public Material deactivatedMaterial;
    public GameObject gameManager;

    public bool activated = false;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Propeller")){
            if(!activated){
                activated = !activated;
                ActivatePlate();
            }
        }
    }

    public void ActivatePlate(){
        if(activated){
            transform.GetComponent<Renderer>().material = activatedMaterial;
            gameManager.GetComponent<IntellectGameManager>().activatedPlates++;
        }
        else{
            transform.GetComponent<Renderer>().material = deactivatedMaterial;
            gameManager.GetComponent<IntellectGameManager>().activatedPlates--;
        }
    }
}
