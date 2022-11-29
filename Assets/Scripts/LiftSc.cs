using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSc : MonoBehaviour
{

    public float speed;
    
    private Vector3 localScale;
    private bool down;
    
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(down && transform.localPosition.y >= (-0.5f + (localScale.y/2))){
            transform.Translate(transform.up * -speed * Time.deltaTime);
        }
        else{
            down = false;
        }
    }

    void OnCollisionStay(Collision other){
        Vector3 position = transform.localPosition;
        float scale_y = localScale.y;
        if(position.y <= (0.5f - (scale_y/2))){
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
    }

    void OnCollisionExit(Collision other){
        down = true;
    }
}
