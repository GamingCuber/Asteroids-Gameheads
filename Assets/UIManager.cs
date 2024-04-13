using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject ScoreText;
    public GameObject GameOverText;
    public GameManager gameManager;
    public CenterGoal center;
    void FixedUpdate()
    {

        int health = center.health;
        ScoreText.GetComponent<Text>().text = "Score: " + health;

        if (health <= 0)
        {

            GameOverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {

                GameOverText.SetActive(false);
                gameManager.RestartGame();

            }

        }

    }
}
