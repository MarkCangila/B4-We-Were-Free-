using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(rb.position.x, rb.position.y + 1, (float)(rb.position.z + 0.1));
	}
    float abs(float i)
    {
        if (i <= 0)
        {
            return (-1f * i);
        }
        return i;
    }
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(rb.position.x, rb.position.y + 1, (float)(rb.position.z + 0.1));
        float totalspeed = abs(rb.velocity.x) + abs(rb.velocity.y) + abs(rb.velocity.z);
        float downno = abs(rb.velocity.x) + abs(rb.velocity.z);
        Vector3 rfq = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (abs(downno) >= 0.2)
        {
            transform.rotation = Quaternion.LookRotation(rfq);
        }
    }
}
