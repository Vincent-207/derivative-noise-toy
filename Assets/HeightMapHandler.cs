using UnityEngine;

public class HeightMapHandler : MonoBehaviour
{
    [SerializeField]
    ComputeHandlerPlus2D computeHandler;
    [SerializeField] Material mat;
    [SerializeField]
    RenderTexture my_rt;

    void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    public void ApplyHeightMap(RenderTexture heightmap)
    {
       
        mat.mainTexture = heightmap;
        mat.SetTexture("_HeightMap", heightmap);
        // mat.SetTexture("_BaseMap", rt);
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        // bounds.size = new Vector3(mesh.bounds.size.x, mesh.bounds.size.y, 100);
        bounds.extents = new Vector3(mesh.bounds.extents.x, mesh.bounds.extents.y, 100);
        // Debug.Log("Bounds; " + mesh.bounds);
        mesh.bounds = bounds;
        
    }
}
