using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceTimedEnemy : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private int sectionID;

    public Rigidbody enemyRigidbody;
    private GameObject player;
    public GameObject gameManager;
    public Vector3 startPosition;

    public bool seeking = true;
    public bool isDead = false;

    void Start(){
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Body");
        gameManager = GameObject.Find("Game Manager");
        StartCoroutine(SeekingCountdown());
    }

    void Update(){
        if(!gameManager.gameObject.GetComponent<EnduranceGameManager>().paused && !isDead && seeking && (sectionID == gameManager.gameObject.GetComponent<EnduranceGameManager>().section)){
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(lookDirection * speed);
        }

        if(transform.position.y < -1){
            enemyRigidbody.useGravity = false;
            isDead = true;
            enemyRigidbody.velocity = Vector3.zero;
            enemyRigidbody.position = new Vector3(0, -1, 300);
        }

        if(sectionID < gameManager.gameObject.GetComponent<EnduranceGameManager>().section){
            Destroy(gameObject);
        }
    }

    IEnumerator SeekingCountdown(){
        while(!gameManager.gameObject.GetComponent<EnduranceGameManager>().gameOver){
            if(seeking){
                yield return new WaitForSeconds(15);
            }
            else{
                yield return new WaitForSeconds(4);
            }

            seeking = !seeking;
        }       
    }
}
