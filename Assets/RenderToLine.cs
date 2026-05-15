
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RenderToLine : MonoBehaviour
{
    private void Awake()
    {
        ApplyToLine();
    }

    public void ApplyToLine()
    {
        Texture2D texture2D = GetComponent<ITextureHolder>().GetTexture2D();
        float period = GetComponent<ITextureHolder>().GetPeriod();
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = texture2D.width * texture2D.height;
        
        for (int y = 0; y < texture2D.height; y++)
        {
            for (int x = 0; x < texture2D.width; x++)
            {
               int index = x + y * texture2D.width;
               lineRenderer.SetPosition(index, new Vector3(x / period, texture2D.GetPixel(x, y).r));
            }
        }
    }
}
