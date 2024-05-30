using UnityEngine;
using UnityEngine.UI;

public class CocktailManager : MonoBehaviour
{
    public Image cocktailImage; // Assign this in the Inspector
    public Sprite[] cocktails; // Array of cocktail sprites
    private int currentCocktailIndex;

    void Start()
    {
        GenerateNewCocktail();
    }

    public void GenerateNewCocktail()
    {
        currentCocktailIndex = Random.Range(0, cocktails.Length);
        cocktailImage.sprite = cocktails[currentCocktailIndex];
    }

    public int GetCurrentCocktailIndex()
    {
        return currentCocktailIndex;
    }
}
