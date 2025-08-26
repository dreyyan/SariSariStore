using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickSFX : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) // New Input System
        {
            AudioManager.Instance.PlayClickSound();
        }
    }
}
