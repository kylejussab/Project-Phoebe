using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFocalPoint : MonoBehaviour{
    public GameObject sphere;

    [SerializeField] private float rotationSpeed = 50.0f;

    void Start(){

    }

    void Update(){
        transform.position = sphere.transform.position;

        float horizontalInput = Input.GetAxis("HorizontalCamera");
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);
    }
}
