using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    public static SpawnBot Instance;

    public GameObject Bot1Spawn;

    public GameObject Bot2Spawn;

    public GameObject SpawnPos1;

    public GameObject SpawnPos2;

    public float spawnRate = 2;

    public float timeSpawn = 0;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

    }


    void Update()
    {
        InvokeRepeating("bot1Spawn", timeSpawn, spawnRate);

        InvokeRepeating("bot2Spawn", timeSpawn, spawnRate);

        if (Bot1Ctrl.Instance.isDie == false)
        {
            CancelInvoke("bot1Spawn");
        }

        if(Bot2Ctrl.Instance.isDie == false)
        {
            CancelInvoke("bot2Spawn");
        }
    }

    
    public void bot1Spawn()
    {
        if (Bot1Ctrl.Instance.isDie == true)
        {
            Instantiate(Bot1Spawn, SpawnPos1.transform.position, SpawnPos1.transform.rotation);
        }
    }

    public void bot2Spawn()
    {
        if (Bot2Ctrl.Instance.isDie == true)
        {
            Instantiate(Bot2Spawn, SpawnPos2.transform.position, SpawnPos2.transform.rotation);
        }
    }
}
