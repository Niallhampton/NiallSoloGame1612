using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    public AudioClip soundClip1; //death sound

    void OnTriggerEnter2D(Collider2D other) //called when object enters collider
    {
        if (other.CompareTag("Player")) //checks object is player
        {
            //stopp movement
            AutoRunner runner = other.GetComponent<AutoRunner>();
            if (runner != null)
            {                                   //stops movement by setting the player to dead
                runner.isDead = true;
            }


            StartCoroutine(PlaySoundAndRestart());
        }
    }

    private IEnumerator PlaySoundAndRestart()
    {
        //create audio source
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip1;
        audioSource.volume = 0.1f;
        audioSource.Play();
     


        //wait for sound to finish
        yield return new WaitForSeconds(soundClip1.length);


        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}