using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Sprite square;

     public Sprite[] sprites;

    public int numSprites;

    private void Awake()
    {
        Vector3 pos = new Vector3 (-40.0f, transform.position.y, 0.0f);

        for (int i = 0; i < numSprites; ++i)
        {
            Sprite backgroundSprite = sprites[i % sprites.Length];

            // Background sprite
            GameObject spriteObject = new GameObject("Sprite");

            spriteObject.transform.parent = transform;
            spriteObject.transform.position = pos;

            SpriteRenderer renderer = spriteObject.AddComponent<SpriteRenderer>();

            renderer.sprite = backgroundSprite;
            renderer.flipX = i % 2 == 0;       

            // Sky
            GameObject skyObject = new GameObject("Sky");

            skyObject.transform.parent = transform;
            skyObject.transform.position = pos + new Vector3(0.0f, 15.0f, 1.0f);
            skyObject.transform.localScale = new Vector2(25.0f, 25.0f);

            renderer = skyObject.AddComponent<SpriteRenderer>();

            renderer.sprite = square;
            renderer.color = new Color(209 / 255.0f, 244 / 255.0f, 247 / 255.0f);

            pos.x += backgroundSprite.rect.width / 100.0f; // 100.0f: World Scale Units
        }
    }
}
