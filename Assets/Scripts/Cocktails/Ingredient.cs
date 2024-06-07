using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int ingredientID; // Assign a unique ID for each ingredient type in the Inspector

    public int GetIngredientID()
    {
        return ingredientID;
    }
}
