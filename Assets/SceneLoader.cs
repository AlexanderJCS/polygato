using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        // Load scene index 1 on any other button press
        else if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            // Check if any key was pressed that isn't space or escape
            bool otherKeyPressed = false;
            foreach (var key in Keyboard.current.allKeys)
            {
                if (key.wasPressedThisFrame && key != Keyboard.current.spaceKey && key != Keyboard.current.escapeKey)
                {
                    otherKeyPressed = true;
                    break;
                }
            }
            
            if (otherKeyPressed)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
