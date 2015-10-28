using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Vector2 _input, _movement;
    float speed = 5f;
    public float lerpSpeed = 0.2f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
        //_movement = _input.normalized * speed * Time.deltaTime;
        //transform.Translate(_movement);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion look = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.1f);
        }
    }

