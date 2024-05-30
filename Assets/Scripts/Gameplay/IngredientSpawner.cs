using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An ingredient spawner
/// </summary>
public class IngredientSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabIngredient;
    public float radius = 1.0f;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // save ingredient 
        GameObject ingredient = Instantiate<GameObject>(prefabIngredient);
        BoxCollider2D collider = ingredient.GetComponent<BoxCollider2D>();      
        Destroy(ingredient);

        // calculate screen width and height
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        // right side ingredient
        ingredient = Instantiate<GameObject>(prefabIngredient);
        Ingredient script = ingredient.GetComponent<Ingredient>();
        script.Initialize(Direction.Left,
            new Vector2(ScreenUtils.ScreenRight + radius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        // top side asteroid
        ingredient = Instantiate<GameObject>(prefabIngredient);
        script = ingredient.GetComponent<Ingredient>();
        script.Initialize(Direction.Down,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + radius));

        // left side asteroid
        ingredient = Instantiate<GameObject>(prefabIngredient);
        script = ingredient.GetComponent<Ingredient>();
        script.Initialize(Direction.Right,
            new Vector2(ScreenUtils.ScreenLeft - radius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        // bottom side asteroid
        ingredient = Instantiate<GameObject>(prefabIngredient);
        script = ingredient.GetComponent<Ingredient>();
        script.Initialize(Direction.Up,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - radius));
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }
}
