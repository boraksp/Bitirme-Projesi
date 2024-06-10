using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject[] ingredientPrefabs; // Array to hold ingredient prefabs
    public float spawnInterval = 0.5f; // Interval in seconds between spawns
    public float spawnRangeX = 8f; // Range on the X axis to spawn ingredients
    public float spawnHeight = 10f; // Height above the scene to spawn ingredients

    private void Start()
    {
        InvokeRepeating("SpawnIngredient", 0f, spawnInterval); // Start spawning ingredients
    }

    void SpawnIngredient()
    {
        if (ingredientPrefabs.Length == 0)
        {
            Debug.LogWarning("No ingredient prefabs assigned to IngredientSpawner.");
            return;
        }

        // Choose a random ingredient prefab
        int index = Random.Range(0, ingredientPrefabs.Length);

        // Determine a random spawn position above the scene
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            spawnHeight,
            0f
        );

        // Instantiate the ingredient at the spawn position
        Instantiate(ingredientPrefabs[index], spawnPosition, Quaternion.identity);
    }
}
