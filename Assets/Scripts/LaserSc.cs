using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSc : MonoBehaviour
{

    public float speed;
    private Vector3 firstPosition;

    // Start is called before the first frame update
    void Start()
    {
       firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.z - firstPosition.z) >= 12f){
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate(){
        transform.Translate(transform.parent.transform.forward * speed * Time.deltaTime);
    }

}
