using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class LevelGenerator: MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    //We want this in the editor so we can put the prefabs in here
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform LevelPart_1;

    private Vector3 lastEndPosition;
    private void Awake()
    {
        //We use Transform because we want to know the positions from the EndPosition GameObject
        //so that we can set the SpawnLevelPart to the lastLevelPart position.

        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        //First few level parts are spawning in:
        int startingSpawnLevelParts = 2;

        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn another level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    //This is a transform because we want to know where to locate the next part
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
