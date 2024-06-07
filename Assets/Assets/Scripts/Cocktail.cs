using UnityEngine;

[CreateAssetMenu(fileName = "New Cocktail", menuName = "Cocktail")]
public class Cocktail : ScriptableObject
{
    public string cocktailName; // Name of the cocktail
    public Sprite image; // Image for the cocktail
    public int[] ingredientIDs; // IDs of the required ingredients
}
