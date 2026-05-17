using UnityEngine;

public class InterpolationToLine : MonoBehaviour
{
    public void ApplyToLine(Texture2D initial, Texture2D final, float t)
    {
        Debug.Log("Applying! - " + t);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        float period = GetComponent<ITextureHolder>().GetPeriod();
        lineRenderer.positionCount = initial.width * initial.height;
        Debug.Log("Period: " + period);
        for (int index = 0, y = 0; y < initial.height; y++)
        {
            for (int x = 0; x < initial.width; x++)
            {
                // Debug.Log(index + " val: " + initial.GetPixel(x, y).r);
                float value = Mathf.Lerp(initial.GetPixel(x, y).r, final.GetPixel(x, y).r, t) * 2f - 1f;
                lineRenderer.SetPosition(index, new Vector3(x/period, value));
                index++;
            }
        }
    }
}
