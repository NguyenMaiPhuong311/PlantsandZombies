using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sunObject;
    // Start is called before the first frame update
    void Start()
    {

        SpawnSun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSun()
    {
        
        GameObject mySun = Instantiate(sunObject, new Vector3(Random.Range(-4.51f, 7.09f), 5.51f, 0),Quaternion.identity);
       mySun.GetComponent<Sun>().dropToPos = Random.Range(2f, -3f);
        Invoke("SpawnSun", Random.Range(4, 10));
    }
}
