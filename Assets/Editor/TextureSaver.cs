using System;
using UnityEditor;
using UnityEngine;
[ExecuteInEditMode]
public class TextureSaver : MonoBehaviour
{
    public String assetName = "myTexture";

    public bool doSave;
    

    void DoSave()
    {
        Texture2D tex = GetComponent<ITextureHolder>().GetTexture2D();
        AssetDatabase.CreateAsset(tex, "Assets/" + assetName + ".asset");
        AssetDatabase.SaveAssets();
        doSave = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (doSave)
        {
            DoSave();
        }   
    }
}
