using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectSpinnerPressurePlate : MonoBehaviour{
    public Material activatedMaterial;
    public Material playerDeactivatedMaterial;
    public Material blockDeactivatedMaterial;
    public GameObject gameManager;

    [SerializeField] private GameObject spinner;
    [SerializeField] private string type;

    public bool activated = false;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player") && type == "Player"){
            activated = !activated;
            spinner.GetComponent<IntellectSpinner>().isSpinning = !spinner.GetComponent<IntellectSpinner>().isSpinning;
            ActivatePlate();
        }

        if(other.gameObject.CompareTag("Block") && type == "Block"){
            activated = !activated;
            spinner.GetComponent<IntellectSpinner>().isSpinning = !spinner.GetComponent<IntellectSpinner>().isSpinning;
            ActivatePlate();
        }

        if(other.gameObject.CompareTag("Player") && type == "PlayerFinal"){
            activated = !activated;
            spinner.GetComponent<IntellectSpinner>().isSpinning = !spinner.GetComponent<IntellectSpinner>().isSpinning;
            ActivatePlate();
        }
    }

    public void ActivatePlate(){
        if(activated){
            transform.GetComponent<Renderer>().material = activatedMaterial;
            if(type == "PlayerFinal"){
                gameManager.GetComponent<IntellectGameManager>().activatedPlates++;
            }
        }
        else{
            if(type == "Player"){
                transform.GetComponent<Renderer>().material = playerDeactivatedMaterial;
            }
            else if(type == "Block"){
                transform.GetComponent<Renderer>().material = blockDeactivatedMaterial;
            }
            else if(type == "PlayerFinal"){
                transform.GetComponent<Renderer>().material = playerDeactivatedMaterial;
                gameManager.GetComponent<IntellectGameManager>().activatedPlates--;
            }

        }
    }
}
