using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalEnemy : MonoBehaviour{
    [SerializeField] private float speed;

    private Rigidbody enemyRigidbody;
    private GameObject player;
    public GameObject gameManager;

    void Start(){
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager");
    }

    void Update(){
        if(!gameManager.gameObject.GetComponent<SurvivalGameManager>().paused) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(lookDirection * speed);
        }

        if(transform.position.y < -10){
            Destroy(gameObject);
        }
    }
}
