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

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!sprinting) 
        {
            staminaSlider.value += 0.5f * Time.deltaTime;
        }
        else
        {
            if(staminaSlider.value <= 0)
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

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    healthSlider.value -= 0.1f;
        //}
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                staminaSlider.value -= 1 * Time.deltaTime;
            }
        }
        else{ sprinting = false;}
    }

    float getSpeed()
    {
        if(sprinting)
        {
            return speed * speedmodifier;
        }
        return speed;
    }
}

