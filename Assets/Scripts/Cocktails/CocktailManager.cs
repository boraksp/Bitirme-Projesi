//using UnityEngine;
//using UnityEngine.UI;

//public class CocktailManager : MonoBehaviour
//{
//    public Image cocktailImage;
//    public Cocktail[] cocktails;

//    private int currentCocktailIndex;

//    void Start()
//    {
//        GenerateNewCocktail();
//    }

//    public void GenerateNewCocktail()
//    {
//        currentCocktailIndex = Random.Range(0, cocktails.Length);
//        cocktailImage.sprite = cocktails[currentCocktailIndex].image;
//    }

//    public Cocktail GetCurrentCocktail()
//    {
//        return cocktails[currentCocktailIndex];
//    }
//}
using UnityEngine;
using UnityEngine.UI;

public class CocktailManager : MonoBehaviour
{
    public Cocktail[] cocktails; // Array of cocktails
    public Image cocktailImage; // Reference to the UI Image component
    public Text cocktailNameText; // Reference to the UI Text component for the cocktail name

    private int currentCocktailIndex;
    private System.Random random; // For generating random numbers

    private void Start()
    {
        random = new System.Random(); // Initialize the random number generator
        SelectRandomCocktail(); // Start with a random cocktail
    }

    public int GetCurrentCocktailIndex()
    {
        return currentCocktailIndex;
    }

    public void NextCocktail()
    {
        SelectRandomCocktail();       
    }

    private void SelectRandomCocktail()
    {

        //array check
        if (cocktails.Length == 0)
        {
            Debug.LogError("No cocktails found!"); // Log error if the array is empty
            return;
        }

        currentCocktailIndex = random.Next(cocktails.Length); // Select a random index
        Debug.Log("Selected Cocktail Index: " + currentCocktailIndex);
        DisplayCurrentCocktail();

    }

    private void DisplayCurrentCocktail()
    {
        if (cocktailImage != null && cocktails[currentCocktailIndex] != null)
        {
            cocktailImage.sprite = cocktails[currentCocktailIndex].image;
        }

        if (cocktailNameText != null && cocktails[currentCocktailIndex] != null)
        {
            cocktailNameText.text = cocktails[currentCocktailIndex].cocktailName;
            Debug.Log("Displaying Cocktail: " + cocktails[currentCocktailIndex].cocktailName);
        }
    }
}


