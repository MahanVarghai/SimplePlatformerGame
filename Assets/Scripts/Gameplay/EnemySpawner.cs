using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();
    private List<Transform> spawnerList = new List<Transform>();
    private GameObject enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        foreach (Transform t in GetComponentInChildren<Transform>())
            spawnerList.Add(t);
        
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            enemy = Instantiate(enemyList[Random.Range(0, enemyList.Count)]);
            enemy.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
        }
    }
}
