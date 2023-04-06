using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalRotateCamera : MonoBehaviour{
    [SerializeField] private float rotationSpeed;

    void Update(){
        float horizontalInput = Input.GetAxis("HorizontalCamera");

        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);
    }
}
