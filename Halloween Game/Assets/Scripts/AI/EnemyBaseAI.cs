using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class EnemyBaseAI : MonoBehaviour {

    public float MovementSpeed = 5;
    public float Health = 100;
    public float RotationSpeed = 0.33f;
    public float Damage = 0.1f;

    protected GameObject[] Targets;
    protected GameObject CurrentTarget;

    protected Animator animator;
    protected AudioSource audioSource;

    public AudioClip HurtSFX;
    public AudioClip DieSFX;

    bool isAlive = true;

	public virtual void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Targets = GameObject.FindGameObjectsWithTag("Player");
        CurrentTarget = GetClosestTarget();
	}
	
    protected virtual void Update()
    {
        if (isAlive)
        {
            Quaternion look = Quaternion.LookRotation(Vector3.forward, CurrentTarget.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, RotationSpeed);
            if (Vector3.Distance(transform.position, CurrentTarget.transform.position) > 1.25f)
            {
                OnMove();
            }
            else
            {
                OnAttack();
            }
            if (Health < 0)
            {
                isAlive = false;
                OnDie();
            }
        }
    }

    public virtual void OnAttack() { }

    public virtual void OnHurt() { }

    public virtual void OnDie() { CurrentTarget.GetComponent<PlayerMovement>().KillsMade++; }

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

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Bullet")
        {
            OnHurt();
            Health -= col.collider.GetComponent<WeaponBase>().Damage;
            GetComponent<Rigidbody>().AddForceAtPosition(Vector3.one * col.collider.GetComponent<WeaponBase>().Knockback, col.transform.position);
            Destroy(col.collider.gameObject);
        }
    }
}
