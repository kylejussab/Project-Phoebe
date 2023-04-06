using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnduranceStealEnemy : MonoBehaviour{
    [SerializeField] private float speed;
    [SerializeField] private int sectionID;
    [SerializeField] private string type;
    [SerializeField] private GameObject[] plates;

    public Rigidbody enemyRigidbody;
    public GameObject gameManager;
    public Vector3 startPosition;

    public bool isDead = false;

    void Start(){
        enemyRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager");
    }

    void Update(){
        if(!gameManager.gameObject.GetComponent<EnduranceGameManager>().paused && !isDead && (sectionID == gameManager.gameObject.GetComponent<EnduranceGameManager>().section)){
            GetPlates();
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

    void GetPlates(){
        if(type == "Two"){
            if(plates[0].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[0].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[1].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[1].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else{
                Vector3 lookDirection = (startPosition - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
        }
        else if(type == "Five"){
            if (plates[0].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[0].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[1].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[1].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[2].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[2].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[3].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[3].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[4].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[4].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else{
                Vector3 lookDirection = (startPosition - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
        }
        else if (type == "Six"){
            if(plates[0].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[0].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[1].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[1].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[2].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[2].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[3].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[3].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[4].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[4].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[5].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[5].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else{
                Vector3 lookDirection = (startPosition - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
        }
        else if(type == "Final"){
            if(plates[0].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[0].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[1].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[1].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[2].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[2].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[3].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[3].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[4].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[4].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[5].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[5].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[6].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[6].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[7].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[7].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else if(plates[8].gameObject.GetComponent<EndurancePressurePlate>().activated){
                Vector3 lookDirection = (plates[8].transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
            else{
                Vector3 lookDirection = (startPosition - transform.position).normalized;
                enemyRigidbody.AddForce(lookDirection * speed);
            }
        }
    }
}
