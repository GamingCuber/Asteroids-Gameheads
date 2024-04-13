using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float respawnTime = 1.5f;
    public RocketMoveScript Rocket;
    public AsteroidSpawner spawner;
    public CenterGoal centerGoal;
    public GameObject UI;


    public void OnPlayerDeath()
    {


        Invoke(nameof(PlayerRespawn), respawnTime);


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

        Rocket.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);


    }

    public void RestartGame()
    {

        Rocket.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        centerGoal.health = 8;


    }

}
