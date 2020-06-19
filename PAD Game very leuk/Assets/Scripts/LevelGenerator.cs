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
        Transform lastLevelPartTransform;
        //This will spawn a LevelPart, which is assigned in the editor, on the EndPosition of the last level.
        lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("Endposition").position);
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(LevelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
