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
    /// Тип интеграции
    /// </summary>
    public TypeIntegration MethodIntegration { get; set; }

    public float this [string parametrName]
    {
        get
        {
            if (Parametr.TryGetValue(parametrName, out var parametr))
            {
                return parametr;
            }
            else
            {
                throw new Exception($"В системе {Name} нет параметра {parametrName}");
            }
        }
        set
        {
            if (Parametr.ContainsKey(parametrName))
            {
                Parametr[parametrName] = value;
            }
            else
            {
                throw new Exception($"В системе {Name} нет параметра {parametrName}");
            }
        }
    }
    protected Dictionary<string, float> Parametr;

    /// <summary>
    /// Метод интеграции дифференциального уравнения
    /// </summary>
    /// <param name="vector">Начальный вектор</param>
    /// <param name="steap">Шаг интегрирования</param>
    /// <returns>Конечный вектор</returns>
    public abstract T NextVector(T vector, float steap, TypeIntegration typeIntegration);
    public T NextVector(T vector, float steap) => NextVector(vector, steap, MethodIntegration);
    /// <summary>
    /// Возврашает стартовое положение вектора для системы
    /// </summary>
    /// <returns></returns>
    public abstract T GetDefaultStartVector();

    public DynamicSystem(string name, byte dimension, TypeIntegration typeIntegration)
    {
        Name = name;
        Dimension = dimension;
        MethodIntegration = typeIntegration;
    }
}