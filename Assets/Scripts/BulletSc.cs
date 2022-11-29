using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSc : MonoBehaviour
{

    public float bulletSpeed;
    public Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(forward != null){
        transform.Translate(forward * bulletSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag != "Player"){
        Destroy(this.gameObject);
        }
    }
}
