using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D body;
        [SerializeField] private float speed;
        private Animator anim;
        private bool grounded;
        private Health health;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            //vänder gubben
            if (horizontalInput > 0.01f)
                transform.localScale = Vector2.one;
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector2(-1, 1);

            if (Input.GetKey(KeyCode.Space) && grounded)
                Jump();

            //Animation parameters
            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);

            if (body.position.y < -10)
            {
                health.PlayerDeath();
            }
        }

        private void Jump()
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            grounded = false;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
                grounded = true;
            else
            {
                grounded = false;
            }
        }
    }
}
