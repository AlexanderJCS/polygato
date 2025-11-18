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
        new[] { true, false, false, false, false },  // 2
        new[] { false, true, false, false, false },  // 3
        new[] { true, true, false, false, false },   // 2:3
        new[] { false, false, true, false, false },  // 4
        new[] { true, false, true, false, false },   // 2:4
        new[] { true, true, true, false, false },    // 2:3:4
        new[] { false, false, false, true, false },  // 5
        new[] { true, false, false, true, false },   // 2:5
        new[] { false, true, false, true, false },   // 3:5
        new[] { false, false, true, true, false },   // 4:5
        new[] { true, true, false, true, false },    // 2:3:5
        new[] { true, false, true, true, false },    // 2:4:5
        new[] { false, true, true, true, false },    // 3:4:5
        new[] { true, true, true, true, false },     // 2:3:4:5
        new[] { true, true, true, true, true }       // 2:3:4:5:6
    };

    // 0 - 3:2 music track
    // 1 - 5:2 music track
    // 2 - 2:3:4:5:6 music track
    private int[] musicPerLevel = new[]
    {
        0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2
    };

    IEnumerator GameCoroutine()
    {
        yield return new WaitForSeconds(0.1f);  // wait for beatscript to initialize
        beatScript.PlayBeat(0);  // load the beat into memory so it plays immediately
        yield return new WaitForSeconds(0.02f);
        beatScript.PlayBeat(1);  // load the beat into memory so it plays immediately
        yield return new WaitForSeconds(0.02f);
        beatScript.PlayBeat(2);  // load the beat into memory so it plays immediately
        yield return new WaitForSeconds(0.02f);
        beatScript.StopBeat();
        
        yield return new WaitForSeconds(0.1f);
        
        for (int levelIdx = 0;  levelIdx < levels.Length; levelIdx++)
        {
            beatScript.PlayBeat(musicPerLevel[levelIdx]);
            
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

            yield return new WaitForSeconds(timePerLevel * 2);
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
