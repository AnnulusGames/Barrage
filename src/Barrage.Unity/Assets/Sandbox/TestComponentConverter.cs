using Barrage.Unity.Conversion;
using UnityEngine;

public class TestComponentConverter : MonoBehaviour, IComponentConverter
{
    [SerializeField] Vector3 value;

    public void Convert(IEntityConverter converter)
    {
        converter.AddComponent(new TestComponent() { Value = value });
    }
}

public struct TestComponent
{
    public Vector3 Value;
}
