using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] Collider2D spawnableArea;
    [SerializeField] GameObject powerupPrefab;

    float minTimeToSpawn = 8f;
    float maxTimeToSpawn = 16f;
    float nextSpawnTime;
    float curTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateNewSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime > nextSpawnTime)
        {
            Debug.Log("spawning");
            spawnPowerup();
            curTime = 0f;
            generateNewSpawnTime();
        }
    }

    void generateNewSpawnTime()
    {
        
        nextSpawnTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        Debug.Log("Next spawn in " + nextSpawnTime + "s");
    }

    void spawnPowerup()
    {
        Vector2 spawnPos = Vector2.zero;
        bool isSpawnValid = false;

        int attempts = 0;
        int maxAttemps = 50;
        while (attempts < maxAttemps && isSpawnValid == false)
        {
            attempts++;
            spawnPos.x = Random.Range(spawnableArea.bounds.min.x, spawnableArea.bounds.max.x);
            spawnPos.y = Random.Range(spawnableArea.bounds.min.y, spawnableArea.bounds.max.y);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos, 1f);

            bool isCollidingWithWall = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.layer == LayerMask.NameToLayer("Walls"))
                {
                    isCollidingWithWall = true;
                    break; // stop checking anything else since we know its invalid already
                }
            }

            //if all collider checks come back not colliding with wall
            if (!isCollidingWithWall)
            {
                isSpawnValid = true;
            }
        }

        Instantiate(powerupPrefab, spawnPos, Quaternion.identity);
    }
}
