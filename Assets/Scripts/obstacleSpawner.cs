using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacle;
    [SerializeField] private float spawnTime;
    // Start is called before the first frame update
    private bool startInvoking = false;

    private void Update()
    {
        if(MegalodonGameManager.Instance.IsGameStart() && !startInvoking) {
            InvokeRepeating(nameof(spawn), 0.0f, spawnTime);
            startInvoking = true;
        }
    }

    private void spawn()
    {
        int i = Random.Range(0, obstacle.Length * 10);
        GameObject o = Instantiate(obstacle[i%obstacle.Length], transform.position, Quaternion.identity);
        o.transform.position = transform.position;
    }
}
