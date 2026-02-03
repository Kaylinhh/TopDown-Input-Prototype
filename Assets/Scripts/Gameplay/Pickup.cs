using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 1;
    public AudioClip pickupSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);

            if (AudioManager.instance != null)
                AudioManager.instance.PlaySFX(pickupSFX);

            Destroy(gameObject);
        }
    }

}
