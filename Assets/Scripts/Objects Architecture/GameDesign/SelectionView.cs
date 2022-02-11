using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SelectionView : MonoBehaviour
{    
    [SerializeField] private Color _selectedColor;

    private SpriteRenderer _renderer;
    private Color _standartColor;

    public void ChangeSelectedMaterial(Color color) =>
        _selectedColor = color;
    
    public void SetSecection(bool isNotSelected)
    {
        if (isNotSelected == false)
            _renderer.color = _selectedColor;
        else
            _renderer.color = _standartColor;
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _standartColor = _renderer.color;
    }
}
