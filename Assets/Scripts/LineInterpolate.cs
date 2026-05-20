using UnityEngine;
[ExecuteInEditMode]
public class LineInterpolate : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField]
    float interpolation = 0;
    public Texture2D startTexture, endTexture;
    public LineRenderer lineRenderer;
    public float period;
    public bool doSetup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Setup()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = startTexture.width;
    }

    void ApplyInterpolation()
    {
        lineRenderer.positionCount = startTexture.width;
        for (int x = 0; x < startTexture.width; x++)
        {
            lineRenderer.SetPosition(x, new Vector3(x / period, 2 * GetInterpolation(x)));
        }
    }

    float GetInterpolation(int x)
    {
        float a = startTexture.GetPixel(x, 0).r;
        float b = endTexture.GetPixel(x, 0).r;
        
        return Mathf.Lerp(a, b, interpolation);
    }
    // Update is called once per frame
    void Update()
    {
        if (doSetup)
        {
            Setup();
            doSetup = false; 
        }
        ApplyInterpolation();
    }
    
    
}
