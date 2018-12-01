using System;
using System.Collections.Generic;
using System.Reflection;

namespace Matthias.Inputmanager
{
    public partial class ContollerProfile
    {
        public string Name { get; private set; }
        public IReadOnlyDictionary<int, Axis> Axis => axis;
        public IReadOnlyDictionary<int, Button> Buttons => buttons;

        private Dictionary<int, Axis> axis;
        private Dictionary<int, Button> buttons;

        private readonly string prefix;

        private Dictionary<string, Action> profiles;

        public ContollerProfile() : this("Default", 1) { }

        public ContollerProfile(string controllerName, int controllerNumber)
        {
            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "Default";
            }

            prefix = "joystick " + controllerNumber + " ";
            profiles = new Dictionary<string, Action>();

            MethodInfo[] methodInfo = typeof(ContollerProfile).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < methodInfo.Length; i++)
            {
                if (methodInfo[i].Name.Contains("Init"))
                {
                    methodInfo[i].Invoke(this, null);
                }
            }

            if (profiles.ContainsKey(controllerName))
            {
                profiles[controllerName].Invoke();
            }
            else
            {
                Default_Profile();
            }
        }

        private void Default_Profile_Init()
        {
            profiles.Add("", Default_Profile);
        }

        private void Default_Profile()
        {
            Name = "Default";

            axis = new Dictionary<int, Axis>
            {
                { 0, new Axis() { AxisName = prefix + "axis X", } }, // Left Stick X
                { 1, new Axis() { AxisName = prefix + "axis Y", IsInverted = true, } }, // Left Stick Y
                { 2, new Axis() { AxisName = prefix + "axis 4", } }, // Right Stick X
                { 3, new Axis() { AxisName = prefix + "axis 5", IsInverted = true, } }, // Richt Stick Y
                { 4, new Axis() { AxisName = prefix + "axis 9", } }, // Left Trigger
                { 5, new Axis() { AxisName = prefix + "axis 10", } }, // Right Trigger
                { 6, new Axis() { AxisName = prefix + "axis 6", } }, // DPad X
                { 7, new Axis() { AxisName = prefix + "axis 7", } }, // DPad Y
            };

            buttons = new Dictionary<int, Button>
            {
                { 0, new Button { ButtonName = prefix + "button 2" } }, // Action Left
                { 1, new Button { ButtonName = prefix + "button 0" } }, // Action Bottom
                { 2, new Button { ButtonName = prefix + "button 1" } }, // Action Right
                { 3, new Button { ButtonName = prefix + "button 3" } }, // Action Top
                { 4, new Button { ButtonName = prefix + "button 4" } }, // Left Bumper
                { 5, new Button { ButtonName = prefix + "button 5" } }, // Right Bumper
                { 6, new Button { IsVirtual = true, AxisName = "axis 9", FromePositiveAxis = true, } }, // Left Trigger
                { 7, new Button { IsVirtual = true, AxisName = "axis 10", FromePositiveAxis = true, } }, // Right Trigger
                { 8, new Button { ButtonName = prefix + "button 6" } }, // Select
                { 9, new Button { ButtonName = prefix + "button 7" } }, // Start
                { 10, new Button { ButtonName = prefix + "button 8" } }, // Left Stick
                { 11, new Button { ButtonName = prefix + "button 9" } }, // Right Stick
                { 12, new Button { IsVirtual = true, AxisName = prefix + "axis 6", FromeNegativeAxis = true, } }, // DPad Left
                { 13, new Button { IsVirtual = true, AxisName = prefix + "axis 7", FromeNegativeAxis = true, } }, // DPad Down
                { 14, new Button { IsVirtual = true, AxisName = prefix + "axis 6", FromePositiveAxis = true, } }, // DPad Right
                { 15, new Button { IsVirtual = true, AxisName = prefix + "axis 7", FromePositiveAxis = true, } }, // DPad Up
            };
        }
    }
}
