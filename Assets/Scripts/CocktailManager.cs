using UnityEngine;
using UnityEngine.UI;

public class CocktailManager : MonoBehaviour
{
    public Image cocktailImage; 
    public Sprite[] cocktails; 
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
