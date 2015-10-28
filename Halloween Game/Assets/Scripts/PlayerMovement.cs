using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Vector2 _input, _movement;
    float speed = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movement = _input.normalized * speed * Time.deltaTime;
        transform.Translate(_movement);
    
       Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       transform.rotation = Quaternion.LookRotation(Vector3.forward,mousePos -transform.position);
        }
    }

