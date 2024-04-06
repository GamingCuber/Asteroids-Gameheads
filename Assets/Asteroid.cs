using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Sprite[] Sprites;
    public float Size, minSize, maxSize;
    public float movementSpeed;

    public float maxLifetime;
    private SpriteRenderer asteroidRenderer;
    private Rigidbody2D asteroidBody;

    void Awake()
    {

        asteroidRenderer = GetComponent<SpriteRenderer>();
        asteroidBody = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {

        asteroidRenderer.sprite = Sprites[Random.Range(0, Sprites.Length)];

        Size = Random.Range(minSize, maxSize);

        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * Size;

        asteroidBody.mass = Size;

    }

    public void SetTrajectory(Vector2 direction)
    {

        asteroidBody.AddForce(direction * movementSpeed);

        Destroy(gameObject, maxLifetime);

    }
}
