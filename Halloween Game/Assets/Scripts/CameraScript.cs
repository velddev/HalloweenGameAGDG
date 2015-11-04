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
            Vector3 targetPosition = CalculateMiddlePoint(GameController.Players.ToArray());
            Debug.Log(targetPosition);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dampTime);
        }
    }

    Vector3 CalculateMiddlePoint(GameObject[] points)
    {
        Vector3 output = Vector3.zero;
        for(int i = 0; i < points.Length; i++)
        {
            output += points[i].transform.position;
        }
        return new Vector3(output.x / points.Length, output.y / points.Length, -10);
    }
}