using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float dropToPos;
    private float speed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject,Random.Range(6f,12f));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > dropToPos) { 
        transform.position -= new Vector3(0,speed*Time.deltaTime,0);
        }
        
    
    }
}
