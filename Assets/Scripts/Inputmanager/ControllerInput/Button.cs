using UnityEngine;

namespace Matthias.Inputmanager
{
    public struct Button
    {
        public string ButtonName { get; set; }

        public bool IsVirtual { get; set; }
        public string AxisName { get; set; }
        public bool IsInvertedAxis { get; set; }
        public bool FromePositiveAxis { get; set; }
        public bool FromeNegativeAxis { get; set; }

        public static bool GetButton(Button button)
        {
            bool result = false;

            if (button.IsVirtual)
            {
                float axisValue = Input.GetAxisRaw(button.AxisName);

                if (button.IsInvertedAxis)
                    axisValue *= -1f;

                if (button.FromePositiveAxis)
                    result = axisValue > 0.2f;

                if (button.FromeNegativeAxis)
                    result = axisValue < -0.2f;
            }
            else
            {
                result = Input.GetKey(button.ButtonName);
            }

            return result;
        }

        public static bool GetButtonUp(Button button)
        {
            bool result = false;

            if (button.IsVirtual)
            {

            }
            else
            {
                result = Input.GetKeyUp(button.ButtonName);
            }

            return result;
        }

        public static bool GetButtonDown(Button button)
        {
            bool result = false;

            if (button.IsVirtual)
            {

            }
            else
            {
                result = Input.GetKeyDown(button.ButtonName);
            }

            return result;
        }
    }
}
