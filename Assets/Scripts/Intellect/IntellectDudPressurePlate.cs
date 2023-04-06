using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectDudPressurePlate : MonoBehaviour{
    public Material activatedMaterial;
    public Material deactivatedMaterial;

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
        }
        else{
            transform.GetComponent<Renderer>().material = deactivatedMaterial;
        }
    }
}
