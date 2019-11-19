using UnityEngine;
using System.Collections;
using System;

namespace BT.Variables
{
    [Serializable]
    public class FloatReference
    {
        public bool useConstant = true;
        public float constantValue;

        public FloatVariable variable;

        public FloatReference() { }

        public FloatReference(float value)
        {
            useConstant = true;
            constantValue = value;
        }

        public float value
        {
            get { return useConstant ? constantValue : variable.value;  }
        }

        public void SetValue(float newValue)
        {
            if (useConstant)
            {
                constantValue = newValue;
            }
            else
            {
                variable.value = newValue;
            }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.value;
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}