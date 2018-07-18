using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 10;
    public float gravity = 2;
    public float maxVelocityChange = 10;
    private bool grounded;
    public int Points = 0;

    public string Name; // the name of the player
    public int Attack; // the integer of the attack
    public float AttackSpeed; // a decimel or an integer on how fast we attack
    public int health; // true or false
    private bool dead; // integer of the health 
    private Transform PlayerTransform;
    private GameObject Enemy;
    private Rigidbody _rigidbody;
    public float JumpHeight = 1;


	// Use this for initialization
	void Start () {
        PlayerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        PlayerTransform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);

        Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));
        targetVelocity = PlayerTransform.TransformDirection(targetVelocity);
        targetVelocity = targetVelocity*speed;
        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocitychange = targetVelocity - velocity;
        velocitychange.x = Mathf.Clamp(velocitychange.x, -maxVelocityChange, maxVelocityChange);
        velocitychange.z = Mathf.Clamp(velocitychange.z, -maxVelocityChange, maxVelocityChange);
        velocitychange.y = 0;
        _rigidbody.AddForce(velocitychange, ForceMode.VelocityChange);
       if(Input.GetButton("Jump")&& grounded == true)
        {
            _rigidbody.velocity = new Vector3(velocity.x, CalculateJump(), velocity.z);

        }
        grounded = false;
        _rigidbody.AddForce(new Vector3(0, -gravity * _rigidbody.mass, 0));

    }
    float CalculateJump()
    {
        float Jump = Mathf.Sqrt(2 * JumpHeight * gravity);
        return Jump;
    }
    void OnCollisionStay()
    {
        grounded = true;

    }
    void OnTriggerEnter(Collider Buddy)
    {
        if (Buddy .tag == "Coin")
        {
            Points = Points + 5;
            Destroy(Buddy.gameObject);
        }
    }
void update()
    {
        if(health < 1)
        {
            SceneManager.LoadScene("test1");
        }
    }


}

