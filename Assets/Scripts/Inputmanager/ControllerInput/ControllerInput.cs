using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matthias.ControllerInput
{
    /// <summary>Interface into the Input system.</summary>
    public static class ControllerInput
    {
        private static List<ContollerProfile> controllerProfiles;

        static ControllerInput()
        {
            controllerProfiles = new List<ContollerProfile>();

            string[] controllerNames = Input.GetJoystickNames();

            int controllerCount = controllerNames.Length;
            for (int i = 0; i < controllerCount; i++)
            {
                string controllerName = controllerNames[i];
                Debug.Log("Found device: " + controllerName);

                ContollerProfile profile = new ContollerProfile(controllerName, i + 1);
                Debug.Log("Using profile: " + profile.Name);

                controllerProfiles.Add(profile);
            }
        }

        /// <summary>Returns the value of the axis identified by axisName.</summary>
        /// <param name="axisName">The name of the axis.</param>
        /// <returns>The value of the axis.</returns>
        public static float GetAxes(ControllerdAxis axisName)
        {
            float result = 0f;
            float temp = 0f;
            int count = controllerProfiles.Count;

            for (int i = 0; i < count; i++)
            {
                var axis = controllerProfiles[i].Axis;
                temp = Axis.GetAxis(axis[(int)axisName]);

                if (Mathf.Abs(temp) > Mathf.Abs(result))
                {
                    result = temp;
                }
            }

            return result;
        }

        /// <summary>Returns the value of the virtual axis identified by key1Name and key2Name.</summary>
        /// <param name="key1Name">The name of the positive key.</param>
        /// <param name="key2Name">The name of the negative key.</param>
        /// <returns>The value of the virtual axis.</returns>
        public static float GetVirtualAxes(KeyCode key1Name, KeyCode key2Name)
        {
            bool value1 = Input.GetKey(key1Name);
            bool value2 = Input.GetKey(key2Name);

            int result = value1.CompareTo(value2);
            result = Mathf.Clamp(result, -1, 1);

            return result;
        }

        /// <summary>Returns true while the button identified by buttonName is held down.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been pressed and not released.</returns>
        public static bool GetButton(ControllerButton buttonName)
        {
            bool result = false;
            int count = controllerProfiles.Count;

            for (int i = 0; i < count; i++)
            {
                var btn = controllerProfiles[i].Buttons;
                if (result = Button.GetButton(btn[(int)buttonName]))
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>Returns true during the frame the user pressed down the button identified by buttonName.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been pressed.</returns>
        public static bool GetButtonDown(ControllerButton buttonName)
        {
            bool result = false;
            int count = controllerProfiles.Count;

            for (int i = 0; i < count; i++)
            {
                var btn = controllerProfiles[i].Buttons;
                if (result = Button.GetButtonDown(btn[(int)buttonName]))
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>Returns true the first frame the user releases the button identified by buttonName.</summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <returns>True when an button has been released.</returns>
        public static bool GetButtonUp(ControllerButton buttonName)
        {
            bool result = false;
            int count = controllerProfiles.Count;

            for (int i = 0; i < count; i++)
            {
                var btn = controllerProfiles[i].Buttons;
                if (result = Button.GetButtonUp(btn[(int)buttonName]))
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>Returns true while the key identified by keyName is held down.</summary>
        /// <param name="keyName">The name of the key.</param>
        /// <returns>True when an key has been pressed and not released.</returns>
        public static bool GetKey(KeyCode keyName)
        {
            bool result = false;
            result = Input.GetKey(keyName);

            return result;
        }

        /// <summary>Returns true during the frame the user pressed down the key identified by keyName.</summary>
        /// <param name="keyName">The name of the key.</param>
        /// <returns>True when an key has been pressed.</returns>
        public static bool GetKeyDown(KeyCode keyName)
        {
            bool result = false;
            result = Input.GetKeyDown(keyName);

            return result;
        }

        /// <summary>Returns true the first frame the user releases the key identified by keyName.</summary>
        /// <param name="keyName">The name of the key.</param>
        /// <returns>True when an key has been released.</returns>
        public static bool GetKeyUp(KeyCode keyName)
        {
            bool result = false;
            result = Input.GetKeyUp(keyName);

            return result;
        }
    }
}
