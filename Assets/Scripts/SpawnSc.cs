using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSc : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private PlayerSc playerSc;
    private Vector3 position;
    void Start(){
        playerSc = player.GetComponent<PlayerSc>();
        position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            playerSc.SetSpawn(position);
        } 
    }
}
