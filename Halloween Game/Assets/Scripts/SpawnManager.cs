using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour {  
   //public float spawnChance;

   private GameObject[] _spawners;
   private Vector3 _spawnPos;
   
    [SerializeField]
    private GameObject _healthPacks;

    [SerializeField]
    private GameObject[] Enemies;

   
   private bool _canSpawn, _canSpawnHealth;
   private float _spawnDelay, _timeDelay, _lastIncreasedTime;

   void Awake()
   {
       _spawners = GameObject.FindGameObjectsWithTag("Respawn").ToArray();
       _spawnDelay = 3.5f; _canSpawn = true;
       StartCoroutine(SpawnHealth());
       GameObject.Destroy(GameObject.FindGameObjectWithTag("Health"));
   }

   void Update()
   {
       if (_canSpawn) { StartCoroutine(SpawnMob(_spawnDelay)); }
       if (_canSpawnHealth) { StartCoroutine(SpawnHealth()); }

       if (_spawnDelay <= 1) { _spawnDelay = 1f; }
       _lastIncreasedTime = (int)Time.time;
       _spawnDelay -= 0.001f * Time.deltaTime;
   }

    IEnumerator SpawnMob(float timeBetweenEnemies)
    {
        _canSpawn = false;
        _spawnPos = _spawners[Random.Range(0, _spawners.Length)].transform.position;
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], _spawnPos, transform.rotation);
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], _spawnPos, transform.rotation);
        yield return new WaitForSeconds(timeBetweenEnemies);
        _canSpawn = true;
    }

    IEnumerator SpawnHealth()
    {
        _canSpawnHealth = false;
        _spawnPos = _spawners[Random.Range(0, _spawners.Length)].transform.position;
        Instantiate(_healthPacks, _spawnPos, transform.rotation);
        yield return new WaitForSeconds(60);
        _canSpawnHealth = true;
    }
}
