using System;
using System.Collections.Generic;
using UnityEngine;
using Matthias.ControllerInput;

public class GamepadTest : MonoBehaviour
{
    private Dictionary<ControllerButton, Renderer> buttons;
    private Dictionary<ControllerdAxis, Transform> axis;

    private Dictionary<Renderer, Color> btnColor;
    private Dictionary<Transform, Vector3> axisPos;

    private void Start()
    {

    }

    private void Update()
    {
        float x = ControllerInput.GetAxes(ControllerdAxis.LStick_X);
        transform.position += new Vector3(x,0f,0f);
    }
}
