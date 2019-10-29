using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField]
    private float spawnTime;
    void Start()
    {

        StartCoroutine(startSpawner());
    }

    
    void Update()
    {
        
    }
    IEnumerator startSpawner()
    {
        
        
            yield return new WaitForSeconds(spawnTime);
            GameObject enemy = Instantiate(prefabs, transform.position, transform.rotation);
        
    }
   

}
