using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public GameManager gameManager;

    public float spawnInterval = 2f;
    public float minX = -2f;
    public float maxX = 2f;
    public float spawnY = 8f;
    public float spawnZ = 0f;

    private float timer = 0f;

    void Update()
    {
        if (gameManager != null && gameManager.IsGameOver())
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomItem();
            timer = 0f;
        }
    }

    void SpawnRandomItem()
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject selectedPrefab = itemPrefabs[randomIndex];

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, spawnZ);

        Instantiate(selectedPrefab, spawnPosition, selectedPrefab.transform.rotation);
    }
}