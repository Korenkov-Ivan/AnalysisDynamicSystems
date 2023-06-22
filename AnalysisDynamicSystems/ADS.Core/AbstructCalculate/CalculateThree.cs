using System.Numerics;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.AbstructCalculate;

/// <summary>
/// Абстрактный класс для исчислений систем размерности 3
/// </summary>
/// <typeparam name="TResult">Тип результата</typeparam>
/// <typeparam name="TActivate">Тип передаваемых параметров</typeparam>
public abstract class CalculateThree<TResult, TActivate>: Calculate<Vector3, TResult, TActivate>
{
    public CalculateThree(DynamicSystemThree dynamicSystem)
        : base(dynamicSystem) { }
}