using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    public Target targetPrefab;
    public float updateInterval = 1f;
    public float spawnInterval = 1f;
    
    private Coroutine updateIntervalCoroutine;
    private Coroutine spawnTargetCoroutine;

    private void Awake()
    {
        updateIntervalCoroutine = StartCoroutine(UpdateInterval());
        spawnTargetCoroutine = StartCoroutine(SpawnTargetLoop());
    }

    private void Update()
    {
        if (GameManager.Instance.timer <= 0f)
        {
            if (updateIntervalCoroutine != null)
            {
                StopCoroutine(updateIntervalCoroutine);
                updateIntervalCoroutine = null;
            }
            if (spawnTargetCoroutine != null)
            {
                StopCoroutine(spawnTargetCoroutine);
                spawnTargetCoroutine = null;
            }
        }
    }

    IEnumerator UpdateInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);
            spawnInterval = Mathf.Max(spawnInterval - 0.1f, 0.2f); // 최소 간격 설정
        }
    }

    IEnumerator SpawnTargetLoop()
    {
        while (true)
        {
            int targetNum = Random.Range(0, GameManager.Instance.unSpawnedTargets.Count);
            Target target = GameManager.Instance.unSpawnedTargets[targetNum];
         
            target.gameObject.SetActive(true);
            GameManager.Instance.spawnedTargets.Add(target);
            GameManager.Instance.unSpawnedTargets.RemoveAt(targetNum);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
