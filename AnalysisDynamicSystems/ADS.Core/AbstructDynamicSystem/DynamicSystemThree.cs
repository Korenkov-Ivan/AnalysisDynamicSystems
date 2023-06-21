using System.Numerics;

namespace ADS.Core.AbstructDynamicSystem;
/// <summary>
/// Динамическая система размерности 3
/// </summary>
public abstract class DynamicSystemThree: DynamicSystem<Vector3>
{
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

    public override Vector3 NextVector(Vector3 vector, float steap, TypeIntegration typeIntegration)
    {
        return typeIntegration switch
        {
            TypeIntegration.EulerMethod => NextVectorEuerMethod(vector, steap),
            _ => throw new Exception("Нет указанного метода интеграции")
        };
    }

    private Vector3 NextVectorEuerMethod(Vector3 vector, float steap)
    {
        return new Vector3()
        {
            X = vector.X + Fx(vector) * steap,
            Y = vector.Y + Fy(vector) * steap,
            Z = vector.Z + Fz(vector) * steap,
        };
    }

    private Vector3 NextVectorRyngeKytta(Vector3 vector, float steap)
    {
        if (
            float.IsNaN(steap) ||
            float.IsInfinity(steap) ||
            steap >= 10 ||
            steap < 0.00000001f)
            throw new Exception(nameof(steap));

        float[,] k = new float[4, 3];

        k[0, 0] = Fx(vector);
        k[0, 1] = Fy(vector);
        k[0, 2] = Fz(vector);

        k[1, 0] = Fx(new Vector3(vector.X + steap / 2, vector.Y + steap / 2 * k[0, 1], vector.Z + steap / 2 * k[0, 2]));
        k[1, 1] = Fy(new Vector3(vector.X + steap / 2 * k[0, 0], vector.Y + steap / 2, vector.Z + steap / 2 * k[0, 2]));
        k[1, 2] = Fz(new Vector3(vector.X + steap / 2 * k[0, 0], vector.Y + steap / 2 * k[0, 1], vector.Z + steap / 2));

        k[2, 0] = Fx(new Vector3(vector.X + steap / 2, vector.Y + steap / 2 * k[1, 1], vector.Z + steap / 2 * k[1, 2]));
        k[2, 1] = Fy(new Vector3(vector.X + steap / 2 * k[1, 0], vector.Y + steap / 2, vector.Z + steap / 2 * k[1, 2]));
        k[2, 2] = Fz(new Vector3(vector.X + steap / 2 * k[1, 0], vector.Y + steap / 2 * k[1, 1], vector.Z + steap / 2));

        k[3, 0] = Fx(new Vector3(vector.X + steap, vector.Y + steap * k[2, 1], vector.Z + steap * k[2, 2]));
        k[3, 1] = Fy(new Vector3(vector.X + steap * k[2, 0], vector.Y + steap, vector.Z + steap * k[2, 2]));
        k[3, 2] = Fz(new Vector3(vector.X + steap * k[2, 0], vector.Y + steap * k[2, 1], vector.Z + steap));

        vector.X += steap / 6 * (k[0, 0] + 2 * k[1, 0] + 2 * k[2, 0] + k[3, 0]);
        vector.Y += steap / 6 * (k[0, 1] + 2 * k[1, 1] + 2 * k[2, 1] + k[3, 1]);
        vector.Z += steap / 6 * (k[0, 2] + 2 * k[1, 2] + 2 * k[2, 2] + k[3, 2]);

        return vector;

    }
}