using UnityEngine;
using System.Collections;

public class PlayerPreviewer : PlayerMovement {

    void Start()
    {

    }

	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion look = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.1f);
	}

    public void ChangeWeapon(WeaponBase gun)
    {
        currentWeapon = gun;
        currentWeaponSprite.sprite = gun.PlayerSprite;
        a.runtimeAnimatorController = gun.PlayerAnimator;
    }
}
