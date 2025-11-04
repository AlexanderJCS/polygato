using System;
using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private CatsList catsList;
    [SerializeField] private float bpm = 40f;
    private float roundDuration;

    public void Start()
    {
        roundDuration = bpm / 60f * 3;
        // StartCoroutine(RoundManagerCoroutine());
    }
    
    IEnumerator RoundManagerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(roundDuration);
            catsList.GetCats()[0].ActivateCat();
            yield return new WaitForSeconds(roundDuration);
            catsList.GetCats()[0].DeactivateCat();
        }
    }
}
