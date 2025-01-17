using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Barrage;

internal sealed class BitSet
{
    const int BitSize = (sizeof(uint) * 8) - 1;
    const int IndexSize = 5;
    static readonly int padding = Vector<uint>.Count;

    uint[] bits;
    int highestBit;
    int max;

    public BitSet()
    {
        bits = new uint[padding];
    }

    public BitSet(int capacity)
    {
        bits = new uint[capacity];
    }

    public BitSet(uint[] bits)
    {
        this.bits = bits;
    }

    public int Length => bits.Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Is(int index)
    {
        var b = index >> IndexSize;
        if (b >= bits.Length)
        {
            return false;
        }

        return (bits[b] & (1 << (index & BitSize))) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int index, bool value)
    {
        var b = index >> IndexSize;

        if (value)
        {
            if (b >= bits.Length)
            {
                Array.Resize(ref bits, (b + padding) / padding * padding);
            }

            highestBit = Math.Max(highestBit, index);
            max = (highestBit / (BitSize + 1)) + 1;
            bits[b] |= 1u << (index & BitSize);
        }
        else
        {
            if (b < bits.Length)
            {
                bits[b] &= ~(1u << (index & BitSize));
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetAll(bool value)
    {
        if (value)
        {
            for (var i = 0; i < bits.Length; i++)
            {
                bits[i] = 0xffffffff;
            }

            highestBit = (bits.Length * (BitSize + 1)) - 1;
            max = (highestBit / (BitSize + 1)) + 1;
        }
        else
        {
            Array.Clear(bits, 0, bits.Length);
            highestBit = 0;
            max = 0;
        }
    }

    public bool HasAll(BitSet other)
    {
        var min = Math.Min(Math.Min(Length, other.Length), max);
        if (!Vector.IsHardwareAccelerated || min < padding)
        {
            var bits = this.bits.AsSpan();
            var otherBits = other.bits.AsSpan();

            // Bitwise and
            for (var i = 0; i < min; i++)
            {
                var bit = bits[i];
                if ((bit & otherBits[i]) != bit)
                {
                    return false;
                }
            }

            // Handle extra bits on our side that might just be all zero.
            for (var i = min; i < max; i++)
            {
                if (bits[i] != 0)
                {
                    return false;
                }
            }
        }
        else
        {
            // Vectorized bitwise and
            for (var i = 0; i < min; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                var otherVector = new Vector<uint>(other.bits, i);

                var resultVector = Vector.BitwiseAnd(vector, otherVector);
                if (!Vector.EqualsAll(resultVector, vector))
                {
                    return false;
                }
            }

            // Handle extra bits on our side that might just be all zero.
            for (var i = min; i < max; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                if (!Vector.EqualsAll(vector, Vector<uint>.Zero)) // Vectors are not zero bits[0] != 0 basically
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool HasAny(BitSet other)
    {
        var min = Math.Min(Math.Min(Length, other.Length), max);
        if (!Vector.IsHardwareAccelerated || min < padding)
        {
            var bits = this.bits.AsSpan();
            var otherBits = other.bits.AsSpan();

            // Bitwise and, return true since any is met
            for (var i = 0; i < min; i++)
            {
                var bit = bits[i];
                if ((bit & otherBits[i]) > 0)
                {
                    return true;
                }
            }

            // Handle extra bits on our side that might just be all zero.
            for (var i = min; i < max; i++)
            {
                if (bits[i] > 0)
                {
                    return false;
                }
            }
        }
        else
        {
            // Vectorized bitwise and, return true since any is met
            for (var i = 0; i < min; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                var otherVector = new Vector<uint>(other.bits, i);

                var resultVector = Vector.BitwiseAnd(vector, otherVector);
                if (!Vector.EqualsAll(resultVector, Vector<uint>.Zero))
                {
                    return true;
                }
            }

            // Handle extra bits on our side that might just be all zero.
            for (var i = min; i < max; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                if (!Vector.EqualsAll(vector, Vector<uint>.Zero)) // Vectors are not zero bits[0] != 0 basically
                {
                    return false;
                }
            }
        }

        return highestBit <= 0;
    }

    public bool HasNone(BitSet other)
    {
        var min = Math.Min(Math.Min(Length, other.Length), max);
        if (!Vector.IsHardwareAccelerated || min < padding)
        {
            var bits = this.bits.AsSpan();
            var otherBits = other.bits.AsSpan();

            // Bitwise and, return true since any is met
            for (var i = 0; i < min; i++)
            {
                var bit = bits[i];
                if ((bit & otherBits[i]) != 0)
                {
                    return false;
                }
            }
        }
        else
        {
            // Vectorized bitwise and, return true since any is met
            for (var i = 0; i < min; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                var otherVector = new Vector<uint>(other.bits, i);

                var resultVector = Vector.BitwiseAnd(vector, otherVector);
                if (!Vector.EqualsAll(resultVector, Vector<uint>.Zero))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool HasExclusive(BitSet other)
    {
        var min = Math.Min(Math.Min(Length, other.Length), max);

        if (!Vector.IsHardwareAccelerated || min < padding)
        {
            var bits = this.bits.AsSpan();
            var otherBits = other.bits.AsSpan();

            // Bitwise xor, if both are not totally equal, return false
            for (var i = 0; i < min; i++)
            {
                var bit = bits[i];
                if ((bit ^ otherBits[i]) != 0)
                {
                    return false;
                }
            }

            // handle extra bits on our side that might just be all zero
            for (var i = min; i < max; i++)
            {
                if (bits[i] != 0)
                {
                    return false;
                }
            }
        }
        else
        {
            // Vectorized bitwise xor, return true since any is met
            for (var i = 0; i < min; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                var otherVector = new Vector<uint>(other.bits, i);

                var resultVector = Vector.Xor(vector, otherVector);
                if (!Vector.EqualsAll(resultVector, Vector<uint>.Zero))
                {
                    return false;
                }
            }

            // Handle extra bits on our side that might just be all zero.
            for (var i = min; i < max; i += padding)
            {
                var vector = new Vector<uint>(bits, i);
                if (!Vector.EqualsAll(vector, Vector<uint>.Zero)) // Vectors are not zero bits[0] != 0 basically
                {
                    return false;
                }
            }
        }

        return true;
    }

    public Span<uint> AsSpan()
    {
        var max = (highestBit / (BitSize + 1)) + 1;
        return MemoryMarshal.CreateSpan(ref bits[0], max);
    }

    public void CopyTo(BitSet destination)
    {
        destination.EnsureCapacity(bits.Length);
        bits.AsSpan().CopyTo(destination.bits);
        destination.highestBit = this.highestBit;
        destination.max = this.max;
    }

    public void EnsureCapacity(int minimumCapacity)
    {
        var capacity = Math.Max(bits.Length, padding);

        while (minimumCapacity > capacity)
        {
            capacity *= 2;
        }

        Array.Resize(ref bits, capacity);
    }

    public override string ToString()
    {
        return string.Concat(bits.Reverse().Select(x => Convert.ToString(x, 2)));
    }
}