using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioLoop;
    public AudioSource audioSource;

    private bool audioChanged;

    void Update()
    {
        if(!audioSource.isPlaying && !audioChanged)
        {
            audioSource.clip = audioLoop;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
