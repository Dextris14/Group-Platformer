using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 3.0f;
    bool grounded = false;

	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("Grounded", grounded);
        float moveX = Input.GetAxis("Horizontal");
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
           
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = false;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "speedup")
        {
            moveSpeed+= 0.5f;
            Destroy(collision.gameObject);

        }else if (collision.gameObject.tag == "jumpup")
        {
            jumpSpeed+= 0.5f;
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "Tar")
        {
            moveSpeed -= 0.5f;
            Destroy(collision.gameObject);

        }
    }
    
    
        
    
}
