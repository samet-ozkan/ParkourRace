using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control3Sc : MonoBehaviour
{
    public float _speed;
    public float _jump; 
    public float _maxSpeed;
    private float horizontal_speed;
    private float vertical_speed;
    private PlayerSc playerSc;
    private Rigidbody rb;
    
    private Transform playerCamera;
    private float maxSpeedWithoutNitro;
    private float maxSpeedWithNitro;
   

     void Start(){
        rb = GetComponent<Rigidbody>();
        playerSc = GetComponent<PlayerSc>();
        InitCamera();
        maxSpeedWithNitro = _maxSpeed * 10;
        maxSpeedWithoutNitro = _maxSpeed;
    }

    void InitCamera(){
        playerCamera = this.gameObject.transform.GetChild(0).transform;
        playerCamera.localPosition = new Vector3(0, 1f, -2f);
        playerCamera.localEulerAngles = new Vector3(10f, 0f, 0f);
    }

    void FixedUpdate(){
        PlayerControl();
    }

    void PlayerControl(){
        switch(name){
            case "P1":
                P1CharacterControl();
                break;
            case "P2":
                P2CharacterControl();
                break;
            default:
                break;
        }
    }

    void P1CharacterControl(){
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        if(Input.GetAxis("P1Horizontal") != 0)
        {
            horizontal_speed = Input.GetAxisRaw("P1Horizontal") * 50;
            transform.Rotate(0f, horizontal_speed * Time.deltaTime * 2, 0f, Space.Self);
        }
        if(Mathf.Abs(localVelocity.z) <= _maxSpeed && Input.GetAxis("P1Vertical") != 0)
        {
            vertical_speed = Input.GetAxisRaw("P1Vertical") * _speed;
            rb.AddForce(transform.forward * vertical_speed);
        }
        
        if(Input.GetAxisRaw("P1Jump") != 0 && playerSc.onGround){
            rb.AddForce(Vector3.up * _jump);
        }
    }

    void P2CharacterControl(){
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        if(Input.GetAxis("P2Horizontal") != 0)
        {
            horizontal_speed = Input.GetAxisRaw("P2Horizontal") * 50;
            transform.Rotate(0f, horizontal_speed * Time.deltaTime * 2, 0f, Space.Self);
        }
        if(Mathf.Abs(localVelocity.z) <= _maxSpeed && Input.GetAxis("P2Vertical") != 0)
        {
            vertical_speed = Input.GetAxisRaw("P2Vertical") * _speed;
            rb.AddForce(transform.forward * vertical_speed);
        }
        
        if(Input.GetAxisRaw("P2Jump") != 0 && playerSc.onGround){
            rb.AddForce(Vector3.up * _jump);
        }
    }


}
