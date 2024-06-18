using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New ZombieType", menuName ="Zombie")]
public class ZombieType : ScriptableObject
{
   public int health;
    public float speed;
    public int damage;
    public float range= .5f;
    [SerializeField] private float eatCooldown=1f;
    public Sprite sprite;
    public Sprite deathSprite;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
