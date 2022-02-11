using UnityEngine;
using UnityEngine.Events;

public class SelectionsComparer : MonoBehaviour
{
    [SerializeField] private ObjectsSelector _selector;

    private bool _canCombineTriangleAndSquare = true;

    public UnityAction OnCubeAndCircleCollect;
    public UnityAction OnCubeSizeDecreaseCollect;

    public void StopCombineTriangleWithCube() =>
        _canCombineTriangleAndSquare = false;

    public void StartCombineTriangleWithCube() =>
        _canCombineTriangleAndSquare = true;

    private void CheckSelections(ISelectableObject first, ISelectableObject second)
    {
        if ((first is Cube) && (second is Circle))
        {
            if (((Cube)first).GetSize() <= ((Circle)second).GetSize())
            {
                first.GetTransform().position = second.GetTransform().position;
                first.Lock();
                second.Lock();
                OnCubeAndCircleCollect?.Invoke();
            }
        }
        if (_canCombineTriangleAndSquare)
        {
            if ((first is Triangle) && (second is Cube))
            {
                ((Cube)second).DecreaseSize();
                first.Lock();
                OnCubeSizeDecreaseCollect?.Invoke();
            }
        }
    }

    private void OnEnable() =>
        _selector.OnTwoSelections += CheckSelections;

    private void OnDisable() =>
        _selector.OnTwoSelections -= CheckSelections;
}
