using UnityEngine;

public class IngredientCollector : MonoBehaviour
{
    private int[] cocktailIngredients;
    private int collectedIngredients;

    void Start()
    {
        SetupCurrentCocktail();
    }

    void SetupCurrentCocktail()
    {
        CocktailManager cocktailManager = FindObjectOfType<CocktailManager>();
        Cocktail currentCocktail = cocktailManager.GetCurrentCocktail();
        cocktailIngredients = currentCocktail.ingredientIDs;
        collectedIngredients = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ingredient ingredient = collision.gameObject.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            int ingredientID = ingredient.GetIngredientID();
            for (int i = 0; i < cocktailIngredients.Length; i++)
            {
                if (cocktailIngredients[i] == ingredientID)
                {
                    collectedIngredients++;
                    Destroy(collision.gameObject);

                    if (collectedIngredients == cocktailIngredients.Length)
                    {
                        ScoreManager.instance.AddScore(1);
                        FindObjectOfType<CocktailManager>().GenerateNewCocktail();
                        SetupCurrentCocktail(); // Reset the collection for new cocktail
                    }
                }
            }
        }
    }
}
