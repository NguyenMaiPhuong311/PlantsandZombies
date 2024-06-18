using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public GameObject currentPlant;
    private Sprite currentPlantSprite;
    [SerializeField] private Transform tiles;
    [SerializeField] private LayerMask tileMask;
    public int suns;
    [SerializeField] private TMP_Text sunText ;
    [SerializeField] private LayerMask sunMask;
    [SerializeField] private AudioClip clips;
    private AudioSource source;
    [SerializeField] private AudioClip sunclips;
    [SerializeField] private AudioSource sunsource;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        sunsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sunText.text=suns.ToString();
        RaycastHit2D hit=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,tileMask);
      
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        if(hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasPlant)
            {
                Plant(hit.collider.gameObject);
            }
        }
        RaycastHit2D sunhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);
        if (sunhit.collider )
        {
            if (Input.GetMouseButton(0))
            {
                sunsource.pitch = Random.Range(.9f,1.1f);
                sunsource.PlayOneShot(sunclips);
                suns += 25;
                Destroy(sunhit.collider.gameObject);
            }
        }
    }

    public void BuyPlant (GameObject plant,Sprite sprite)
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }

    void Plant(GameObject hit)
    {
        source.PlayOneShot(clips);
        
        GameObject plant= Instantiate(currentPlant, hit.transform.position, Quaternion.identity);
        hit.GetComponent<Tile>().hasPlant = true;
        plant.GetComponent<Plant>().tile=hit.GetComponent<Tile>();
        currentPlant = null;
        currentPlantSprite = null;
    }
    public void Win()
    {
        
        if(SceneManager.GetActiveScene().buildIndex + 1> SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        PlayerPrefs.SetInt("levelSave", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
