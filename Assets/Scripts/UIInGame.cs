using TMPro;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    private void Update()
    {
        if (GameManager.Instance.timer > 0)
        {
            GameManager.Instance.timer -= Time.deltaTime;
            GameManager.Instance.seconds = Mathf.FloorToInt(GameManager.Instance.timer);
            GameManager.Instance.milliseconds = Mathf.FloorToInt((GameManager.Instance.timer - GameManager.Instance.seconds) * 100);
            timerText.text = GameManager.Instance.seconds.ToString("00") + ":" + GameManager.Instance.milliseconds.ToString("00");
        }
        else
        {
            GameManager.Instance.timer = 0;
            timerText.text = "00:00";
            GameManager.Instance.GameEnd();
        }
        scoreText.text = "Score : "+GameManager.Instance.score.ToString();
    }
}
