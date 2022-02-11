public class Cube : StackableObject
{
    public void DecreaseSize()
    {
        _size--;
        RefreshSize();
    }
}
