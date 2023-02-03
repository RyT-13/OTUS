namespace Core.Components.Abstract.Values
{
    public interface IValueComponent<T>
    {
        T GetValue();
        void SetValue(T value);
    }
}
