using System.Numerics;
using ADS.Core.AbstructDynamicSystem;
using Moq;

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
        // Arrange
        var moqDynamicSystem = new Mock<DynamicSystemThree>();
        moqDynamicSystem
            .Setup(ds => ds.Fx(It.IsAny<Vector3>()))
            .Returns<Vector3>(r => r.X);
        moqDynamicSystem
            .Setup(ds => ds.Fy(It.IsAny<Vector3>()))
            .Returns<Vector3>(r => r.Y);
        moqDynamicSystem
            .Setup(ds => ds.Fz(It.IsAny<Vector3>()))
            .Returns<Vector3>(r => r.Z);
        var steap = 0.001f;
        var result = new Vector3(1, 1, 1);
        moqDynamicSystem.Object.MethodIntegration = TypeIntegration.EulerMethod;

        // Act
        for (var i = 0; i < 1000; i++)
        {
            result = moqDynamicSystem.Object.NextVector(result, steap);
        }
        Console.WriteLine(result.X);
        // Assert
        Assert.IsTrue(Math.Abs(result.X - Math.E) < 0.01);
    }

    // class A : DynamicSystemThree
    // {
    //     public override float Fx(Vector3 vector) => vector.X;
    //     public override float Fy(Vector3 vector) => vector.Y;
    //     public override float Fz(Vector3 vector) => vector.Z;
    //
    //     public override Vector3 GetDefaultStartVector()
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}