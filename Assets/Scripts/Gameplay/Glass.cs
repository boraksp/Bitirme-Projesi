using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private float glassMovespeed = 2f;
    Rigidbody2D rb2d;
    float halfColliderWidth;

    #endregion

    #region Methods

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        halfColliderWidth = boxCollider.size.x * 0.5f;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * glassMovespeed * Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    float CalculateClampedX(float newX)
    {
        //Calculate the minimum and maximum x position based on the screen boundaries and half collider width
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfColliderWidth;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfColliderWidth;

        //clamp the new x position within the screen boundaries
        float clampedX = Mathf.Clamp(newX, minX, maxX);

        return clampedX;
    }

    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        //on top collisions, both contact points are the same y location
        ContactPoint2D[] contacts = new ContactPoint2D[2];
        coll.GetContacts(contacts);
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    #endregion
}
