using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject aiPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public List<Character> spawnedAIS = new List<Character>();

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

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject gameObject = Instantiate(aiPrefab, spawnPoint.position, Quaternion.identity);
        AICharacter aiController = gameObject.GetComponent<AICharacter>();

        aiController.onDeath.AddListener(OnAIDeath);
        spawnedAIS.Add(aiController);
    }

    private void OnAIDeath(Character character)
    {
        character.onDeath.RemoveListener(OnAIDeath);
        spawnedAIS.Remove(character);
    }

    private void OnDisable()
    {
        for (int i = 0; i < spawnedAIS.Count; i++)
        {
            spawnedAIS[i].onDeath.RemoveListener(OnAIDeath);
        }
    }
}
