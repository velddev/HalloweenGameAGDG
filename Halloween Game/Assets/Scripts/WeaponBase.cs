using UnityEngine;
using System.Collections;

public class WeaponBase : MonoBehaviour {

    public Sprite PlayerSprite;
    public RuntimeAnimatorController PlayerAnimator;

    public float Lifetime;
    public float Speed;
    public float Damage;
    public float Knockback;
    public float Cooldown;
    float maxCooldown;

    void Start()
    {
        maxCooldown = Cooldown;
    }

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

    public virtual void PlayLeftClickAnimation(Animator a)
    {

    }

    public virtual void PlayRightClickAnimation(Animator a)
    {

    }

    public virtual void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            GetComponent<EnemyBaseAI>().Health -= Damage;
        }
        OnDie();
    }

    public void ResetCooldown()
    {
        Cooldown = maxCooldown;
    }
}
