using UnityEngine;

namespace Matthias.ControllerInput
{
    public struct Axis
    {
        public string AxisName { get; set; }
        public bool IsInverted { get; set; }

        public int MaxValue { get; set; }
        public int MinValue { get; set; }

        public bool IsVirtual { get; set; }
        public string PositiveButton { get; set; }
        public string NegativeButton { get; set; }

        public static float GetAxis(Axis axis)
        {
            float result = 0f;

            if (axis.IsVirtual)
            {
                bool pB = false, nB = false;
                if (!string.IsNullOrEmpty(axis.PositiveButton))
                {
                    pB = Input.GetButton(axis.PositiveButton);
                }
                if (!string.IsNullOrEmpty(axis.NegativeButton))
                {
                    nB = Input.GetButton(axis.NegativeButton);
                }
                result = pB.CompareTo(nB);
            }
            else
            {
                float value = 0f;
                value = Input.GetAxisRaw(axis.AxisName);
                if (axis.IsInverted)
                {
                    value *= -1f;
                }
                result = value;
            }

            return result;
        }

        public static float GetAxis(Axis axis, float newMax, float newMin)
        {
            float result = GetAxis(axis);

            float oldRange = axis.MaxValue - axis.MinValue;
            if (oldRange == 0)
            {
                result = newMin;
            }
            else
            {
                float newRange = newMax - newMin;
                result = ((result - axis.MinValue) * newRange / oldRange) + newMin;
            }

            return result;
        }
    }
}
