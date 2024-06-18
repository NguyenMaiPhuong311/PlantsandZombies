using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    [SerializeField] private GameObject sunObject;
    [SerializeField] private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSun", cooldown, cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSun()
    {
        
       GameObject mySun= Instantiate(sunObject,transform.position,Quaternion.identity);
        mySun.GetComponent<Sun>().dropToPos = transform.position.y - 0.5f;
    }
}
