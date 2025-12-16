using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    public AudioClip soundClip1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //stopp movement
            AutoRunner runner = other.GetComponent<AutoRunner>();
            if (runner != null)
            {
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
        audioSource.Play();


        //wait for sound to finish
        yield return new WaitForSeconds(soundClip1.length);


        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}