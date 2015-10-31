using UnityEngine;
using System.Collections;

public class SkeletonAI : EnemyBaseAI {

    public float AttackCooldown;
    float mAttackCooldown;

    public override void Start()
    {
        base.Start();
        mAttackCooldown = AttackCooldown;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void OnAttack()
    {
        base.OnAttack();
        AttackCooldown -= 1 * Time.deltaTime;
        if(AttackCooldown <= 0)
        {
            AttackCooldown = mAttackCooldown;
            a.SetTrigger("PunchLeft");
            CurrentTarget.GetComponent<PlayerMovement>().healthSlider.value -= Damage;
        }
    }

    public override void OnDie()
    {
        base.OnDie();
        Destroy(gameObject);
    }

    public override void OnMove()
    {
        transform.Translate(Vector2.up * MovementSpeed * Time.deltaTime);
    }

    public override void OnHurt()
    {
        GetComponent<AudioSource>().PlayOneShot(HurtSFX);
    }

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
    }
}
