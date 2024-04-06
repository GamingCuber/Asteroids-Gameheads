using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public float trajectoryVariance = 15.0f;
    public Asteroid asteroidPreFab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spawnAsteroid), spawnRate, spawnRate);
    }
    void spawnAsteroid()
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPoint = transform.position + spawnDirection * spawnDistance;

        float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

        Asteroid spawnedAsteroid = Instantiate(asteroidPreFab, spawnPoint, rotation);
        spawnedAsteroid.Size = Random.Range(asteroidPreFab.minSize, asteroidPreFab.maxSize);

        Vector2 trajectory = rotation * -spawnDirection;
        spawnedAsteroid.SetTrajectory(trajectory);

    }
}
