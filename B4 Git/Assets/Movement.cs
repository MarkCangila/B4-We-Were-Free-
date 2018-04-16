using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public Rigidbody rb;
    public int speed;
    public Vector3 v3speed;
    public float totalspeed;
    public float maxspeed;
    public float vertspeed;
	void Start () {
        
}
	float abs (float i)
    {
        if (i <= 0)
        {
            return (-1f * i);
        }
        return i;
    }
	// Update is called once per frame
	void FixedUpdate () {
        v3speed = rb.velocity;
        totalspeed = abs(v3speed.x) + abs(v3speed.z) + abs(v3speed.y);
		if(Input.GetKey("a") && totalspeed <= maxspeed)
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("d") && totalspeed <= maxspeed)
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("s") && totalspeed <= maxspeed)
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        else if (Input.GetKey("w") && totalspeed <= maxspeed)
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("space") && transform.position.y >= 0.9 && transform.position.y <= 1.1)
        {
            rb.AddForce(0, vertspeed, 0, ForceMode.Impulse);
        }
        if (transform.position.y >= 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
        }
  
        float nodownspeed = abs(rb.velocity.x) + abs(rb.velocity.z);
        if (abs(totalspeed) >= maxspeed && v3speed.y >= 0)
        {
            float ratio = maxspeed / abs(totalspeed);
            rb.velocity = new Vector3((v3speed.x) / ratio, (v3speed.y) / ratio, (v3speed.z) / ratio);
        }
        else if (abs(nodownspeed) >= maxspeed)
        {
            float ratio = maxspeed / abs(nodownspeed);
            rb.velocity = new Vector3((v3speed.x) / ratio, v3speed.y, (v3speed.z) / ratio);
        }
    }
}
