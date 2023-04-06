using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceEnemy : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private int sectionID;
    public Vector3 startPosition;

    public Rigidbody enemyRigidbody;
    private GameObject player;
    public GameObject gameManager;

    public bool isDead = false;

    void Start(){
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Body");
        gameManager = GameObject.Find("Game Manager");
    }

    void Update(){
        if(!gameManager.gameObject.GetComponent<EnduranceGameManager>().paused && !isDead && (sectionID == gameManager.gameObject.GetComponent<EnduranceGameManager>().section)){
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(lookDirection * speed);
        }

        if(transform.position.y <= -1){
            enemyRigidbody.useGravity = false;
            isDead = true;
            enemyRigidbody.velocity = Vector3.zero;
            enemyRigidbody.position = new Vector3(0, -1, 300);
        }

        if(sectionID < gameManager.gameObject.GetComponent<EnduranceGameManager>().section){
            Destroy(gameObject);
        }
    }
}
