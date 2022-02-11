using System.Collections.Generic;
using UnityEngine;

public class LevelsPool : MonoBehaviour
{
    [SerializeField] private List<Level> _levels = new List<Level>();

    public void AddLevel(Level level) => _levels.Add(level);

    public void RemoveLevel(Level level) => _levels.Remove(level);

    public IReadOnlyCollection<Level> GetLevels() => _levels;

    public void HideAllLevels()
    {
        foreach (var item in _levels)
        {
            item.gameObject.SetActive(false);
        }
    }

#if UNITY_EDITOR
    public void ClearLevels()
    {
        if (Application.isPlaying == false)
            _levels.Clear();
    }
#endif

}
