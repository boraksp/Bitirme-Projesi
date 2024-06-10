//using UnityEngine;

//public class IngredientCollector : MonoBehaviour
//{
//    private int[] cocktailIngredients;
//    private int collectedIngredients;

//    void Start()
//    {
//        SetupCurrentCocktail();
//    }

//    void SetupCurrentCocktail()
//    {
//        CocktailManager cocktailManager = FindObjectOfType<CocktailManager>();
//        Cocktail currentCocktail = cocktailManager.GetCurrentCocktail();
//        cocktailIngredients = currentCocktail.ingredientIDs;
//        collectedIngredients = 0;
//    }

//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        Ingredient ingredient = collision.gameObject.GetComponent<Ingredient>();
//        if (ingredient != null)
//        {
//            int ingredientID = ingredient.GetIngredientID();
//            for (int i = 0; i < cocktailIngredients.Length; i++)
//            {
//                if (cocktailIngredients[i] == ingredientID)
//                {
//                    collectedIngredients++;
//                    Destroy(collision.gameObject);

//                    if (collectedIngredients == cocktailIngredients.Length)
//                    {
//                        ScoreManager.instance.AddScore(1);
//                        FindObjectOfType<CocktailManager>().GenerateNewCocktail();
//                        SetupCurrentCocktail(); // Reset the collection for new cocktail
//                    }
//                }
//            }
//        }
//    }
//}

using System.Collections.Generic;
using UnityEngine;

public class IngredientCollector : MonoBehaviour
{
    public CocktailManager cocktailManager; // Reference to CocktailManager
    private HashSet<int> requiredIngredients; // Ingredients required for the current cocktail
    private HashSet<int> collectedIngredients; // Ingredients collected
    private int incorrectCollectionCount = 0; // Count of wrong ingredients collected
    public int maxIncorrectCollections = 2; // Maximum allowed incorrect collections

    private void Start()
    {
        UpdateRequiredIngredients();
    }

    private void UpdateRequiredIngredients()
    {
        int currentCocktailIndex = cocktailManager.GetCurrentCocktailIndex();
        Cocktail currentCocktail = cocktailManager.cocktails[currentCocktailIndex];
        requiredIngredients = new HashSet<int>(currentCocktail.ingredientIDs);
        collectedIngredients = new HashSet<int>(); // Reset for new cocktail
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            int ingredientID = ingredient.GetIngredientID();
            if (requiredIngredients.Contains(ingredientID))
            {
                // Correct ingredient collected
                collectedIngredients.Add(ingredientID);
                Destroy(other.gameObject); // Remove the ingredient
                if (collectedIngredients.SetEquals(requiredIngredients))
                {
                    // All required ingredients collected
                    cocktailManager.NextCocktail();
                    UpdateRequiredIngredients();
                }
            }
            else
            {
                // Incorrect ingredient collected
                incorrectCollectionCount++;
                Destroy(other.gameObject); // Remove the ingredient
                if (incorrectCollectionCount >= maxIncorrectCollections)
                {
                    EndGame();
                }
            }
        }
    }
    private void EndGame()
    {
        Debug.Log("Game Over!");
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        gameOverManager.ShowGameOver(); // Show the Game Over menu
    }
}




