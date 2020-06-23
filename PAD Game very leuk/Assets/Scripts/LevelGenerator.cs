using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class LevelGenerator: MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;
    private const float PLAYER_DISANCE_DELETE_LEVEL_PART = 200f;

    //We want this in the editor so we can put the prefabs in here
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;

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
        //When the distance of this object (on the player) and the lastEndPosition is less than PLAYER_DIST...
        //then the method SpawnLevelPart(); will be called.
        if (Vector3.Distance(transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn another level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        //Transform to get the position of the lastLevelPart, so the next LevelPart wil spawn on the
        //EndPosition of the one that's checking right now

        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)]
;        Transform lastLevelPartTransform = SpawnLevelPart( chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;



        if (Vector3.Distance(transform.position, lastEndPosition) > PLAYER_DISANCE_DELETE_LEVEL_PART) {
            Destroy(lastLevelPartTransform);
        } 
    }

    //This is a transform because we want to know where to locate the next part
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        //Quaternion.identity so it doesn't rotate
        //Transform to get the position

        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
