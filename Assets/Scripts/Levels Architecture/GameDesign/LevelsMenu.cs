using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsMenu : MonoBehaviour
{
    public List<Level> Levels;
    [Space(100.1f)]
    [SerializeField] private LevelView _levelViewPrefab;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _content;
    [SerializeField] private LevelsPool _levelsPool;
    [SerializeField] private LevelLoader _levelLoader;

    private List<LevelView> _levelViews = new List<LevelView>();

    public void AddLevelViewOnScene(Level level)
    {
        var levelView = Instantiate(_levelViewPrefab, _content.transform);
        levelView.SetText((_levelViews.Count + 1).ToString());
        levelView.OnLevelViewClick.AddListener(() =>
        {
            _levelLoader.Load(level);
            HideMenu();
        });

        _levelViews.Add(levelView);
    }

    public void FillMenu(IReadOnlyCollection<Level> levels)
    {
        foreach (var item in _content.GetComponentsInChildren<LevelView>())
        {
            Destroy(item);
        }
        _levelViews.Clear();

        foreach (var item in levels)
        {
            AddLevelViewOnScene(item);
        }
    }

    private void HideMenu()
    {
        _menu.SetActive(false);
    }

    private void Awake()
    {
        FillMenu(Levels);
        _levelsPool.HideAllLevels();
    }
}
