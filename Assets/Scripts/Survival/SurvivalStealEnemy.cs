using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalStealEnemy : MonoBehaviour{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    public GameObject[] powerUps;
    public GameObject gameManager;

    [SerializeField] private float speed;

    void Start(){
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager");
    }

    void Update(){
        powerUps = GameObject.FindGameObjectsWithTag("Powerup");

        if(!gameManager.gameObject.GetComponent<SurvivalGameManager>().paused){
            Vector3 lookDirection;

            if(powerUps.Length != 0){
                speed = 0.2f;
                lookDirection = (powerUps[0].transform.position - transform.position).normalized;
            }
            else{
                speed = 1.0f;
                lookDirection = (player.transform.position - transform.position).normalized;
            }

            enemyRigidbody.AddForce(lookDirection * speed);
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Powerup")){
            Destroy(other.gameObject);
        }
    }
}
