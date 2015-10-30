using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour {

    public float Delay;

    void Update()
    {
        if (transform.parent == null)
        {
            Delay -= 1 * Time.deltaTime;
            if (Delay <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
