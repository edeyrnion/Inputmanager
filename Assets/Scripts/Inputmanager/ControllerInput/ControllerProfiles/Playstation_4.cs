using System.Collections.Generic;

namespace Matthias.Inputmanager
{
    public partial class ContollerProfile
    {
        private void Playstation_4_Profile_Init()
        {
            profiles.Add("Wireless Controller", Playstation_4_Profile);
        }

        private void Playstation_4_Profile()
        {
            Name = "Playstation 4";

            axis = new Dictionary<int, Axis>
            {
                { 0, new Axis() { AxisName = prefix + "axis X", } }, // Left Stick X
                { 1, new Axis() { AxisName = prefix + "axis Y", IsInverted = true, } }, // Left Stick Y
                { 2, new Axis() { AxisName = prefix + "axis 3", } }, // Right Stick X
                { 3, new Axis() { AxisName = prefix + "axis 6", IsInverted = true, } }, // Richt Stick Y
                { 4, new Axis() { AxisName = prefix + "axis 4", } }, // Left Trigger
                { 5, new Axis() { AxisName = prefix + "axis 5", } }, // Right Trigger
                { 6, new Axis() { AxisName = prefix + "axis 7", } }, // DPad X
                { 7, new Axis() { AxisName = prefix + "axis 8", } }, // DPad Y
            };

            buttons = new Dictionary<int, Button>
            {
                { 0, new Button { ButtonName = prefix + "button 0" } }, // Action Left
                { 1, new Button { ButtonName = prefix + "button 1" } }, // Action Bottom
                { 2, new Button { ButtonName = prefix + "button 2" } }, // Action Right
                { 3, new Button { ButtonName = prefix + "button 3" } }, // Action Top
                { 4, new Button { ButtonName = prefix + "button 4" } }, // Left Bumper
                { 5, new Button { ButtonName = prefix + "button 5" } }, // Right Bumper
                { 6, new Button { ButtonName = prefix + "button 6" } }, // Left Trigger
                { 7, new Button { ButtonName = prefix + "button 7" } }, // Right Trigger
                { 8, new Button { ButtonName = prefix + "button 8" } }, // Select
                { 9, new Button { ButtonName = prefix + "button 9" } }, // Start
                { 10, new Button { ButtonName = prefix + "button 10" } }, // Left Stick
                { 11, new Button { ButtonName = prefix + "button 11" } }, // Right Stick
                { 12, new Button { IsVirtual = true, AxisName = prefix + "axis 7", FromeNegativeAxis = true, } }, // DPad Left
                { 13, new Button { IsVirtual = true, AxisName = prefix + "axis 8", FromeNegativeAxis = true, } }, // DPad Down
                { 14, new Button { IsVirtual = true, AxisName = prefix + "axis 7", FromePositiveAxis = true, } }, // DPad Right
                { 15, new Button { IsVirtual = true, AxisName = prefix + "axis 8", FromePositiveAxis = true, } }, // DPad Up
            };
        }
    }
}
