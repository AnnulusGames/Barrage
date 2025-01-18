using UnityEngine;

namespace Barrage.Unity.Conversion
{
    [AddComponentMenu("Barrage/Entity Converter")]
    public sealed class EntityConverter : MonoBehaviour
    {
        [SerializeField] EntityConversionOptions options;

        void Awake()
        {
            EntityConversion.Convert(gameObject, EntityConversion.DefaultWorld, options);
        }
    }
}