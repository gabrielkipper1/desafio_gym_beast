using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject aiPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> spawnedAIS = new List<GameObject>();

    public int maxAIs = 10;
    public float spawnRate = 2;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnRate;
    }

    private void Update()
    {
        if (spawnedAIS.Count < maxAIs)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawnTimer = spawnRate;
                SpawnAI();
            }
        }
    }

    private void SpawnAI()
    {
        if (spawnPoints.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];
        GameObject gameObject = Instantiate(aiPrefab, spawnPoint.position, Quaternion.identity);
        AICharacter aiController = gameObject.GetComponent<AICharacter>();
        aiController.onDeath.AddListener(OnAIDeath);
        spawnedAIS.Add(gameObject);
    }

    private void OnAIDeath(Character character)
    {
        spawnedAIS.Remove(character.gameObject);
    }
}
