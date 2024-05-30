//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class IngredientCollector : MonoBehaviour
//{
//    private int[] cocktailIngredients;
//    private int collectedIngredients;

//    void Start()
//    {
//        CocktailManager cocktailManager = FindObjectOfType<CocktailManager>();
//        int currentCocktail = cocktailManager.GetCurrentCocktailIndex();

       
//        if (currentCocktail == 0)
//            cocktailIngredients = new int[] { 1, 2, 3 };

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
//                        Start();
//                    }
//                }
//            }
//        }
//    }
//}
