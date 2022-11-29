using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGreenTargetSc : MonoBehaviour
{

    public GameObject door;
    public GameObject player;
    private GameObject parent;
    private Rigidbody doorRb;
    private bool isRed;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        doorRb = door.GetComponent<Rigidbody>();
        isRed = false;
        StartCoroutine(RedCoroutine());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RedCoroutine(){
        while(true){
            float wait = Random.Range(3f, 10f);
            yield return new WaitForSeconds(wait);
            isRed = (isRed) ? false : true;
            GetComponent<Renderer>().material.color = (isRed) ? new Color(255, 0, 0) : new Color(0, 255, 0);
        }
    }

    void OnTriggerEnter(Collider other){
        if(isRed && other.tag == "Bullet"){

            if(parent.transform.childCount == 1){
                doorRb.isKinematic = false;
                player.GetComponent<Control2Sc>().enabled = false;
                player.GetComponent<Control3Sc>().enabled = true;
            }
            Destroy(this.gameObject);
        }
    }
}
