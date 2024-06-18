using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Zombie : MonoBehaviour
{
     private float speed;
    [SerializeField] private int health;
    [SerializeField] private int damage;
     private float range;
    public ZombieType type;
    [SerializeField] private LayerMask plantMask;
     private float eatCooldown;
    private Plant targetPlant;
    private bool canEat=true;
    private AudioSource source;
    [SerializeField] private AudioClip[] groans;
    public bool LastZombie;
    public bool dead;
    
    private void Start()
    {
        health = type.health;
        speed = type.speed;
        range = type.range;
        damage = type.damage;

        source = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = type.sprite;
        Invoke("Groan", Random.Range(1, 20));

    }
    

    void Groan()
    {
        source.PlayOneShot(groans[Random.Range(0,groans.Length)]);
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);
        if (hit.collider)
        {
            targetPlant= hit.collider.GetComponent<Plant>();
            Eat();
        }

        if (health == 1)
        {
            GetComponent<SpriteRenderer>().sprite = type.deathSprite;
        }
      
    }

    void Eat()
    {
        if(!canEat || !targetPlant)
        {
            return;
            
        }
        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);
        targetPlant.Hit(damage);
    }
    private void ResetEatCooldown()
    {
        canEat = true;
    }
    private void FixedUpdate()
    {
        if (!targetPlant)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    public void Hit(int damage, bool freeze)
    {
        source.PlayOneShot(type.clips[Random.Range(0,type.clips.Length)]);
        health -= damage;
        if (freeze)
        {
            Freeze();
        }
        if (health <= 0)
        {
            if(LastZombie)
              GameObject.Find("GameManager").GetComponent<Gamemanager>().Win();
            dead = true;
            GetComponent<SpriteRenderer>().sprite=type.deathSprite;
            Destroy(gameObject);
        }
    }

    void Freeze()
    {
        CancelInvoke("UnFreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        speed=type.speed/2;
        Invoke("UnFreeze", 5);
    }
    void UnFreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        speed=type.speed;
    }
}
