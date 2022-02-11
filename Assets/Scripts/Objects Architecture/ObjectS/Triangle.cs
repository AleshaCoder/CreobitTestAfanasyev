using UnityEngine;

public class Triangle : MonoBehaviour, ISelectableObject
{
    [SerializeField] private bool _isAvailableForSelection = true;
    [SerializeField] private bool _hide = false;
    [SerializeField] private SelectionView selection;

    public Transform GetTransform() => transform;

    public bool IsAvailableForSelection() =>
        _isAvailableForSelection && !_hide;

    public void Lock()
    {
        _hide = true;
        gameObject.SetActive(false);
    }

    public void Select()
    {
        _isAvailableForSelection = false;
        selection.SetSecection(_isAvailableForSelection);
    }

    public void Unlock()
    {
        _hide = false;
        gameObject.SetActive(true);
    }

    public void Unselect()
    {
        _isAvailableForSelection = true;
        selection.SetSecection(_isAvailableForSelection);
    }
}
