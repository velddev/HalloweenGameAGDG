using UnityEngine;
using System.Collections;

public class WeaponGlock : WeaponBase {

    public override void OnMove()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    public override void OnDie()
    {
        base.OnDie();
    }
}
