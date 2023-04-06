using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndurancePressurePlate : MonoBehaviour{
    public Material activatedMaterial;
    public Material deactivatedMaterial;
    public GameObject gameManager;

    [SerializeField] private string collisionThing;

    public bool activated = false;

    private void OnTriggerEnter(Collider other){
        //The steal enemy can deactivate any plate
        if(other.gameObject.CompareTag("Enemy") && collisionThing == "Enemy"){
            activated = !activated;
            ActivatePlate();
        }

        if(other.gameObject.CompareTag("Player") && collisionThing == "Player"){
            activated = !activated;
            ActivatePlate();
        }

        if(other.gameObject.CompareTag("StealEnemy") && activated){
            activated = false;
            ActivatePlate();
        }
    }

    public void ActivatePlate(){
        if(activated){
            transform.GetComponent<Renderer>().material = activatedMaterial;
            gameManager.GetComponent<EnduranceGameManager>().activatedPlates++;
        }
        else{
            transform.GetComponent<Renderer>().material = deactivatedMaterial;
            gameManager.GetComponent<EnduranceGameManager>().activatedPlates--;
        }
    }
}
