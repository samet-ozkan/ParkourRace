using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubeCreatorSc : MonoBehaviour
{
    public GameObject enemyCubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createEnemyCube());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createEnemyCube(){
        while(true){
            GameObject enemyCubeRef = Instantiate(enemyCubePrefab, this.transform.position, enemyCubePrefab.transform.rotation);
            enemyCubeRef.transform.parent = this.gameObject.transform;
            float wait = Random.Range(6f, 9f);
            yield return new WaitForSeconds(wait);
        }
    }
}
