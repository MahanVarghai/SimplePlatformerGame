using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            enemy = Instantiate(enemyList[Random.Range(0, enemyList.Count)]);
            enemy.transform.position = transform.position;
        }
    }
}
