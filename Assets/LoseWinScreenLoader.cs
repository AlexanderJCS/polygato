using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseWinScreenLoader : MonoBehaviour
{
    private void Update()
    {
        // Load main scene (index 0) on space
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(1);
        }
        // Quit game on escape
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        // Load title scene on enter
        else if (Keyboard.current.enterKey.wasPressedThisFrame)
        { 
            SceneManager.LoadScene(0);
        }
    }
}
