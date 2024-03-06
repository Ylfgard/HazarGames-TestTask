using System;

namespace Roulette
{
    public interface IRouletteData
    {
        event Action<int> RolledValue;
    }
}