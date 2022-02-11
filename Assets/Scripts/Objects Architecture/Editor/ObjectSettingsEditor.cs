using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectSettings)), CanEditMultipleObjects]
public class ObjectSettingsEditor : Editor
{
    private ObjectSettings _settings;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        _settings = (ObjectSettings)target;
        if (GUILayout.Button("Refresh all objects"))
        {
            _settings.RefreshAll();
        }
    }
}
