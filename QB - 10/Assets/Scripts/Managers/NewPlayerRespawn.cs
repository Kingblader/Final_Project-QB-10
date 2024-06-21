using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerRespawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnpoints;
    [SerializeField] private GameObject selectedSpawnpoint;
    private Transform transformSpawnpoint;
    public GameObject playerPrefab;
    private GameObject newPlayer;



    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 8);
        selectedSpawnpoint = spawnpoints[rand];
            
        transformSpawnpoint = selectedSpawnpoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= 2f)
        {
            Respawn();
            int rand = Random.Range(0, 8);
            selectedSpawnpoint = spawnpoints[rand];
        }
    }

    public void Respawn()
    {
        Destroy(gameObject);
        newPlayer = Instantiate(playerPrefab, transformSpawnpoint.position, transformSpawnpoint.rotation);
    }
}
