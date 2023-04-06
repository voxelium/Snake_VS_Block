using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform container;
    [SerializeField] private int _LinesAmount;

    [Header("Damage Blocks")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    [SerializeField] private int _distanceBetweenFullLines;
    [SerializeField] private int _distanceBetweenRandomLines;

    [Header("Bonus Blocks")]
    [SerializeField] private Bonus _bonusTemplate;
    [SerializeField] private int _distanceBetweenBonusLines;
    [SerializeField] private int _bonusSpawnChance;

    [Header("Wall")]
    [SerializeField] private Wall wallTemplateLeft;
    [SerializeField] private Wall wallTemplateRight;
    [Header("Finish Line")]
    [SerializeField] private FinishLine finishLine;

    private SpawnPoint[] blockSpawnPoints;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        for (int i = 0; i < _LinesAmount; i++)
        {
            MoveSpawner(_distanceBetweenFullLines);
            GenerateFullLine(blockSpawnPoints, _blockTemplate.gameObject);
            MoveSpawner(_distanceBetweenRandomLines);
            GenerateRandomElements(blockSpawnPoints, _blockTemplate.gameObject, _blockSpawnChance);
            MoveSpawner(_distanceBetweenBonusLines);
            GenerateRandomElements(blockSpawnPoints, _bonusTemplate.gameObject, _bonusSpawnChance);
        }


        //Спавн боковых стенок
        Vector3 wallSpawnPositionLeft = wallTemplateLeft.transform.position;
        Vector3 wallSpawnPositionRight = wallTemplateRight.transform.position;

        int wallCount = 9 + _LinesAmount + (_distanceBetweenFullLines + _distanceBetweenRandomLines + _distanceBetweenBonusLines) * _LinesAmount;

        for (int i = 0; i < wallCount; i++)
        {
            Instantiate(wallTemplateLeft.gameObject, wallSpawnPositionLeft, Quaternion.identity);
            Instantiate(wallTemplateRight.gameObject, wallSpawnPositionRight, Quaternion.identity);

            wallSpawnPositionLeft = newSpawnPosition(wallSpawnPositionLeft);
            wallSpawnPositionRight = newSpawnPosition(wallSpawnPositionRight);
        }

        //Spawn finish line
        Vector3 finishLinePosition = new Vector3 (0, wallSpawnPositionLeft.y, 0);
        Instantiate(finishLine.gameObject, finishLinePosition, Quaternion.identity);

    }

    // increase value Y for wall spawn
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
