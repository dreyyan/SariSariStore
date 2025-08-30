using UnityEngine;

public class GameAreaNavigation : MonoBehaviour
{
    // ATTRIBUTES
    public string currentArea = "center"; // Possible values: "left", "center", "right"
    public GameObject FrontArea;
    public GameObject LeftArea;
    public GameObject RightArea;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    // METHODS
    public void NavigateLeft()
    {
        if (currentArea == "center")
        {
            // Move to left area
            currentArea = "left";
            FrontArea.SetActive(false);
            LeftArea.SetActive(true);
            RightArea.SetActive(false);
            LeftArrow.SetActive(false);
            RightArrow.SetActive(true);
        }
        else if (currentArea == "right")
        {
            // Move to center area
            currentArea = "center";
            FrontArea.SetActive(true);
            LeftArea.SetActive(false);
            RightArea.SetActive(false);
            LeftArrow.SetActive(true);
            RightArrow.SetActive(true);
        }
    }

    public void NavigateRight()
    {
        if (currentArea == "center")
        {
            // Move to right area
            currentArea = "right";
            FrontArea.SetActive(false);
            LeftArea.SetActive(false);
            RightArea.SetActive(true);
            LeftArrow.SetActive(true);
            RightArrow.SetActive(false);
        }
        else if (currentArea == "left")
        {
            // Move to center area
            currentArea = "center";
            FrontArea.SetActive(true);
            LeftArea.SetActive(false);
            RightArea.SetActive(false);
            LeftArrow.SetActive(true);
            RightArrow.SetActive(true);
        }
    }
}
