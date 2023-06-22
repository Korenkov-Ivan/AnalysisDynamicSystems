using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.AbstructCalculate;

/// <summary>
/// Абстрактный класс для исчислений
/// </summary>
/// <typeparam name="TDynamicSystem">Тип динамической системы</typeparam>
/// <typeparam name="TResult">Тип результата</typeparam>
/// <typeparam name="TActivate">Тип передаваемых параметров</typeparam>
public abstract class Calculate<TDynamicSystem, TResult, TActivate>
// TODO здесь надо поставить ограничения на типы
{
    /// <summary>
    /// Динамическая система
    /// </summary>
    public DynamicSystem<TDynamicSystem> CurrentDynamicSystem { get; protected set; }
    
    public Calculate(DynamicSystem<TDynamicSystem> dynamicSystem)
    {
        CurrentDynamicSystem = dynamicSystem;
    }
    /// <summary>
    /// Акт вычисления
    /// </summary>
    /// <param name="item">Передаваемые параметры</param>
    /// <returns>Результат</returns>
    public abstract TResult Activate(TActivate item);
    /// <summary>
    /// Акт вычисления
    /// </summary>
    /// <returns>Результат</returns>
    public abstract TResult Activate();
}