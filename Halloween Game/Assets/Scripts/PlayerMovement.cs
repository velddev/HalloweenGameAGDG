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

    public int currentWeaponID;
    public WeaponBase[] allweapons;

    public Animator a;
    public GameObject DeathScreen;
    public Text stats;
    public int KillsMade;
    public bool CanMove;

    // Use this for initialization
    void Start()
    {
        a = GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value <= 0)
        {
            DeathScreen.SetActive(true);
            stats.text = "Time survived: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().CalculateTime() + "\nKills: " + KillsMade;
            PlayerPrefs.SetFloat("TopScore", GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SecondsSurvived);
            Time.timeScale = 0;
        }
        if (transform.position.x < -37)
        {
            transform.position = new Vector3(-37, transform.position.y);
        }
        if (transform.position.x > 35)
        {
            transform.position = new Vector3(35, transform.position.y);
        }
        if (transform.position.y < -35)
        {
            transform.position = new Vector3(transform.position.x, -35);
        }
        if (transform.position.y > 35)
        {
            transform.position = new Vector3(transform.position.x, 35);
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
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * getSpeed() * Time.deltaTime;
        transform.position += input;

        if (input != Vector3.zero && !sprinting) { manager.WalkingSFX(); }


        //_movement = _input.normalized * speed * Time.deltaTime;
        //transform.Translate(_movement);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion look = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.1f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            manager.SprintingSFX();
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                staminaSlider.value -= 1 * Time.deltaTime;
            }
        }
        else
        {
            sprinting = false;
        }
        if (currentWeapon.Cooldown <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentWeapon.PlayLeftClickAnimation(a);
                Instantiate(currentWeapon, transform.position, transform.rotation);
                currentWeapon.ResetCooldown();
                GetComponent<AudioSource>().PlayOneShot(currentWeapon.WeaponSFX, 0.5f);
            }
            if (Input.GetMouseButtonDown(1))
            {
                currentWeapon.PlayRightClickAnimation(a);
                Instantiate(currentWeapon, transform.position, transform.rotation);
                currentWeapon.ResetCooldown();
                GetComponent<AudioSource>().PlayOneShot(currentWeapon.WeaponSFX, 0.5f);
            }
        }
        if(Input.mouseScrollDelta.y > 0)
        {
            currentWeaponID++;
            if(currentWeaponID >= allweapons.Length)
            {
                currentWeaponID = 0;
            }
            ChangeWeapon(allweapons[currentWeaponID]);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            currentWeaponID--;
            if (currentWeaponID <= 0)
            {
                currentWeaponID = allweapons.Length;
            }
            ChangeWeapon(allweapons[currentWeaponID]);
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
        if(col.collider.tag == "Health")
        {
            healthSlider.value += 0.25f;
            Destroy(col.gameObject);
        }
    }

    void OnParticleCollision(GameObject other) {
        healthSlider.value -= 0.025f;

        }

    public void ChangeWeapon(WeaponBase gun)
    {
        currentWeapon = gun;
        currentWeaponSprite.sprite = gun.PlayerSprite;
        a.runtimeAnimatorController = gun.PlayerAnimator;
    }
}

