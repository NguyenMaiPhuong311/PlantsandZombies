using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantSlot : MonoBehaviour
{
    [SerializeField] private Sprite planSprite;
    [SerializeField] private GameObject plantObject;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private int price;

    private Gamemanager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyPlant);
        gameManager=GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }


    // Update is called once per frame
    void Update()
    {
        priceText=GetComponent<TMP_Text>();
    }
    private void OnValidate()
    {
        if (planSprite)
        {
            icon.enabled = true;
            icon.sprite = planSprite;
            priceText.text = price.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }
    private void BuyPlant()
    {
        if (gameManager.suns >= price && !gameManager.currentPlant)
        {
            gameManager.suns -= price;
            gameManager.BuyPlant(plantObject, planSprite);
        }
    }
}
