using System.Numerics;

namespace ADS.Core;

/// <summary>
/// Динамическая система
/// </summary>
public abstract class DynamicSystemsThree
{
    /// <summary>
    /// Наименование динамической системы
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Размерность
    /// </summary>
    public byte Dimension { get; private set; }
    /// <summary>
    /// Уравнение проекции скорости на ось OX
    /// </summary>
    /// <param name="vector">Начальный вектор</param>
    /// <returns>Проекция значения скорости на ось OX</returns>
    public abstract float Fx(Vector3 vector);
    /// <summary>
    /// Уравнение проекции скорости на ось OY
    /// </summary>
    /// <param name="vector">Начальный вектор</param>
    /// <returns>Проекция значения скорости на ось OY</returns>
    public abstract float Fy(Vector3 vector);
    /// <summary>
    /// Уравнение проекции скорости на ось OZ
    /// </summary>
    /// <param name="vector">Начальный вектор</param>
    /// <returns>Проекция значения скорости на ось OZ</returns>
    public abstract float Fz(Vector3 vector);

    public Vector3 NextVector(Vector3 vector, float steap)
    {
        throw new Exception();
    }
}