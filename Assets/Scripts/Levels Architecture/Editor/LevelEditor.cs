using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level)), CanEditMultipleObjects]
public class LevelEditor : Editor
{
    private ObjectSettings _settings;
    private Level _thisLevel;

    public override void OnInspectorGUI()
    {       
        _thisLevel.TriangleExtention.Use = GUILayout.Toggle(_thisLevel.TriangleExtention.Use, "Triangle are availale");
        if (_thisLevel.TriangleExtention.Use)
        {
            _thisLevel.TriangleExtention.Energy = EditorGUILayout.IntField("Energy", _thisLevel.TriangleExtention.Energy);
        }
        if (GUILayout.Button("Add Cube"))
        {
            var cube = Instantiate(_thisLevel.CubePrefab, Vector2.zero, Quaternion.identity, _thisLevel.transform);
            _settings.RefreshAll();
            Selection.activeObject = cube;
        }
        if (GUILayout.Button("Add Circle"))
        {
            var circle = Instantiate(_thisLevel.CirclePrefab, Vector2.zero, Quaternion.identity, _thisLevel.transform);
            _settings.RefreshAll();
            Selection.activeObject = circle;
        }
        if (_thisLevel.TriangleExtention.Use)
        {
            if (GUILayout.Button("Add Triangle"))
            {
                var triangle = Instantiate(_thisLevel.TriangleExtention.TrianglePrefab, Vector2.zero, Quaternion.identity, _thisLevel.transform);
                _settings.RefreshAll();
                Selection.activeObject = triangle;
            }
        }
        //base.OnInspectorGUI();
    }

    private void OnDisable()
    {
        _thisLevel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _settings = FindObjectOfType<ObjectSettings>();
        _thisLevel = (Level)target;
        _thisLevel.gameObject.SetActive(true);

        if (_settings == null)
            Debug.LogError("Object settings don't has active in current scene");
    }
}
