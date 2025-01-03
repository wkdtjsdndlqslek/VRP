using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public Target targetPrefab;
    public float updateInterval = 3f;
    public float spawnInterval = 1f;

    private void Awake()
    {
        for (int j = 0; j <= 5; j++)
        {
            for (int i = -9; i <= 9; i++)
            {
                Target target = Instantiate(targetPrefab, new Vector3(2 * i, (2*j)+1, 20), Quaternion.identity);
                GameManager.Instance.unSpawnedTargets.Add(target);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator UpdateInterval()
    {
        yield return new WaitForSeconds(updateInterval);
        spawnInterval -= 0.1f;
    }

    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(spawnInterval);
        int targetNum = Random.Range(0, GameManager.Instance.unSpawnedTargets.Count);
        GameManager.Instance.unSpawnedTargets[targetNum].gameObject.SetActive(true);
        GameManager.Instance.spawnedTargets.Add(GameManager.Instance.unSpawnedTargets[targetNum]);
        GameManager.Instance.unSpawnedTargets.RemoveAt(targetNum);
    }
}
