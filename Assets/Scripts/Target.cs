using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifeDuration = 2f;
    public GameObject particlePrefab;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifeDuration);
        GameManager.Instance.unSpawnedTargets.Add(this);
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Bullet");
        {
            GameManager.Instance.score++;
            GameManager.Instance.unSpawnedTargets.Add(this);
            Destroy(gameObject);
        }
    }
}
