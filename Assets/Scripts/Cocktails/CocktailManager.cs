using UnityEngine;
using UnityEngine.UI;

public class CocktailManager : MonoBehaviour
{
    public Image cocktailImage;
    public Cocktail[] cocktails; 

    private int currentCocktailIndex;

    void Start()
    {
        GenerateNewCocktail();
    }

    public void GenerateNewCocktail()
    {
        currentCocktailIndex = Random.Range(0, cocktails.Length);
        cocktailImage.sprite = cocktails[currentCocktailIndex].image;
    }

    public Cocktail GetCurrentCocktail()
    {
        return cocktails[currentCocktailIndex];
    }
}
