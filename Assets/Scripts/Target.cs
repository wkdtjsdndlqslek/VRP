using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeDuration = 2f;
    public GameObject particlePrefab;

    private void OnEnable()
    {
        Invoke("TargetDestroy", lifeDuration);
    }

    private void TargetDestroy()
    {
        if (gameObject.activeSelf)
        {
            GameManager.Instance.unSpawnedTargets.Add(this);
            GameManager.Instance.spawnedTargets.Remove(this);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Bullet");
        {
            GameManager.Instance.score++;
            TargetDestroy();
        }
    }
}
