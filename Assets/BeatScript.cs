using UnityEngine;

public class BeatScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBeat(int index)
    {
        if (index < 0 || index >= clips.Length) return;

        audioSource.clip = clips[index];
        audioSource.Play();
    }
    
    public void StopBeat()
    {
        audioSource.Stop();
    }
}
