using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Circle _circlePrefab;
    [SerializeField] private TriangleExtension _triangleExtention = new TriangleExtension();

    public Cube CubePrefab => _cubePrefab;
    public Circle CirclePrefab => _circlePrefab;
    public TriangleExtension TriangleExtention => _triangleExtention;

    public void SetPrefabs(Cube cube, Circle circle, Triangle triangle)
    {
        _cubePrefab = cube;
        _circlePrefab = circle;
        _triangleExtention.SetPrefabs(triangle);
    }
}
