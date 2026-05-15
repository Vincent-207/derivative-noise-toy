using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SetPosToScreen : MonoBehaviour
{
    void Start()
    {
        
        UpdatePos();
    }

    float GetLineLength(LineRenderer line)
    {
        return line.GetPosition(line.positionCount - 1).x;

    }

    float getHorizontalFOV(Camera cam)
    {
        var radAngle = cam.fieldOfView * Mathf.Deg2Rad;
        var radHFOV = 2 * Mathf.Atan(Mathf.Tan(radAngle / 2) * cam.aspect);
        var hFOV = Mathf.Rad2Deg * radHFOV;
        return hFOV;
    }

    float getLineDistance(float length, float angle)
    {
        Debug.Log("L: " + length);
        Debug.Log("Angle: " + angle);
        float tanPart = (2 * Mathf.Tan( Mathf.Deg2Rad * (angle/2)));
        Debug.Log("Tanpart: " + tanPart);
        return length / tanPart;
    }

    public void UpdatePos()
    {
        Camera cam = Camera.main;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        float distance = getLineDistance(GetLineLength(lineRenderer), getHorizontalFOV(cam));
        Debug.Log("Distance: " + distance);
        transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0.5f, distance));
        Debug.Log("Length: " + GetLineLength(lineRenderer));   
    }

}
