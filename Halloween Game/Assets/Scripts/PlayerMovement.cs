using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _input, _movement;
    private AudioManager manager;
    float speed = 10f;
    float speedmodifier = 1.5f;
    bool sprinting = false;
    
    public float lerpSpeed = 1f;
    public Slider healthSlider;
    public Slider staminaSlider;

    public SpriteRenderer currentWeaponSprite;
    public WeaponBase currentWeapon;

    public DataContainer data;

    public Animator a;

    // Use this for initialization
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameContainer").GetComponent<DataContainer>();
        a = GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        ChangeWeapon(data.PreferredWeapon);
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * getSpeed() * Time.deltaTime;
        transform.position += input;

        if (input != Vector3.zero && !sprinting) { manager.WalkingSFX(); }

   

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
                manager.SprintingSFX();
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

    void ChangeWeapon(WeaponBase gun)
    {
        currentWeapon = gun;
        currentWeaponSprite.sprite = gun.PlayerSprite;
        a.runtimeAnimatorController = gun.PlayerAnimator;
    }
}

