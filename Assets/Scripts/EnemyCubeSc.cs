using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubeSc : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0f){
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate(){
        //transform.Translate(transform.forward * speed * Time.deltaTime);
        rb.AddForce(transform.parent.transform.forward * speed);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            //HP
        }
    }

}
