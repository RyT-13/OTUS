using System;

namespace Core.Components.Abstract
{
    public interface IDeathComponent
    {
        event Action OnDie;
    }
}
