using UnityEngine;
using System.Collections;

public class PlayerPreviewer : PlayerMovement {

    public void ChangeWeapon(WeaponBase gun)
    {
        currentWeapon = gun;
        currentWeaponSprite.sprite = gun.PlayerSprite;
        a.runtimeAnimatorController = gun.PlayerAnimator;
    }
}
