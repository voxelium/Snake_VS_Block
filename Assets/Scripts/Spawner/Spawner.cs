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
    [SerializeField] private Wall wallTemplateLeft;
    [SerializeField] private Wall wallTemplateRight;
    [Header("Finish Line")]
    [SerializeField] private FinishLine finishLine;

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


        //Спавн боковых стенок
        Vector3 wallSpawnPositionLeft = wallTemplateLeft.transform.position;
        Vector3 wallSpawnPositionRight = wallTemplateRight.transform.position;

        int wallCount = 9 + linesAmount + distanceBetweenFullLine * linesAmount + distanceBetweenRandomLine * linesAmount;

        for (int i = 0; i < wallCount; i++)
        {
            Instantiate(wallTemplateLeft.gameObject, wallSpawnPositionLeft, Quaternion.identity);
            Instantiate(wallTemplateRight.gameObject, wallSpawnPositionRight, Quaternion.identity);

            wallSpawnPositionLeft = newSpawnPosition(wallSpawnPositionLeft);
            wallSpawnPositionRight = newSpawnPosition(wallSpawnPositionRight);
        }

        Vector3 finishLinePosition = new Vector3 (0, wallSpawnPositionLeft.y, 0);

        Instantiate(finishLine.gameObject, finishLinePosition, Quaternion.identity);

    }

    // увелничивает значение Y для спавна следущей боковой станки
    private Vector3 newSpawnPosition(Vector3 currentPosition)
    {
       Vector3 targetPosition = new Vector3 (currentPosition.x, currentPosition.y + wallTemplateLeft.transform.localScale.y, currentPosition.z);
       return targetPosition;
    }

 
    private GameObject GenerateOneElement(Vector3 BlockSpawnPoint, GameObject generatedElement)
    {
        BlockSpawnPoint.y = BlockSpawnPoint.y - generatedElement.transform.localScale.y;

        return (Instantiate(generatedElement, BlockSpawnPoint, Quaternion.identity, container));
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
