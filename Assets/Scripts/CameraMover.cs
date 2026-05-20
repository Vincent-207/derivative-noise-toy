using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Vector3 oneDPos, twoDPos;
    public Vector3 oneDRot, twoDRot;
    [SerializeField]
    private float twoDAnimDuration,oneDAnimDuration;
    [SerializeField]
    private GameObject[] oneDObjs;
    void Start()
    {
        MoveTo2D();
    }

    public void MoveTo1D()
    {
        StartCoroutine(LerpBetween(oneDAnimDuration, transform.position, oneDPos, transform.rotation.eulerAngles, oneDRot));
        SetObjectsActive(oneDObjs, true);
        
    }
    public void MoveTo2D()
    {
        StartCoroutine(LerpBetween(twoDAnimDuration, transform.position, twoDPos,transform.rotation.eulerAngles, twoDRot));
        SetObjectsActive(oneDObjs, false);
    }

    IEnumerator LerpBetween(float duration, Vector3 fromPos, Vector3 toPos, Vector3 fromRot, Vector3 toRot)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            float p = t/duration;
            transform.position = Vector3.Lerp(fromPos, toPos, p);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(fromRot, toRot, p));
            yield return null;
        }
        
        transform.position = toPos;
        transform.rotation = Quaternion.Euler(toRot);
    }

    void SetObjectsActive(GameObject[] objs, bool active)
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(active);
        }
    }
}
