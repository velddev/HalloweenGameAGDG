using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] _spawners;

    [SerializeField]
    private GameObject _healthPacks;

    [SerializeField]
    private GameObject[] Enemies;

    public int WaveNumber;
    public int MonstersToSpawn;
    public int MonstersSpawnPerDelay;

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
        if (MonstersToSpawn <= 0)
        {
            if (_canSpawn) { StartCoroutine(SpawnMob(_spawnDelay)); }
            if (_canSpawnHealth) { StartCoroutine(SpawnHealth()); }

            if (_spawnDelay <= 1) { _spawnDelay = 1f; }
            _lastIncreasedTime = (int)Time.time;
            _spawnDelay -= 0.001f * Time.deltaTime;
        }
        else
        {
            if (!IsInvoking("NextWave"))
            {
                Invoke("NextWave", 1);
            }
        }
    }

    IEnumerator SpawnMob(float timeBetweenEnemies)
    {
        _canSpawn = false;
        for (int i = 0; i < MonstersSpawnPerDelay; i++)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], _spawners[Random.Range(0, _spawners.Length)].transform.position, transform.rotation);
        }
        MonstersToSpawn -= MonstersSpawnPerDelay;
        yield return new WaitForSeconds(timeBetweenEnemies);
        _canSpawn = true;
    }

    IEnumerator SpawnHealth()
    {
        _canSpawnHealth = false;
        Instantiate(_healthPacks, _spawners[Random.Range(0, _spawners.Length)].transform.position, transform.rotation);
        yield return new WaitForSeconds(60);
        _canSpawnHealth = true;
    }

    void NextWave()
    {
        WaveNumber++;
        MonstersToSpawn = 10 * WaveNumber;
        MonstersSpawnPerDelay = (int)Mathf.Round(1 * WaveNumber / 10);
    }
}
