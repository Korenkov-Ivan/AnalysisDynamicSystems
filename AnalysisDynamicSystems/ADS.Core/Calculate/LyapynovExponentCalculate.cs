using System.Numerics;
using ADS.Core.AbstructCalculate;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.Calculate;

public class LyapynovExponentCalculate: CalculateThree<float, LyapynovExponentParametrs>
{
    public LyapynovExponentCalculate(DynamicSystemThree dynamicSystem)
        : base(dynamicSystem) { }
    /// <summary>
    /// Вычисляет старщий ляпуновский показатель
    /// </summary>
    /// <param name="item">Параметры для старшего ляпуновского показателя</param>
    /// <returns>Старший ляпуновский показатель</returns>
    public override float Activate(LyapynovExponentParametrs item)
    {
        Vector3
            vector = new Vector3(0.1f, 0, 0),
            closeVector = vector;
        var result = 0d;

        for (int i = 0; i < item.CountIteration; i++)
        {
            vector = CurrentDynamicSystem.NextVector(vector, item.Steap);
            closeVector = CurrentDynamicSystem.NextVector(closeVector, item.Steap);

            var lengthSeparet = (vector - closeVector).Length();

            result += Math.Log(lengthSeparet / item.Eps);

            if (result == double.PositiveInfinity || result == double.NegativeInfinity || result == double.NaN) return float.NaN;

            closeVector.X = vector.X + (closeVector.X - vector.X) / lengthSeparet * item.Eps;
            closeVector.Y = vector.Y + (closeVector.Y - vector.Y) / lengthSeparet * item.Eps;
            closeVector.Z = vector.Z + (closeVector.Z - vector.Z) / lengthSeparet * item.Eps;
        }
        return (float)result / (item.CountIteration * item.Steap);

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