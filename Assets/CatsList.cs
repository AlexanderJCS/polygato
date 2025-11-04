using UnityEngine;

public class CatsList : MonoBehaviour
{
    [SerializeField] private CatSpinner[] cats;

    public CatSpinner[] GetCats()
    {
        return cats;
    }
}
