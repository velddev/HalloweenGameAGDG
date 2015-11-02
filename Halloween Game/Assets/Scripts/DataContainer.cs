using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(gameObject);	
	}
}
