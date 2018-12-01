using System.Collections.Generic;
using UnityEngine;
using Matthias.Inputmanager;

namespace Matthias
{
    public static class CInput
    {
        private static Dictionary<int, ControllerAxis> controllerAxes;
        private static Dictionary<int, ControllerButton> controllerButtons;

        private static Dictionary<int, string> buttons;
        private static Dictionary<int, string> axes;

        private static ControllerInput controllerInput;

        static CInput()
        {
            controllerInput = new ControllerInput();

            ControllerBindings();
            KeyBindings();
        }

        private static void ControllerBindings()
        {
            controllerAxes = new Dictionary<int, ControllerAxis>
            {
                {(int)CAxis.MoveHorizontal, ControllerAxis.LStick_X },
                {(int)CAxis.MoveVertical, ControllerAxis.LStick_Y },
                {(int)CAxis.CameraHorizontal, ControllerAxis.RStick_X },
                {(int)CAxis.CameraVertical, ControllerAxis.RStick_Y },
            };

            controllerButtons = new Dictionary<int, ControllerButton>
            {
                {(int)CButton.Jump, ControllerButton.Action_Right },
            };
        }

        private static void KeyBindings()
        {
            axes = new Dictionary<int, string>
            {
                {(int)CAxis.MoveHorizontal, "Horizontal" },
                {(int)CAxis.MoveVertical, "Vertical" },
                {(int)CAxis.CameraHorizontal, "Mouse X" },
                {(int)CAxis.CameraVertical, "Mouse Y" },
            };

            buttons = new Dictionary<int, string>
            {
                { (int)CButton.Jump, "Jump" },
            };
        }

        /// <summary>Returns the value of the virtual axis identified by axisName.</summary>
        /// <param name="axisName">The name of the axis.</param>
        /// <returns>The value of the axis.</returns>
        public static float GetAxis(CAxis axisName)
        {
            float value = controllerInput.GetAxis(controllerAxes[(int)axisName]);
            return value;
        }

        /// <summary>Returns true while the virtual button identified by buttonName is held down.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been pressed and not released.</returns>
        public static bool GetButton(CButton buttonName)
        {
            bool value = controllerInput.GetButton(controllerButtons[(int)buttonName]);
            return value;
        }

        /// <summary>Returns true during the frame the user pressed down the virtual button identified by buttonName.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been pressed.</returns>
        public static bool GetButtonDown(CButton buttonName)
        {
            bool value = controllerInput.GetButtonDown(controllerButtons[(int)buttonName]);
            return value;
        }

        /// <summary>Returns true the first frame the user releases the virtual button identified by buttonName.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been released.</returns>
        public static bool GetButtonUp(CButton buttonName)
        {
            bool value = controllerInput.GetButtonUp(controllerButtons[(int)buttonName]);
            return value;
        }

        /// <summary>Returns true while the key identified by key is held down.</summary>
        /// <param name="key">The name of the key.</param>
        /// <returns>True when an key has been pressed and not released.</returns>
        public static bool GetKey(KeyCode key)
        {
            bool value = Input.GetKey(key);
            return value;
        }

        /// <summary>Returns true during the frame the user pressed down the key identified by key.</summary>
        /// <param name="key">The name of the key.</param>
        /// <returns>True when an key has been pressed.</returns>
        public static bool GetKeyDown(KeyCode key)
        {
            bool value = Input.GetKeyDown(key);
            return value;
        }

        /// <summary>Returns true the first frame the user releases the key identified by key.</summary>
        /// <param name="key">The name of the key.</param>
        /// <returns>True when an key has been released.</returns>
        public static bool GetKeyUp(KeyCode key)
        {
            bool value = Input.GetKeyUp(key);
            return value;
        }
    }
}
