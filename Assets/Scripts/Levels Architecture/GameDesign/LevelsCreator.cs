using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelsCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Circle _circlePrefab;
    [SerializeField] private Triangle _trianglePrefab;
    [SerializeField] private Level _LevelPrefab;
    [SerializeField] private LevelsPool _levelsPool;
    public Cube CubePrefab => _cubePrefab;
    public Circle CirclePrefab => _circlePrefab;
    public Triangle TrianglePrefab => _trianglePrefab;
    public Level LevelPrefab => _LevelPrefab;
    public LevelsPool LevelsPool => _levelsPool;
}
