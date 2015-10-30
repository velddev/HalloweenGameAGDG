using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _input, _movement;
    float speed = 10f;
    float speedmodifier = 1.5f;
    bool sprinting = false;
    
    public float lerpSpeed = 1f;
    public Slider healthSlider;
    public Slider staminaSlider;

    public WeaponBase currentWeapon;
    public SpriteRenderer currentWeaponSprite;

    public Animator a;

    // Use this for initialization
    void Start()
    {
        a = GetComponent<Animator>();
        ChangeWeapon(currentWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 37)
        {
            transform.position = new Vector3(37, transform.position.y);
        }
        if (transform.position.x < -35)
        {
            transform.position = new Vector3(-35, transform.position.y);
        }
        if (transform.position.y > 35)
        {
            transform.position = new Vector3(transform.position.x, 35);
        }
        if (transform.position.y < -36)
        {
            transform.position = new Vector3(transform.position.x, -36);
        }
        currentWeapon.Cooldown -= 1 * Time.deltaTime;
        if (!sprinting)
        {
            staminaSlider.value += 0.5f * Time.deltaTime;
        }
        else
        {
            if (staminaSlider.value <= 0)
            {
                sprinting = false;
            }
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * getSpeed() * Time.deltaTime;
        //_movement = _input.normalized * speed * Time.deltaTime;
        //transform.Translate(_movement);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion look = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.1f);

        /*       if (Input.GetKeyDown(KeyCode.Space))
               {
                   healthSlider.value -= 0.1f;
               }*/
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                staminaSlider.value -= 1 * Time.deltaTime;
            }
        }
        else { sprinting = false; }
        if (currentWeapon.Cooldown <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentWeapon.PlayLeftClickAnimation(a);
                Instantiate(currentWeapon, transform.position, transform.rotation);
                currentWeapon.ResetCooldown();
            }
            if (Input.GetMouseButtonDown(1))
            {
                currentWeapon.PlayRightClickAnimation(a);
                Instantiate(currentWeapon, transform.position, transform.rotation);
                currentWeapon.ResetCooldown();
            }
        }
    }

    float getSpeed()
    {
        if(sprinting)
        {
            return speed * speedmodifier;
        }
        return speed;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Damage")
        {
            healthSlider.value -= col.collider.GetComponent<EnemyBaseAI>().Damage;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        healthSlider.value -= 0.025f;
    }

    void ChangeWeapon(WeaponBase Weapon)
    {
        currentWeapon = Weapon;
        currentWeaponSprite.sprite = Weapon.GetComponent<WeaponBase>().PlayerSprite;
        a.runtimeAnimatorController = Weapon.GetComponent<WeaponBase>().PlayerAnimator;
    }
}

