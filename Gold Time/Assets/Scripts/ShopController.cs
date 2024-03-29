using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private bool isOpen = true;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeShop()
    {
        Color color;
        if (isOpen)
        {
            color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        }
        else
        {
            color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255f);
        }
        spriteRenderer.color = color;
        gameObject.GetComponent<CircleCollider2D>().enabled = !gameObject.GetComponent<CircleCollider2D>().enabled;
        isOpen = !isOpen;
    }
}
