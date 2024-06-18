using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private int health;
    public Tile tile;

    void Start()
    {
        gameObject.layer = 9;
    }

    public void Hit(int damage)
    {
       
        if (gameObject.tag == "A")
        {
            health -= damage;
            if (health <= 0)
            {
                tile.hasPlant = false;
                Destroy(gameObject, 20f);
            }
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                tile.hasPlant = false;
                Destroy(gameObject, 5f);
            }
        }
    }
}
