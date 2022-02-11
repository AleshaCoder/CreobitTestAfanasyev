using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectsSelector : MonoBehaviour
{
    private ISelectableObject _firstObject;
    private ISelectableObject _secondObject;
    private Camera _camera;

    public UnityAction<ISelectableObject, ISelectableObject> OnTwoSelections;

    public void ResetSelections()
    {
        _firstObject.Unselect();
        _secondObject.Unselect();
        _firstObject = null;
        _secondObject = null;
    }

    private bool TryAddSelection(ISelectableObject selectable)
    {
        if (_firstObject == selectable)
        {
            _firstObject.Unselect();
            _firstObject = null;
            return false;
        }

        if (selectable.IsAvailableForSelection())
        {
            if (_firstObject == null)
            {
                _firstObject = selectable;
                _firstObject.Select();
                return true;
            }
            else if (_secondObject == null)
            {
                _secondObject = selectable;
                _secondObject.Select();
                OnTwoSelections?.Invoke(_firstObject, _secondObject);
                ResetSelections();
                return true;
            }
        }
        return false;
    }

    private bool TryFindClickedObject()
    {
        Vector2 worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out ISelectableObject selectable))
            {
                TryAddSelection(selectable);
                return true;
            }
        }
        return false;
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryFindClickedObject();
        }
    }
}
