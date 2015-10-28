using UnityEngine;
using System.Collections;

public class EnemyBaseAI : MonoBehaviour {

    public float MovementSpeed = 5;
    public float Health = 100;

    GameObject[] Targets;
    GameObject CurrentTarget;

	void Start () {
        CurrentTarget = GetClosestTarget();
	}
	
    void Update()
    {
        Quaternion look = Quaternion.LookRotation(Vector3.forward, CurrentTarget.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.1f);
        if (Vector3.Distance(transform.position, CurrentTarget.transform.position) < 1.25f)
        {
            OnMove();
        }
        else
        {
            OnAttack();
        }
        if(Health < 0)
        {
            OnDie();
        }
    }

    public virtual void OnAttack() { }

    public virtual void OnDie() { }

    public virtual void OnMove() { }

    GameObject GetClosestTarget()
    {
        float lowestDistance = 9999999;
        int id = 0;
        for(int i = 0; i < Targets.Length; i++)
        {
            if(Vector3.Distance(transform.position, Targets[i].transform.position) < lowestDistance)
            {
                id = i;
            }
        }
        return Targets[id];
    }
}
