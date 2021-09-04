using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private bool _stopSpawning = false;



    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotPowerup());
    }


    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-13.65f, -5.43f), 7, 15);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        // after this everlasting loop never execute next line of code

    }

    IEnumerator SpawnTripleShotPowerup()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-13.65f, -5.43f), 7, 20);
            int randomPowerup = Random.Range(0, 3);
            GameObject newPowerup = Instantiate(powerups[randomPowerup], posToSpawn, Quaternion.identity);
            newPowerup.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));
            // every 3-7 seconds spawn powerup
        }
    }

    public void OnPlayerDeath() 
    {
        _stopSpawning = true;
    }
}
