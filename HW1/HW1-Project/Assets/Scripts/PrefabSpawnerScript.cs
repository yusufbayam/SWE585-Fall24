using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawnerScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnObject();
        }
    }

    void SpawnObject() {
        if (objectToSpawn != null && spawnLocation != null) {
            Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
        } else {
            Debug.LogError("Error while spawning object");
        }
    }
}
