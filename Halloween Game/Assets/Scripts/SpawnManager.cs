﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour {
   public GameObject item;
    
   public GameObject[] _spawners;
   private Vector3 _spawnPos;
   bool canSpawn;
   private int _spawnDelay, _timeDelay = 10, _lastIncreasedTime;


   void Awake()
   {
       _spawners = GameObject.FindGameObjectsWithTag("Respawn").ToArray();
       _spawnDelay = 5; canSpawn = true;
   }
	// Use this for initialization

	
	// Update is called once per frame
    void Update()
    {
        if (canSpawn) { StartCoroutine(SpawnMob(_spawnDelay)); }
        if (_spawnDelay <= 2) { _spawnDelay = 2; }

        if (Time.time > _timeDelay + _lastIncreasedTime)
        {
            _lastIncreasedTime = (int)Time.time;
            _spawnDelay -= 1;
        }

        
        
      
          
    }

    IEnumerator SpawnMob(int timeBetweenEnemies)
    {
        canSpawn = false;
        _spawnPos = _spawners[Random.Range(0, _spawners.Length)].transform.position;
        Instantiate(item, _spawnPos, transform.rotation);
        yield return new WaitForSeconds(timeBetweenEnemies);
        canSpawn = true;
    }
}
