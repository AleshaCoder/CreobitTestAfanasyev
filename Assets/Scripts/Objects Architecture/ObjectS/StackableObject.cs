using UnityEngine;

public abstract class StackableObject : MonoBehaviour, IObjectWithIntSize, ISelectableObject
{
    [SerializeField] protected int _size;
    [SerializeField] private bool _isAvailableForSelection = true;
    [SerializeField] private bool _isLocked = false;
    [SerializeField] private SelectionView selection;

    protected float SizeScaleToUnitySize;

    public int Size => _size;

    public int GetSize() => Size;

    public Transform GetTransform() => transform;

    public bool IsAvailableForSelection() => _isAvailableForSelection && !_isLocked;

    public void CompareAndChangeUnityScale(float scale)
    {
        if (SizeScaleToUnitySize != scale)
            SizeScaleToUnitySize = scale;
        RefreshSize();
    }

    public void RefreshSize()
    {
        float newSize = _size * SizeScaleToUnitySize;
        transform.localScale = new Vector3(newSize, newSize, 1);
    }

    public void Select()
    {
        _isAvailableForSelection = false;
        selection.SetSecection(_isAvailableForSelection);
    }

    public void Unselect()
    {
        _isAvailableForSelection = true;
        selection.SetSecection(_isAvailableForSelection);
    }

    public void Lock()
    {
        _isLocked = true;
        selection.SetSecection(_isAvailableForSelection);
    }

    public void Unlock()
    {
        _isLocked = false;
        selection.SetSecection(_isAvailableForSelection);
    }

    private void Awake() => RefreshSize();

#if UNITY_EDITOR
    private void OnValidate() => RefreshSize();
#endif
}