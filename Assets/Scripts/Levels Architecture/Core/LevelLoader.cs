using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelsPool _levelsPool;

    private Level _currentLevel;

    public UnityAction<Level> OnLoadNewLevel;

    public void Load(Level level)
    {
        if (_currentLevel == level)
            return;
        OnLoadNewLevel?.Invoke(level);
        _levelsPool.HideAllLevels();
        level.gameObject.SetActive(true);
    }
}
