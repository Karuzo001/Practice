namespace Objects
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}