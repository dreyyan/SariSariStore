using UnityEngine;
using UnityEngine.EventSystems;

public class RefManager : MonoBehaviour, IPointerClickHandler
{
    // ATTRIBUTES
    bool isOpen = false;

    // METHODS
    public void openRef() {
        // Play sound effect
        AudioManager.Instance.PlayRefOpenSound();
    }

    public void closeRef() {
        // Play sound effect
        AudioManager.Instance.PlayRefCloseSound();
    }

    public void clickRef()
    {
        if (isOpen)
        {
            closeRef();
            isOpen = false;
        }
        else
        {
            openRef();
            isOpen = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickRef();
    }
}
