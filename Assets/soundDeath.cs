using UnityEngine;

public class DeathSound: MonoBehaviour
{
    private AudioClip soundClip1;
    private float volume = 0.7f;

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(soundClip1, transform.position, volume);
    }
}
