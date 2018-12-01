using System;
using System.Collections.Generic;
using UnityEngine;
using Matthias.ControllerInput;

public class GamepadTest : MonoBehaviour
{
    private Dictionary<ControllerButton, Renderer> buttons;
    private Dictionary<ControllerAxis, Transform> axis;

    private Dictionary<Renderer, Color> btnColor;
    private Dictionary<Transform, Vector3> axisPos;

    private ControllerInput controllerInput;

    private void Start()
    {
        controllerInput = new ControllerInput();

        buttons = new Dictionary<ControllerButton, Renderer>();
        axis = new Dictionary<ControllerAxis, Transform>();

        btnColor = new Dictionary<Renderer, Color>();
        axisPos = new Dictionary<Transform, Vector3>();

        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);
            ControllerButton btn = GetButtonEnum(child.name);
            AddInput(btn, child);
        }

        var trans8 = transform.GetChild(8);
        AddInput(ControllerAxis.LStick_X, trans8);
        AddInput(ControllerAxis.LStick_Y, trans8);

        var trans9 = transform.GetChild(9);
        AddInput(ControllerAxis.RStick_X, trans9);
        AddInput(ControllerAxis.RStick_Y, trans9);

        var trans15 = transform.GetChild(15);
        AddInput(ControllerAxis.LTrigger, trans15);

        var trans14 = transform.GetChild(14);
        AddInput(ControllerAxis.RTrigger, trans14);

        var trans4 = transform.GetChild(4);
        AddInput(ControllerAxis.DPad_X, trans4);

        var trans5 = transform.GetChild(5);
        AddInput(ControllerAxis.DPad_X, trans5);

        var trans6 = transform.GetChild(6);
        AddInput(ControllerAxis.DPad_Y, trans6);

        var trans7 = transform.GetChild(7);
        AddInput(ControllerAxis.DPad_Y, trans7);
    }

    private void Update()
    {
        foreach (var button in buttons)
        {
            button.Value.material.color = btnColor[button.Value];
        }

        var btnsPressed = controllerInput.GetAllButtons();
        int btnPCount = btnsPressed.Count;
        for (int i = 0; i < btnPCount; i++)
        {
            var btnPressed = btnsPressed[i];
            if (buttons.ContainsKey(btnPressed))
            {
                buttons[btnPressed].material.color = new Color(0f, 1f, 0f);
            }
        }

        var axisPushed = controllerInput.GetAllAxis();

        float valueLX = axisPushed[ControllerAxis.LStick_X];
        float valueLY = axisPushed[ControllerAxis.LStick_Y];
        axis[ControllerAxis.LStick_X].position = axisPos[axis[ControllerAxis.LStick_X]] + new Vector3(valueLX * 0.5f, 0, valueLY * 0.5f);

        float valueRX = axisPushed[ControllerAxis.RStick_X];
        float valueRY = axisPushed[ControllerAxis.RStick_Y];
        axis[ControllerAxis.RStick_X].position = axisPos[axis[ControllerAxis.RStick_X]] + new Vector3(valueRX * 0.5f, 0, valueRY * 0.5f);

        float valueLT = axisPushed[ControllerAxis.LTrigger];
        axis[ControllerAxis.LTrigger].position = axisPos[axis[ControllerAxis.LTrigger]] + new Vector3(-valueLT * 0.5f, 0, 0);

        float valueRT = axisPushed[ControllerAxis.RTrigger];
        axis[ControllerAxis.RTrigger].position = axisPos[axis[ControllerAxis.RTrigger]] + new Vector3(valueRT * 0.5f, 0, 0);

        float valueDL = axisPushed[ControllerAxis.DPad_X];
        if (valueDL <= 0f)
        {
            axis[ControllerAxis.DPad_X].position = axisPos[axis[ControllerAxis.DPad_X]] + new Vector3(valueDL * 0.3f, 0, 0);
        }
        if (valueDL >= 0f)
        {
            transform.GetChild(5).position = axisPos[transform.GetChild(5)] + new Vector3(valueDL * 0.3f, 0, 0);
        }

        float valueDT = axisPushed[ControllerAxis.DPad_Y];

        if (valueDT >= 0f)
        {
            axis[ControllerAxis.DPad_Y].position = axisPos[axis[ControllerAxis.DPad_Y]] + new Vector3(0, 0, valueDT * 0.3f);
        }
        if (valueDT <= 0f)
        {
            transform.GetChild(7).position = axisPos[transform.GetChild(7)] + new Vector3(0, 0, valueDT * 0.3f);
        }
    }

    private ControllerButton GetButtonEnum(string name)
    {
        return (ControllerButton)Enum.Parse(typeof(ControllerButton), name);
    }

    private void AddInput(ControllerButton btn, Transform trans)
    {
        var r = trans.GetComponent<Renderer>();
        buttons.Add(btn, r);
        btnColor.Add(r, r.material.color);
    }

    private void AddInput(ControllerAxis axis, Transform trans)
    {
        if (!this.axis.ContainsKey(axis))
        {
            this.axis.Add(axis, trans);
        }
        if (!axisPos.ContainsKey(trans))
        {
            axisPos.Add(trans, trans.position);
        }
    }
}
