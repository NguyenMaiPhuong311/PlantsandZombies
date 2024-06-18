using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;

    [SerializeField] private GameObject zombie;
    [SerializeField] private ZombieTypeProb[] zombieTypes;
    private List<ZombieType> proList = new List<ZombieType>();

    [SerializeField] private int zombieMax;
     private int zombieSpawned;
    [SerializeField] private Slider progessBar;
    [SerializeField] private float zombieDelay=5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZombie", 15, zombieDelay);
        foreach(ZombieTypeProb zom in zombieTypes)
        {
            for(int i = 0; i < zom.probability; i++)
            {
                proList.Add(zom.type);
            }
        }
        progessBar.maxValue = zombieMax;
    }

    // Update is called once per frame
    void Update()
    {
        progessBar.value = zombieSpawned;
    }
    void SpawnZombie()
    {
        if (zombieSpawned >= zombieMax)
            return;
        zombieSpawned++;

        int r=Random.Range(0,spawnpoints.Length);
        GameObject myZombie= Instantiate(zombie, spawnpoints[r].position,Quaternion.identity);

        myZombie.GetComponent<Zombie>().type = proList[Random.Range(0,proList.Count)];
        if (zombieSpawned >= zombieMax)
        {
            myZombie.GetComponent<Zombie>().LastZombie = true;
        }


    }
    [System.Serializable]
    public class ZombieTypeProb
    {
        public ZombieType type;
        public int probability;
    }
}
