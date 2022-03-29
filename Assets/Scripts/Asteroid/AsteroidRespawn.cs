using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRespawn : MonoBehaviour
{
    public float timeSpawn;
    public GameObject[] prefabs;
    public Transform[] spawner;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(
                prefabs[Random.Range(0, prefabs.Length)],
                spawner[Random.Range(0, spawner.Length)].position,
                Quaternion.identity
                );
            yield return new WaitForSeconds(timeSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
