using System.Numerics;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.DynamicSystems;

public class ShimizyMoriokaDynamicSystem: DynamicSystemThree
{
    public const string
        LAMBDA = "Lambda",
        ALPHA = "Alphs";
    private const string
        NAME_DYNAMIC_SYSTEM = "Система Шимицу-Мориока";

    private const float
        DEFAULT_LAMBDA = 1f,
        DEFAULT_ALPHA = 0.8f;

    public override float Fx(Vector3 v) => v.Y;
    public override float Fy(Vector3 v) => v.X - this[LAMBDA] * v.Y - v.X * v.Z;
    public override float Fz(Vector3 v) => -this[ALPHA] * v.Z + v.X * v.X;

    public ShimizyMoriokaDynamicSystem()
        :base(NAME_DYNAMIC_SYSTEM)
    {
        Parametr = new()
        {
            {LAMBDA, DEFAULT_LAMBDA},
            {ALPHA, DEFAULT_ALPHA},
        };
    }

}