using UnityEngine;
using System.Collections;

public class SkeletonAI : EnemyBaseAI {

    float AttackCooldown;
    float mAttackCooldown;

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
    }

    public override void OnMove()
    {
        transform.Translate(Vector2.up * MovementSpeed * Time.deltaTime);
    }

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
    }
}
