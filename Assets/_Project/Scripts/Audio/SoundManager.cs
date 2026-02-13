using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource, backgroundSound;
    [SerializeField] private AudioClip shootSound, coinPickup, coinDrop, enemyDamageSound, playerDamageSound, gameOverSound;

    private void Awake()
    {
        if (audioSource == null) 
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayShootSound()
    {
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    public void PlayPlayerDamageSound()
    {
        if (playerDamageSound != null) 
        {
            audioSource.PlayOneShot(playerDamageSound);
        }
    }

    public void PlayEnemyDamageSound()
    {
        if (enemyDamageSound != null)
        {
            audioSource.PlayOneShot(enemyDamageSound);
        }
    }

    public void PlayCoinDrop()
    {
        if (coinDrop != null)
        {
            audioSource.PlayOneShot(coinDrop);
        }
    }

    public void PlayCoinPickup()
    {
        if (coinPickup != null)
        {
            audioSource.PlayOneShot(coinPickup);
        }
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundSound != null)
        {
            backgroundSound.Stop();
        }
    }
}
