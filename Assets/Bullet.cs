using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletBody;
    public float speed = 5.0f;
    public float bulletLifeTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
    }

    public void sendDirection(Vector2 direction)
    {

        bulletBody.AddForce(direction * speed);

        Destroy(gameObject, bulletLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

        }

    }

}
