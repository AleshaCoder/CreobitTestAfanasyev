using UnityEngine;

public interface ILevelExtension
{
}

[System.Serializable]
public class TriangleExtension : ILevelExtension
{
    [SerializeField] private Triangle _trianglePrefab;
    public bool Use;
    public int Energy;

    public Triangle TrianglePrefab => _trianglePrefab;

    public void SetPrefabs(Triangle triangle) =>
        _trianglePrefab = triangle;
}
