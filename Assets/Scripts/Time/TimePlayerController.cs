using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayerController : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public Rigidbody playerRigidbody;
    public GameObject focalPoint;
    public GameObject gameManager;

    void Start(){
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        MovePlayer();
    }

    void MovePlayer(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(!gameManager.gameObject.GetComponent<TimeGameManager>().paused){
            //Forward and backwards
            playerRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
            //Left and right
            playerRigidbody.AddForce(focalPoint.transform.right * speed * horizontalInput);
        }
    }
}
