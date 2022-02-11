using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSettings : MonoBehaviour
{
    [SerializeField] private float _sizeScaleToUnitySize = 1;
    [SerializeField] private Color _selectedColor;

    public void RefreshAll()
    {
        GetAllObjectsAndSetScale();
        GetAllSelectionViewAndChangeSelectedColor();
    }

    private void GetAllSelectionViewAndChangeSelectedColor()
    {
        var selectionViews = new List<SelectionView>(FindObjectsOfType<SelectionView>(true));
        foreach (var item in selectionViews)
        {
            item.ChangeSelectedMaterial(_selectedColor);
        }
    }

    private void GetAllObjectsAndSetScale()
    {
        var _objectsWithIntSize = new List<StackableObject>(FindObjectsOfType<StackableObject>(true));
        foreach (var item in _objectsWithIntSize)
        {
            item.CompareAndChangeUnityScale(_sizeScaleToUnitySize);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        RefreshAll();
    }
#endif

    private void Awake()
    {
        RefreshAll();
    }
}
