using System.Numerics;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.DynamicSystems;

public class ShimizyMoriokaDynamicSystem: DynamicSystemThree
{
    public override float Fx(Vector3 v) => v.Y;
    public override float Fy(Vector3 v) => v.X - parametrs[LAMBDA] * v.Y - v.X * v.Z;
    public override float Fz(Vector3 v) => -parametrs[ALPHA] * v.Z + v.X * v.X;

}