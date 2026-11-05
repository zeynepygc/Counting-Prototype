using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Good"))
        {
            gameManager.AddScore(3);
        }
        else if (other.CompareTag("Special"))
        {
            gameManager.AddTime(5f);
        }
        else if (other.CompareTag("Bad"))
        {
            gameManager.AddScore(-3);
        }

        Destroy(other.gameObject);
    }
}