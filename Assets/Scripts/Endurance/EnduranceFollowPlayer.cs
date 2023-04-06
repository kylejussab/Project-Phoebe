using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceFollowPlayer : MonoBehaviour{
    public GameObject player;
   
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -8);

    void LateUpdate(){
        transform.position = player.transform.TransformPoint(offset);
        transform.rotation = player.transform.rotation;
    }
}
