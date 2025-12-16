using UnityEngine;

public class soundDeath: MonoBehaviour
{
    private AudioClip soundClip1;
    private float volume = 0.7f;

    void Awake()
    {
        //get soundclip from folder
        soundClip1 = Resources.Load<AudioClip>("soundClip1");
      
    }
    public void PlaySound()
    {
        if (soundClip1 != null)
        {
            AudioSource.PlayClipAtPoint(soundClip1, transform.position, volume);
        }
    }
}
