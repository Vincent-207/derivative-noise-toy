using UnityEngine;

public class TextureDisplay : MonoBehaviour
{
    Draw2DVarWidth drawVarWidth;
    SpriteRenderer spriteRenderer;
    Sprite[] _sprites;
    public int a;
    void Start()
    {
        drawVarWidth = GetComponent<Draw2DVarWidth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _sprites = drawVarWidth.GetSprites();
    }

    void Update()
    {
        Display(a);
    }

    void Display(int index)
    {
        spriteRenderer.sprite = _sprites[index];
    }
}
