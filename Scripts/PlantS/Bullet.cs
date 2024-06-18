using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damge;
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private bool freeze;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            zombie.Hit(damge, freeze);
            Destroy(gameObject);
        }
    }
}
