namespace Core.Components.Abstract
{
    public interface IValueComponent<T>
    {
        T GetValue();
        void SetValue(T value);
    }
}
