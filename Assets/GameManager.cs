using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CatsList catsList;
    [SerializeField] private BeatScript beatScript;
    [SerializeField] private float bpm;
    private float timePerLevel;
    
    private bool[][] levels = new[]
    {
        new[] { true, false, false, false, true },
        new[] { false, true, false, false, false },
        new[] { true, true, false, false, false }
    };

    IEnumerator GameCoroutine()
    {
        yield return new WaitForSeconds(0.1f);  // wait for beatscript to initialize
        beatScript.PlayBeat();  // load the beat into memory so it plays immediately
        yield return new WaitForSeconds(0.02f);
        beatScript.StopBeat();
        
        yield return new WaitForSeconds(0.1f);
        
        beatScript.PlayBeat();
        
        foreach (var level in levels)
        {
            Debug.Log("new level!");
            for (int i = 0; i < level.Length; i++)
            {
                if (catsList.GetCats()[i] == null)
                {
                    continue;
                }
                
                if (level[i])
                {
                    catsList.GetCats()[i].ActivateCat();
                }
                else
                {
                    catsList.GetCats()[i].DeactivateCat();
                }
            }

            yield return new WaitForSeconds(timePerLevel);
        }
        
        beatScript.StopBeat();
    }
    
    private void Start()
    {
        float secsPerBeat = 60f / bpm;
        float beatsPerIteration = 2f;
        timePerLevel = secsPerBeat * beatsPerIteration;
        StartCoroutine(GameCoroutine());
    }
}
