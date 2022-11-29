using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control2Sc : MonoBehaviour
{
    public float _speed;
    public float _jump; 
    public float _maxSpeed;
    private float horizontal_speed;
    private PlayerSc playerSc;
    private Rigidbody rb;
    public GameObject bullet;
    public GameObject location;
    private Transform playerCamera;
    public Transform cubeDoor;
    private bool fireOnce = true;

     void Start(){
        rb = GetComponent<Rigidbody>();
        playerSc = GetComponent<PlayerSc>();
    }

    void Update(){
        InitCamera();
    }

    void InitCamera(){
        playerCamera = this.gameObject.transform.GetChild(0).transform;
        location.transform.position = new Vector3(cubeDoor.position.x, cubeDoor.position.y, playerCamera.transform.position.z);
        playerCamera.position = new Vector3(cubeDoor.position.x, cubeDoor.position.y, playerCamera.transform.position.z);
        playerCamera.localEulerAngles = new Vector3(0f, 0f, 0f);
    }

    void FixedUpdate(){
        PlayerControl();
    }

    void PlayerControl(){
        switch(name){
            case "P1":
                P1CharacterControl();
                P1FireControl();
                break;
            case "P2":
                P2CharacterControl();
                P2FireControl();
                break;
            default:
                break;
        }
    }

    void P1CharacterControl(){
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        if(Mathf.Abs(localVelocity.x) <= _maxSpeed && Input.GetAxis("P1Horizontal") != 0)
        {
            horizontal_speed = Input.GetAxis("P1Horizontal") * _speed;
            transform.Rotate(0f, horizontal_speed * Time.deltaTime, 0f, Space.Self);
        }
        
        if(Input.GetAxisRaw("P1Jump") != 0 && playerSc.onGround){
            rb.AddForce(Vector3.up * _jump);
        }
    }

    void P1FireControl(){
        if(Input.GetAxisRaw("P1Skill") > 0 && fireOnce){
            fireOnce = false;
            GameObject bulletRef = Instantiate(bullet, location.transform.position, Quaternion.identity) as GameObject;
            Vector3 forward = location.transform.forward;
            BulletSc bulletSc = bulletRef.gameObject.GetComponent<BulletSc>();
            bulletSc.forward = forward;
        }
        else if(Input.GetAxisRaw("P1Skill") == 0){
            fireOnce = true;
        }
    }

    void P2CharacterControl(){
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        if(Mathf.Abs(localVelocity.x) <= _maxSpeed && Input.GetAxis("P2Horizontal") != 0)
        {
            horizontal_speed = Input.GetAxis("P2Horizontal") * _speed;
            transform.Rotate(0f, horizontal_speed * Time.deltaTime, 0f, Space.Self);
        }
        
        if(Input.GetAxisRaw("P2Jump") != 0 && playerSc.onGround){
            rb.AddForce(Vector3.up * _jump);
        }
    }

    void P2FireControl(){
        if(Input.GetAxisRaw("P2Skill") > 0 && fireOnce){
            fireOnce = false;
            GameObject bulletRef = Instantiate(bullet, location.transform.position, Quaternion.identity) as GameObject;
            Vector3 forward = location.transform.forward;
            BulletSc bulletSc = bulletRef.gameObject.GetComponent<BulletSc>();
            bulletSc.forward = forward;
        }
        else if(Input.GetAxisRaw("P2Skill") == 0){
            fireOnce = true;
        }
    }
}
