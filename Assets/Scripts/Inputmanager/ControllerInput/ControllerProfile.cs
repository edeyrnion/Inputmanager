using System;
using System.Collections.Generic;
using System.Reflection;

namespace Matthias.ControllerInput
{
    public class ContollerProfile
    {
        public string Name { get; private set; }
        public IReadOnlyDictionary<int, Axis> Axis => axis;
        public IReadOnlyDictionary<int, Button> Buttons => buttons;

        private Dictionary<int, Axis> axis;
        private Dictionary<int, Button> buttons;

        private string prefixA;
        private string prefixB;

        private Dictionary<string, Action> profiles;

        public ContollerProfile() : this("Default", 1) { }

        public ContollerProfile(string controllerName, int controllerNumber)
        {
            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "Default";
            }

            prefixA = "Joy" + controllerNumber + "_";
            prefixB = "joystick " + controllerNumber + " ";

            PS4_Profile();
        }

        private void Default_Profile()
        {
            Name = "Default";

            axis = new Dictionary<int, Axis>
            {
                { 0, new Axis() { AxisName = prefixA + "AxisX", } }, // Left Stick X
                { 1, new Axis() { AxisName = prefixA + "AxisY", IsInverted = true, } }, // Left Stick Y
                { 2, new Axis() { AxisName = prefixA + "Axis4", } }, // Right Stick X
                { 3, new Axis() { AxisName = prefixA + "Axis5", IsInverted = true, } }, // Richt Stick Y
                { 4, new Axis() { AxisName = prefixA + "Axis9", } }, // Left Trigger
                { 5, new Axis() { AxisName = prefixA + "Axis10", } }, // Right Trigger
                { 6, new Axis() { AxisName = prefixA + "Axis6", } }, // DPad X
                { 7, new Axis() { AxisName = prefixA + "Axis7", } }, // DPad Y
            };

            buttons = new Dictionary<int, Button>
            {
                { 0, new Button { ButtonName = prefixB + "button 2" } }, // Action Left
                { 1, new Button { ButtonName = prefixB + "button 0" } }, // Action Bottom
                { 2, new Button { ButtonName = prefixB + "button 1" } }, // Action Right
                { 3, new Button { ButtonName = prefixB + "button 3" } }, // Action Top
                { 4, new Button { ButtonName = prefixB + "button 4" } }, // Left Bumper
                { 5, new Button { ButtonName = prefixB + "button 5" } }, // Right Bumper
                { 6, new Button { IsVirtual = true, AxisName = "Axis9", FromePositiveAxis = true, } }, // Left Trigger
                { 7, new Button { IsVirtual = true, AxisName = "Axis10", FromePositiveAxis = true, } }, // Right Trigger
                { 8, new Button { ButtonName = prefixB + "button 6" } }, // Select
                { 9, new Button { ButtonName = prefixB + "button 7" } }, // Start
                { 10, new Button { ButtonName = prefixB + "button 8" } }, // Left Stick
                { 11, new Button { ButtonName = prefixB + "button 9" } }, // Right Stick
                { 12, new Button { IsVirtual = true, AxisName = "Axis6", FromeNegativeAxis = true, } }, // DPad Left
                { 13, new Button { IsVirtual = true, AxisName = "Axis7", FromeNegativeAxis = true, } }, // DPad Down
                { 14, new Button { IsVirtual = true, AxisName = "Axis6", FromePositiveAxis = true, } }, // DPad Right
                { 15, new Button { IsVirtual = true, AxisName = "Axis7", FromePositiveAxis = true, } }, // DPad Up
            };
        }

        private void PS4_Profile()
        {
            Name = "PS4 Dualshock";

            axis = new Dictionary<int, Axis>
            {
                { 0, new Axis() { AxisName = prefixA + "AxisX", } }, // Left Stick X
                { 1, new Axis() { AxisName = prefixA + "AxisY", IsInverted = true, } }, // Left Stick Y
                { 2, new Axis() { AxisName = prefixA + "Axis3", } }, // Right Stick X
                { 3, new Axis() { AxisName = prefixA + "Axis6", IsInverted = true, } }, // Richt Stick Y
                { 4, new Axis() { AxisName = prefixA + "Axis4", } }, // Left Trigger
                { 5, new Axis() { AxisName = prefixA + "Axis5", } }, // Right Trigger
                { 6, new Axis() { AxisName = prefixA + "Axis7", } }, // DPad X
                { 7, new Axis() { AxisName = prefixA + "Axis8", } }, // DPad Y
            };

            buttons = new Dictionary<int, Button>
            {
                { 0, new Button { ButtonName = prefixB + "button 0" } }, // Action Left
                { 1, new Button { ButtonName = prefixB + "button 1" } }, // Action Bottom
                { 2, new Button { ButtonName = prefixB + "button 2" } }, // Action Right
                { 3, new Button { ButtonName = prefixB + "button 3" } }, // Action Top
                { 4, new Button { ButtonName = prefixB + "button 4" } }, // Left Bumper
                { 5, new Button { ButtonName = prefixB + "button 5" } }, // Right Bumper
                { 6, new Button { ButtonName = prefixB + "button 6" } }, // Left Trigger
                { 7, new Button { ButtonName = prefixB + "button 7" } }, // Right Trigger
                { 8, new Button { ButtonName = prefixB + "button 8" } }, // Select
                { 9, new Button { ButtonName = prefixB + "button 9" } }, // Start
                { 10, new Button { ButtonName = prefixB + "button 10" } }, // Left Stick
                { 11, new Button { ButtonName = prefixB + "button 11" } }, // Right Stick
                { 12, new Button { IsVirtual = true, AxisName = prefixA + "Axis7", FromeNegativeAxis = true, } }, // DPad Left
                { 13, new Button { IsVirtual = true, AxisName = prefixA + "Axis8", FromeNegativeAxis = true, } }, // DPad Down
                { 14, new Button { IsVirtual = true, AxisName = prefixA + "Axis7", FromePositiveAxis = true, } }, // DPad Right
                { 15, new Button { IsVirtual = true, AxisName = prefixA + "Axis8", FromePositiveAxis = true, } }, // DPad Up
            };
        }
    }
}
