using System;
using UnityEngine;

namespace Barrage.Unity.Conversion
{
    [Serializable]
    public record EntityConversionOptions
    {
        public static readonly EntityConversionOptions Default = new();

        [SerializeField] ConversionMode conversionMode;
        [SerializeField] bool convertUnityComponents;

        public ConversionMode ConversionMode
        {
            get => conversionMode;
            init => conversionMode = value;
        }

        public bool ConvertUnityComponents
        {
            get => convertUnityComponents;
            init => convertUnityComponents = value;
        }
    }
}