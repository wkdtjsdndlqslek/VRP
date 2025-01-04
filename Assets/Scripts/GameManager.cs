using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    
    public List<Target> unSpawnedTargets;
    public List<Target> spawnedTargets;
    
    public float timer = 30f;
    [HideInInspector] public float currentSec;
    [HideInInspector] public int seconds;
    [HideInInspector] public int milliseconds;
    
    public int score = 0;
    
    public TargetSpawner targetSpawner;
    [FormerlySerializedAs("uiTimer")] public UIInGame uiInGame;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void GameStart()
    {
        targetSpawner.gameObject.SetActive(true);
        uiInGame.gameObject.SetActive(true);
    }

    public void GameEnd()
    {
        foreach (Target target in spawnedTargets)
        {
            target.gameObject.SetActive(false);
        }
        targetSpawner.gameObject.SetActive(false);
        uiInGame.gameObject.SetActive(false);
        timer = 30f;
    }
}
