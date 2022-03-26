using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(BrakeWing))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BrakeWing myScript = (BrakeWing)target;
        if (GUILayout.Button("DestroyWing"))
        {
            myScript.DestroyWing();
        }
    }

}
