using System;

namespace UnityEngine
{
    namespace UI
    {
        public class Text
        {
            public string text;
        }

        public class InputField : Text {}
    }

    public struct Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x*b.x, a.y*b.y, a.z*b.z, a.w*b.w);
        }

        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.x*b, a.y*b, a.z*b, a.w*b);
        }

        public float this[int a]
        {
            get
            {
                switch (a)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (a)
                {
                    case 0: x = a; break;
                    case 1: y = a; break;
                    case 2: z = a; break;
                    case 3: w = a; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z}, {w})";
        }

        public static Vector4 zero = new Vector4(0, 0, 0, 0);
    }

    public class Material
    {
        public int idx = 0;
        public byte[] binary;

        public void SetVectorArray(string a, Vector4[] b)
        {
            if (binary == null)
                binary = new byte[b.Length * 16 * 4];
            
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byte[] flt = BitConverter.GetBytes(b[i][j]);
                    binary[idx + i * 16 + j * 4 + 0] = flt[0];
                    binary[idx + i * 16 + j * 4 + 1] = flt[1];
                    binary[idx + i * 16 + j * 4 + 2] = flt[2];
                    binary[idx + i * 16 + j * 4 + 3] = flt[3];
                }
            }
            idx += b.Length;
        }
        public void SetVector(string a, Vector4 b) {}
    }
}

namespace VRC
{
    namespace SDKBase {}
    namespace SDK3
    {
        namespace Components {}
    }
    namespace Udon
    {
        namespace Common {}
    }
}

namespace UdonSharp
{
}

public class RecursiveMethodAttribute : Attribute {}
public class UdonSyncedAttribute : Attribute {}
public enum UdonInputEventArgs
{
    None
}

public class UdonSharpBehaviour
{
    public virtual void InputUse(bool a, UdonInputEventArgs b) {}
    public virtual void InputJump(bool a, UdonInputEventArgs b) {}
    public virtual void InputGrab(bool a, UdonInputEventArgs b) {}
    public virtual void InputDrop(bool a, UdonInputEventArgs b) {}
    public virtual void InputMoveHorizontal(float a, UdonInputEventArgs b) {}
    public virtual void InputMoveVertical(float a, UdonInputEventArgs b) {}
    public virtual void InputLookHorizontal(float a, UdonInputEventArgs b) {}
    public virtual void InputLookVertical(float a, UdonInputEventArgs b) {}
    public virtual void Interact() {}
    public virtual void OnDeserialization() {}
}