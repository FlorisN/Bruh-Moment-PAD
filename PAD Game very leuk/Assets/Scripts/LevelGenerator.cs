using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator: MonoBehaviour
{
    //We want this in the editor so we can put the prefabs in here

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform LevelPart_1;
    private void Awake()
    {
        //We use Transform because we want to know the positions from the EndPosition GameObject
        //so that we can set the SpawnLevelPart to the lastLevelPart position

        Transform lastLevelPartTransform;
        lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
    }

    //This is a transform because we want to know where to locate the next part
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
