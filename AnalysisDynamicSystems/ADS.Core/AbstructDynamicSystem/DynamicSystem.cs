namespace ADS.Core.AbstructDynamicSystem;
/// <summary>
/// Динамическая система
/// </summary>
/// <typeparam name="T">Вектор</typeparam>
public abstract class DynamicSystem<T>
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
    /// Метод интеграции дифференциального уравнения
    /// </summary>
    /// <param name="vector">Начальный вектор</param>
    /// <param name="steap">Шаг интегрирования</param>
    /// <returns>Конечный вектор</returns>
    public abstract T NextVector(T vector, float steap);
}