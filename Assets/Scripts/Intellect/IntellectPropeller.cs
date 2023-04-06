using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectPropeller : MonoBehaviour{
    [SerializeField] private GameObject spinner;

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPropeller = collision.transform.position - transform.position;

            if(spinner.GetComponent<IntellectSpinner>().isSpinning){
                playerRigidbody.AddForce(awayFromPropeller * 50, ForceMode.Impulse);
            }
        }
    }
}
