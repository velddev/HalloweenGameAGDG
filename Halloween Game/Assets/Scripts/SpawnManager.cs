using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnManager : MonoBehaviour {
   public GameObject item;
    
   public GameObject[] _spawners;
   private Vector3 _spawnPos;
   

	// Use this for initialization
	void Start () {
        _spawners  = GameObject.FindGameObjectsWithTag("Respawn").ToArray();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spawnPos = _spawners[Random.Range(0, _spawners.Length)].transform.position;
            Instantiate(item, _spawnPos, transform.rotation);
        }
        }
	
}
