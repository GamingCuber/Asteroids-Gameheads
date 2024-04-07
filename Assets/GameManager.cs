using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public float respawnTime = 1.5f;
    public RocketMoveScript Rocket;


    public void OnPlayerDeath()
    {

        lives--;

        if (lives <= 0)
        {

            GameOver();

        }
        else
        {

            Invoke(nameof(PlayerRespawn), respawnTime);

        }


    }

    public void PlayerRespawn()
    {

        Rocket.transform.position = new Vector3(0, 5, 0);
        Rocket.gameObject.SetActive(true);
        GiveInvincibility();
        Invoke(nameof(RemoveInvincibility), 3.0f);

    }

    private void GiveInvincibility()
    {

        Rocket.gameObject.layer = LayerMask.NameToLayer("Invincibility");


    }

    private void RemoveInvincibility()
    {

        Rocket.gameObject.layer = LayerMask.NameToLayer("Player");

    }

    public void GameOver()
    {

        // TODO

    }
}
