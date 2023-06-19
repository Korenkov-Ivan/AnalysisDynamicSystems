using System.Numerics;
using ADS.Core.AbstructDynamicSystem;

namespace ADS.Core.Test.AbstructDynamicSystem;

public class DynamicSystemThreeTest
{
    // [SetUp]
    // public void Setup()
    // {
    // }

    [Test]
    public void Test1()
    {
        // Actual
        var a = new A();
        var steap = 0.001f;
        var result = new Vector3(1, 1, 1);

        // Act
        for (var i = 0; i < 1000; i++)
        {
            result = a.NextVector(result, steap);
        }
        Console.WriteLine(result.X);
        // Assert
        Assert.IsTrue(Math.Abs(result.X - Math.E) < 0.01);
    }

    class A : DynamicSystemThree
    {
        public override float Fx(Vector3 vector) => vector.X;
        public override float Fy(Vector3 vector) => vector.Y;
        public override float Fz(Vector3 vector) => vector.Z;
    }
}