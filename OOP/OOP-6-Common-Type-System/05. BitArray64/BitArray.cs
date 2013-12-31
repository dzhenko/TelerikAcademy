using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

public class BitArray : IComparable<BitArray>, IEnumerable<int>
{
    private ulong num;

    public BitArray() { }

    public int this[int position]
    {
        get
        {
            if (position < 0 || position > 63)
            {
                throw new ArgumentException("Invalid position !");
            }
            return (int)((this.num >> position) & 1);
        }
        set
        {
            if (position < 0 || position > 63)
            {
                throw new ArgumentException("Invalid position !");
            }
            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Invalid value 0 or 1 only !");
            }
            if (value == 1)
            {
                this.num = this.num | ((ulong)1 << position);
            }
            else
            {
                this.num = this.num & (~((ulong)1 << position));
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 64; i++)
        {
            if (((this.num >> (63 - i)) & 1) == 1)
            {
                sb.Append(1);
            }
            else
            {
                sb.Append(0);
            }
        }
        return sb.ToString();
    }



    public int CompareTo(BitArray other)
    {
        return this.num.CompareTo(other.num);
    }

    public static bool operator ==(BitArray array1, BitArray array2)
    {
        return BitArray.Equals(array1, array2);
    }

    public static bool operator !=(BitArray array1, BitArray array2)
    {
        return !(BitArray.Equals(array1, array2));
    }

    public override bool Equals(object obj)
    {
        if (obj as BitArray == null)
        {
            return false;
        }
        BitArray arr2 = obj as BitArray;

        return this.num == arr2.num;
    }

    public override int GetHashCode()
    {
        return this.num.GetHashCode();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < 64; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}