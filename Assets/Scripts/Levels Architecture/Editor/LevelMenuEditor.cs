using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelsMenu)), CanEditMultipleObjects]
public class LevelMenuEditor : Editor
{
    private LevelsMenu _levelsMenu;
    private LevelsPool _levelsPool;
    private int _size = 0;

    private void OnEnable()
    {
        if (Application.isPlaying)
            return;
        _levelsMenu = (LevelsMenu)target;
        _levelsPool = FindObjectOfType<LevelsPool>();
        _levelsMenu.Levels.Clear();
        foreach (var item in _levelsPool.GetLevels())
        {
            _levelsMenu.Levels.Add(item);
        }
        _size = _levelsMenu.Levels.Count;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
            return;
        if (_size != _levelsMenu.Levels.Count)
        {
            _levelsMenu.Levels.Clear();
            foreach (var item in _levelsPool.GetLevels())
            {
                _levelsMenu.Levels.Add(item);
            }
        }
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Dont forget save levels combination!");
        if (GUILayout.Button("Load levels Again"))
        {
            _levelsMenu.Levels.Clear();
            foreach (var item in _levelsPool.GetLevels())
            {
                _levelsMenu.Levels.Add(item);
            }
        }

        if (GUILayout.Button("Save Changes"))
        {
            _levelsPool.ClearLevels();
            foreach (var item in _levelsMenu.Levels)
            {
                _levelsPool.AddLevel(item);
            }
        }

        base.OnInspectorGUI();
    }
}
