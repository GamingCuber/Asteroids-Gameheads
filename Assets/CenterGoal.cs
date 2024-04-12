using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGoal : MonoBehaviour
{
    public int health = 8;
    public Rigidbody2D goalBody;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        goalBody = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        if (health <= 0)
        {

            gameManager.GameOver();

        }

    }

}
