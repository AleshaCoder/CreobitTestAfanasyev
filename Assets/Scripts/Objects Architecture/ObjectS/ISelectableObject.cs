using UnityEngine;

public interface ISelectableObject
{
    public Transform GetTransform();
    public bool IsAvailableForSelection();
    public void Select();
    public void Unselect();
    public void Lock();
    public void Unlock();
}