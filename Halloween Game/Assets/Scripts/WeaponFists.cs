using UnityEngine;
using System.Collections;

public class WeaponFists : WeaponBase {

    public override void OnMove()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    public override void OnDie()
    {
        base.OnDie();
    }
}
