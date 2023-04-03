using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform container;
    [SerializeField] private int linesAmount;
    [SerializeField] private int distanceBetweenFullLine;
    [SerializeField] private int distanceBetweenRandomLine;
    [Header("Blocks")]
    [SerializeField] private Block blockTemplate;
    [SerializeField] private int blockSpawnChance;
    [Header("Wall")]
    [SerializeField] private Wall wallTemplate;
    [SerializeField] private int wallSpawnChance;


    private SpawnPoint[] blockSpawnPoints;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        for (int i = 0; i < linesAmount; i++)
        {
            MoveSpawner(distanceBetweenFullLine);
            GenerateFullLine(blockSpawnPoints, blockTemplate.gameObject);
            MoveSpawner(distanceBetweenRandomLine);
            GenerateRandomElements(blockSpawnPoints, blockTemplate.gameObject, blockSpawnChance);
        }
    }


 
    private GameObject GenerateOneElement(Vector3 spawnPoint, GameObject generatedElement)
    {
        spawnPoint.y = spawnPoint.y - generatedElement.transform.localScale.y;

        return (Instantiate(generatedElement, spawnPoint, Quaternion.identity, container));
    }



    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateOneElement(spawnPoints[i].transform.position, generatedElement);
        }

    }


    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                GameObject element = GenerateOneElement(spawnPoints[i].transform.position, generatedElement);
            }
        }
    }


    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }


}
