using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndurancePlayerController : MonoBehaviour{
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

        if(!gameManager.gameObject.GetComponent<EnduranceGameManager>().paused){
            //Forward and backwards
            playerRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
            //Left and right
            playerRigidbody.AddForce(focalPoint.transform.right * speed * horizontalInput);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("StealEnemy") || collision.gameObject.CompareTag("Enemy")){
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * 30, ForceMode.Impulse);
        }
    }
}
