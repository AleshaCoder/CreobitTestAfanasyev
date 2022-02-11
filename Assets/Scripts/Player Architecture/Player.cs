using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _moves;
    [SerializeField] private int _energy;
    [SerializeField] private SelectionsComparer _comparer;
    [SerializeField] private LevelLoader _loader;

    public int Moves => _moves;
    public int Energy => _energy;

    public UnityAction OnMovesChanged;
    public UnityAction OnEnergyChanged;

    private void SetEnergy(int energy)
    {
        _energy = energy;
        OnEnergyChanged?.Invoke();
    }

    private void UseLevelSettings(Level level)
    {
        if (level.TriangleExtention.Use == true)
        {
            _comparer.StartCombineTriangleWithCube();
            SetEnergy(level.TriangleExtention.Energy);
        }
        else
        {
            SetEnergy(0);
        }
    }

    private void AddMove()
    {
        _moves++;
        OnMovesChanged?.Invoke();
    }

    private void DecreaseEnergy()
    {
        _energy--;
        if (_energy == 0)
            _comparer.StopCombineTriangleWithCube();
        OnEnergyChanged?.Invoke();
    }

    private void OnEnable()
    {
        _loader.OnLoadNewLevel += UseLevelSettings;
        _comparer.OnCubeAndCircleCollect += AddMove;
        _comparer.OnCubeSizeDecreaseCollect += DecreaseEnergy;
    }

    private void OnDisable()
    {
        _loader.OnLoadNewLevel -= UseLevelSettings;
        _comparer.OnCubeAndCircleCollect -= AddMove;
        _comparer.OnCubeSizeDecreaseCollect += DecreaseEnergy;
    }
}
