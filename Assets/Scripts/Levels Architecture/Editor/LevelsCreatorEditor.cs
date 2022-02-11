using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelsCreator)), CanEditMultipleObjects]
public class LevelsCreatorEditor : Editor
{
    private ObjectSettings _settings;
    private LevelsCreator _creator;
    private  int _levelIndex = 0;    

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();        

        var levels = _creator.LevelsPool.GetLevels() as List<Level>;

        DrawLevelsPopup(levels);

        levels = _creator.LevelsPool.GetLevels() as List<Level>;
        var currentLevel = levels[_levelIndex];

        ShowSelectedLevel(currentLevel);

        currentLevel.TriangleExtention.Use = GUILayout.Toggle(currentLevel.TriangleExtention.Use, "Triangle are availale");
        if (currentLevel.TriangleExtention.Use)
            currentLevel.TriangleExtention.Energy = EditorGUILayout.IntField("Energy", currentLevel.TriangleExtention.Energy);

        if (GUILayout.Button("Add New Level"))
        {
            var level = Instantiate(_creator.LevelPrefab, Vector2.zero, Quaternion.identity, _creator.LevelsPool.transform);
            level.name = "Level " + levels.Count;
            level.SetPrefabs(_creator.CubePrefab, _creator.CirclePrefab, _creator.TrianglePrefab);
            _creator.LevelsPool.AddLevel(level);
            Selection.activeObject = level;
        }

        if (currentLevel == null)
            return;

        if (GUILayout.Button("Add Cube"))
        {
            var cube = Instantiate(_creator.CubePrefab, Vector2.zero, Quaternion.identity, currentLevel.transform);
            _settings.RefreshAll();
            Selection.activeObject = cube;
        }

        if (GUILayout.Button("Add Circle"))
        {
            var circle = Instantiate(_creator.CirclePrefab, Vector2.zero, Quaternion.identity, currentLevel.transform);
            _settings.RefreshAll();
            Selection.activeObject = circle;
        }

        if (currentLevel.TriangleExtention.Use)
        {
            if (GUILayout.Button("Add Triangle"))
            {
                var triangle = Instantiate(_creator.TrianglePrefab, Vector2.zero, Quaternion.identity, currentLevel.transform);
                _settings.RefreshAll();
                Selection.activeObject = triangle;
            }
        }
    }

    private void DrawLevelsPopup(IReadOnlyCollection<Level> levels)
    {
        var levelNames = new List<string>();
        foreach (var item in levels)
        {
            if (item == null)
            {
                _creator.LevelsPool.RemoveLevel(item);
                return;
            }
            levelNames.Add(item.name);
        }

        _levelIndex = EditorGUILayout.Popup(_levelIndex, levelNames.ToArray());
    }

    private void ShowSelectedLevel(Level level)
    {
        _creator.LevelsPool.HideAllLevels();
        level.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _creator?.LevelsPool?.HideAllLevels();
    }

    private void OnEnable()
    {
        _creator = (LevelsCreator)target;
        _settings = FindObjectOfType<ObjectSettings>();

        if (_settings == null)
            Debug.LogError("Object settings don't has active in current scene");
    }
}