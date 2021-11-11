using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameObject obj= PrefabUtility.LoadPrefabContents("Assets/Cube.prefab");
        obj.AddComponent<Rigidbody>();
        PrefabUtility.SaveAsPrefabAsset(obj, "Assets/Cube.prefab");
    }

    
}
