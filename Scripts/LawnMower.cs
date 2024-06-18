using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour
{
    private bool isMoving;
    public float speed = 1;
    [SerializeField] private AudioClip music;
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.layer == 7)
        {
            if (!isMoving)
            {
                source.PlayOneShot(music);
            }
            other.GetComponent<Zombie>().Hit(100, false);
            isMoving = true;
            
            Destroy(gameObject,8);
        }
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
