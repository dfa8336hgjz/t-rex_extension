using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Pipe prefab;
    public float spawnrate = 1f;
    public float minheight = -1f;
    public float maxheight = 2f;
    public List<GameObject> spawnedPipes = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void Spawn()
    {
        Pipe newpipe = Instantiate(prefab, transform.position, Quaternion.identity);
        newpipe.transform.position += Vector3.up * Random.Range(minheight, maxheight);
        spawnedPipes.Add(newpipe.gameObject);
    }
}
