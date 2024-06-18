using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bas : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float cooldown;
    private bool canShoot;
    [SerializeField] private float range;
    [SerializeField] private LayerMask shootMask;
    private GameObject target;
    private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ResetCooldown", cooldown);
        source = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit=Physics2D.Raycast(transform.position, Vector2.right,range,shootMask);

        if (hit.collider)
        {
            target=hit.collider.gameObject;
            Shoot();
        }
    }
    void ResetCooldown()
    {
        canShoot = true;
    }
    void Shoot()
    {
        if (!canShoot)
            return;

        source.PlayOneShot(clips[Random.Range(0,clips.Length)]);
        canShoot = false;
        Invoke("ResetCooldown", cooldown);
        GameObject myBullet= Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    }

    
}
