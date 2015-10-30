using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {

    public float Lifetime;
    public float Speed;
    public float Damage;

    void Update()
    {
        Lifetime -= 1 * Time.deltaTime;
        OnMove();
        if(Lifetime <= 0)
        {
            OnDie();
        }
    }

    public virtual void OnMove()
    {
        // movement code
    }

    public virtual void OnDie()
    {
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            GetComponent<EnemyBaseAI>().Health -= Damage;
        }
        OnDie();
    }
}
