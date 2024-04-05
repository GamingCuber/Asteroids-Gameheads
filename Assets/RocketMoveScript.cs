using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RocketMoveScript : MonoBehaviour
{
    private bool isThrusting;
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

        isThrusting = Input.GetKey(KeyCode.W);

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

        if (isThrusting)
        {

            rocketBody.AddForce(transform.up * moveSpeed);

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
}
