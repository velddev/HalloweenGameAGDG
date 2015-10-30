using UnityEngine;
using System.Collections;

public class PumpkinAI : EnemyBaseAI
{
    bool Exploding = false;
    float FuseTime = 2;

    public ParticleSystem Explosion;

    protected override void Update()
    {
        base.Update();
        if(Exploding)
        {
            FuseTime -= 1 * Time.deltaTime;
            if (FuseTime < 0) { OnDie();  }
        }
    }

    public override void OnAttack()
    {
        Exploding = true;
        a.SetBool("Explode", true);
    }

    public override void OnDie()
    {
        Explosion.gameObject.SetActive(true);
        Explosion.Play();
        Explosion.transform.parent = null;
        Destroy(gameObject);
    }

    public override void OnMove()
    {
        if (!Exploding)
        {
            transform.Translate(Vector2.up * CalculateMovementSpeed(MovementSpeed, 20) * Time.deltaTime);
        }
    }

    float CalculateMovementSpeed(float speed, float max)
    {
        float output = max - Vector3.Distance(CurrentTarget.transform.position, transform.position);
        if (output < speed) return speed;
        else if (output > max) return max;
   //     Debug.Log(output);
        return output;
    }
}
