using UnityEngine;

public class BeatScript : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBeat()
    {
        audioSource.Play();
    }
    
    public void StopBeat()
    {
        audioSource.Stop();
    }
}
