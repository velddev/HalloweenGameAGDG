using UnityEngine;
using System.Collections;

public class SlimeAI : EnemyBaseAI {

    public GameObject[] OnDeathSpawn;

    public float AttackCooldown;
    float mAttackCooldown;

    bool _spawned = false;
    bool _playedSound = false;

    public override void Start()
    {
        base.Start();
        mAttackCooldown = AttackCooldown;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void OnMove()
    {
        transform.Translate(Vector2.up * MovementSpeed * Time.deltaTime);
    }

    public override void OnHurt()
    {
        base.OnHurt();
        audioSource.PlayOneShot(HurtSFX);
    }

    public override void OnDie()
    {
        base.OnDie();
        if (!_spawned)
        {
            for (int i = 0; i < OnDeathSpawn.Length; i++)
            {
                GameObject g = (GameObject)Instantiate(OnDeathSpawn[i], new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1), Random.Range(transform.position.y - 1, transform.position.y + 1)), Quaternion.identity);
            }
            _spawned = true;
        }
       StartCoroutine(DeathSound());
    }

    IEnumerator DeathSound()
    {
        if (!_playedSound)
        {
            audioSource.PlayOneShot(HurtSFX);
            _playedSound = true;
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public override void OnAttack()
    {
        base.OnAttack();
        AttackCooldown -= 1 * Time.deltaTime;
        if (AttackCooldown <= 0)
        {
            AttackCooldown = mAttackCooldown;
            CurrentTarget.GetComponent<PlayerMovement>().healthSlider.value -= Damage;
        }
    }

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
    }
}
