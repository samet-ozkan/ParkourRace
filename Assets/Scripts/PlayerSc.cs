using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSc : MonoBehaviour
{
    
    public GameObject game;
    private GameSc gameSc; 
    private Rigidbody rb; 
    public bool onGround;
    public GameObject section2ChangeControl; 
    private Vector3 spawn;
    private bool isFinishedParkour;
    
    void Start(){
        isFinishedParkour = false;
        rb = GetComponent<Rigidbody>();
        onGround = false;
        gameSc = game.GetComponent<GameSc>();
    }

    void FixedUpdate(){
        if(!isFinishedParkour){
            ReduceScale();
        }
    }

    void ReduceScale(){
        if(rb.velocity.magnitude > 1 && transform.localScale.magnitude > 1){
            transform.localScale -= new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.01f * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Floor"){
            onGround = true;
        }

        if(other.gameObject.tag == "Plane"){
            if(!isFinishedParkour){
                Spawn();
            }
        }
    }

    void OnCollisionStay(Collision other){
        if(!onGround && other.gameObject.tag == "Floor"){
            onGround = true;
        }
    }

    void OnCollisionExit(Collision other){
        if(onGround){
            onGround = false;
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger girdi: " + other.gameObject.name);
        if(other.gameObject.tag == "Laser"){
            Spawn();
            Control3Sc control3 = this.gameObject.GetComponent<Control3Sc>();
            if(!control3.enabled){
                this.gameObject.GetComponent<Control2Sc>().enabled = false;
                Control1Sc control1 = this.gameObject.GetComponent<Control1Sc>();
                control1.enabled = true;
                control1.InitCamera();
                this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                section2ChangeControl.SetActive(true);
            }
        }

        if(other.gameObject.name == "P1LastLoop" && gameObject.name == "P1") {
            Debug.Log("P1 girdi.");
            gameSc.P1Win();
        }
        
        else if(other.gameObject.name == "P2LastLoop" && gameObject.name == "P2") {
            Debug.Log("P2 Girdi.");
            gameSc.P2Win();
        } 
    }

    public void SetSpawn(Vector3 spawn){
        this.spawn = spawn;
    }

    public void Spawn(){
        this.transform.position = spawn;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
