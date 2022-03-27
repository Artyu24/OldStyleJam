using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(BreakWing))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BreakWing myScript = (BreakWing)target;
        if (GUILayout.Button("DestroyWing"))
        {
            myScript.DestroyWing();
        }
    }

}
