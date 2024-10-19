using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnKeyPress : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayOrPauseAudio();
        }
    }

    void PlayOrPauseAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
    }
}
