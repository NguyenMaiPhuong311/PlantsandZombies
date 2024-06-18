using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] private Animator ani;
    private bool hasLost;
    
    [SerializeField] private AudioClip loseclips;
    [SerializeField] private AudioSource music;
    private AudioSource source;
    [SerializeField] private AudioClip scream;
    // Start is called before the first frame update
    void Start()
    {
        
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer==7)
        {
            if (hasLost || other.GetComponent<Zombie>().dead)
                return;
            hasLost = true;

            source.PlayOneShot(loseclips);
            source.PlayOneShot(scream);
            music.Stop();

            ani.Play("DeathAni");
            Invoke("RestartScene", 2.5f);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
