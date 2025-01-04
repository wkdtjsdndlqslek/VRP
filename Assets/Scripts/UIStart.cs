using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    public Button startButton;

    public void Start()
    {
        startButton.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        GameManager.Instance.GameStart();
        gameObject.SetActive(false);
    }
}
