using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerController : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public Rigidbody playerRigidbody;
    public GameObject focalPoint;
    public GameObject gameManager;

    public bool onGround = true;
    
    void Start(){
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        MovePlayer();
    }

    void MovePlayer(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(!gameManager.gameObject.GetComponent<SkillGameManager>().paused){
            //Forward and backwards
            playerRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
            //Left and right
            playerRigidbody.AddForce(focalPoint.transform.right * speed * horizontalInput);

            //Jump
            if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1)) && onGround){
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                onGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PressurePlate")){
            onGround = true;
        }
    }
}
