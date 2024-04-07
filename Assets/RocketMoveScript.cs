using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RocketMoveScript : MonoBehaviour
{
    private bool isThrustingForward;
    private bool isThrustingBackwards;
    private float direction;
    public Bullet BulletPreFab;
    public float moveSpeed = 5.0f;
    public float turnSpeed = 1.0f;
    public Rigidbody2D rocketBody;

    void Start()
    {

        rocketBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

        isThrustingForward = Input.GetKey(KeyCode.W);
        isThrustingBackwards = Input.GetKey(KeyCode.S);

        if (Input.GetKey(KeyCode.A))
        {

            direction = 1.0f;

        }
        else if (Input.GetKey(KeyCode.D))
        {

            direction = -1.0f;

        }
        else
        {

            direction = 0f;

        }

        if (Input.GetMouseButtonDown(0) == true)
        {

            Shoot();

        }

    }

    void FixedUpdate()
    {

        if (isThrustingForward)
        {

            rocketBody.AddForce(transform.up * moveSpeed);

        }

        if (isThrustingBackwards)
        {

            rocketBody.AddForce(-transform.up * moveSpeed);

        }

        if (direction != 0)
        {

            rocketBody.AddTorque(direction * turnSpeed);

        }
    }

    void Shoot()
    {

        Bullet shotBullet = Instantiate(BulletPreFab, transform.position, transform.rotation);
        shotBullet.sendDirection(transform.up);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        string collisionTag = collision.gameObject.tag;
        if (collisionTag == "Asteroid")
        {

            rocketBody.velocity = Vector3.zero;
            rocketBody.angularVelocity = 0.0f;

            gameObject.SetActive(false);

            FindObjectOfType<GameManager>().OnPlayerDeath();

        }

    }
}
