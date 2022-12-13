using System;

namespace Components.Abstract
{
    public interface IDeathComponent
    {
        event Action OnDie;
    }
}
