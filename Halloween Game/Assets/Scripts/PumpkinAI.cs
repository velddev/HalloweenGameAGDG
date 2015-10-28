using UnityEngine;
using System.Collections;

public class PumpkinAI : EnemyBaseAI
{
    public override void OnAttack()
    {
        
    }

    public override void OnDie()
    {
      
    }

    public override void OnMove()
    {
        transform.Translate(Vector2.up * CalculateMovementSpeed(MovementSpeed, 20) * Time.deltaTime);
    }

    float CalculateMovementSpeed(float speed, float max)
    {
        float output = max - Vector3.Distance(CurrentTarget.transform.position, transform.position);
        if (output < speed) return speed;
        else if (output > max) return max;
        Debug.Log(output);
        return output;
    }
}
