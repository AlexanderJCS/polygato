using System;
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
        new[] { true, false, false, false, false },
        new[] { false, true, false, false, false },
        new[] { true, true, false, false, false },
        new[] { false, false, true, false, false },
        new[] { true, false, true, false, false },
        new[] { true, true, true, false, false },
        new[] { false, false, false, true, false },
        new[] { true, false, false, true, false },
        new[] { false, true, false, true, false },
        new[] { false, false, true, true, false },
        new[] { true, true, false, true, false },
        new[] { true, false, true, true, false },
        new[] { false, true, true, true, false },
        new[] { true, true, true, true, false },
        new[] { true, true, true, true, true }
    };

    IEnumerator GameCoroutine()
    {
        yield return new WaitForSeconds(0.1f);  // wait for beatscript to initialize
        beatScript.PlayBeat();  // load the beat into memory so it plays immediately
        yield return new WaitForSeconds(0.02f);
        beatScript.StopBeat();
        
        yield return new WaitForSeconds(0.1f);
        
        beatScript.PlayBeat();
        
        for (int levelIdx = 0;  levelIdx < levels.Length; levelIdx++)
        {
            bool[] level = levels[levelIdx];
            bool[] nextLevel = levels[Math.Min(levelIdx + 1, level.Length)];
            
            Debug.Log("new level!");
            for (int catIdx = 0; catIdx < catsList.GetCats().Length; catIdx++)
            {
                Debug.Log("CatIdx: " + catIdx);
                if (catsList.GetCats()[catIdx] == null)
                {
                    Debug.LogWarning("Cat Idx " + catIdx + " is null!");
                    continue;
                }
                
                // Activate them for playing
                if (level[catIdx])
                {
                    Debug.Log(catIdx + " is playing");
                    catsList.GetCats()[catIdx].ActivateCat();
                    continue;
                }
                
                // Cat is not playing
                catsList.GetCats()[catIdx].DeactivateCat();
                
                
                // Preview the cats playing next round
                if (nextLevel[catIdx])
                {
                    Debug.Log("Showing cat " + catIdx);
                    catsList.GetCats()[catIdx].Show();
                }
                else
                {
                    Debug.Log("Hiding cat " + catIdx);
                    catsList.GetCats()[catIdx].Hide();
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
