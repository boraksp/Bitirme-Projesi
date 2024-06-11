using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject recipesImage; // Reference to the Recipes Image

    private void Start()
    {
        // Ensure the recipes image is hidden at start
        recipesImage.SetActive(false);
    }

    public void OnRecipesButtonClick()
    {
        // Toggle the visibility of the recipes image
        recipesImage.SetActive(!recipesImage.activeSelf);
    }
}
