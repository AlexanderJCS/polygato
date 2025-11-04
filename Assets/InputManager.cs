using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionMap inputs;
    [SerializeField] private CatSpinner[] cats;

    private void Start()
    {
        for (int i = 1; i <= 5; i++)
        {
            int index = i;
            InputAction action = inputs.FindAction(index.ToString());
            action.performed += _ => OnButtonPressed(index);
            action.canceled += _ => OnButtonReleased(index);
            action.Enable();
        }
    }

    private void OnButtonReleased(int index)
    {
        cats[index - 1].SetPressed(false);
    }
    
    private void OnButtonPressed(int index)
    {
        cats[index - 1].SetPressed(true);
    }
}
