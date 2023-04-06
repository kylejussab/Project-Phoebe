using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntellectSpinner : MonoBehaviour{
    [SerializeField] private GameObject propeller;
    private Rigidbody rigidBody;

    public bool isSpinning = true;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update(){
        if(isSpinning){
            propeller.transform.Rotate(0, 0, 1200 * Time.deltaTime);
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
        }
        else{
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            propeller.transform.rotation = new Quaternion(propeller.transform.rotation.x, 0, propeller.transform.rotation.z, 0);
        }
    }
}
