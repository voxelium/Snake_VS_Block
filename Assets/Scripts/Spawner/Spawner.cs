using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private int linesAmount;
    [SerializeField] private int distanceBetweenFullLine;
    [SerializeField] private int distanceBetweenRandomLine;

    [SerializeField] private Block blockTemplate;
    [SerializeField] private int blockSpawnChance;

    private SpawnPoint[] blockSpawnPoints;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        for (int i = 0; i < linesAmount; i++)
        {
            GenerateFullLine(blockSpawnPoints, blockTemplate.gameObject);
            MoveSpawner(distanceBetweenFullLine);
        }

    }


  
    private void GenerateRandomElements()
    {


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

    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }

}
