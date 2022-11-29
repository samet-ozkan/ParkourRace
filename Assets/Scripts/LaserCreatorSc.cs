using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCreatorSc : MonoBehaviour
{
    public GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createLaser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createLaser(){
        while(true){
            GameObject laserRef = Instantiate(laserPrefab, this.transform.position, laserPrefab.transform.rotation);
            laserRef.transform.parent = this.gameObject.transform;
            float wait = Random.Range(1f, 5f);
            yield return new WaitForSeconds(wait);
        }
    }
}
