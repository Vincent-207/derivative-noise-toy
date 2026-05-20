using System.Collections;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    [SerializeField]
    Vector3 pos2D, pos3D, rot2D, rot3D;

    [SerializeField] private float to3DDuration, to2DDuration;
    public bool isBusy;
    public void DoTo3D()
    {
        if (isBusy) return;
        StartCoroutine(AnimTo3DPos(to3DDuration));
    }

    public void DoTo2D()
    {
        if (isBusy) return;
        StartCoroutine(AnimTo2DPos(to2DDuration));
    }
    
    IEnumerator AnimTo3DPos(float duration)
    {
        isBusy = true;
        float time = 0;
        Vector3 startPos = transform.position;
        Vector3 startRot = transform.rotation.eulerAngles;
        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, pos3D, time / duration);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, rot3D, time / duration));
            yield return null;
        }
        isBusy = false;
        
    }

    IEnumerator AnimTo2DPos(float duration)
    {
        isBusy = true;
        float time = 0;
        Vector3 startPos = transform.position;
        Vector3 startRot = transform.rotation.eulerAngles;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, pos2D, time / duration);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, rot2D, time / duration));
            yield return null;
        }
        isBusy = false;
    }
}
