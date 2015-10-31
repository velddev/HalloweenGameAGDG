using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    Vector3 mouse = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
           // Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1f)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            mouse = Camera.main.ViewportToWorldPoint(Input.mousePosition);
            mouse = new Vector3(mouse.x - 12500, mouse.y- 5000);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3((target.position.x + (mouse.x * 0.001f)), (target.position.y + (mouse.y * 0.001f)), -10), ref velocity, dampTime);
            Debug.Log(mouse);
        }
    }
}