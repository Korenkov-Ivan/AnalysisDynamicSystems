using ADS.Core.AbstructCalculate;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.Calculate;

public class LyapynovExponentCalculate: CalculateThree<float, LyapynovExponentParametrs>
{
    public LyapynovExponentCalculate(DynamicSystemThree dynamicSystem)
        : base(dynamicSystem) { }

    public override float Activate(LyapynovExponentParametrs item)
    {
        
    }
}

/// <summary>
/// Параметры для вычисления Ляпуновского показателя
/// </summary>
public class LyapynovExponentParametrs
{
    /// <summary>
    /// Шаг интегрирования
    /// </summary>
    public float Steap { get; set; } = 0.001f;

    /// <summary>
    /// Количество шагов интегрирования
    /// </summary>
    public uint CountIteration { get; set; } = 1_000_000;

    /// <summary>
    /// константа для сближения векторов
    /// </summary>
    public float Eps { get; set; } = 0.001f;
}