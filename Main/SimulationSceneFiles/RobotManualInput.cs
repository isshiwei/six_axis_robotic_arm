using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManualInput : MonoBehaviour
{
    public GameObject robot;

    public AxisBtnControl axisBtnControl;
    //复位
    private void Awake()
    {
        axisBtnControl.restoreBtn.onClick.AddListener(() =>
        {
            RobotController robotController = robot.GetComponent<RobotController>();
            foreach (var joint in robotController.joints)
            {
                var articulationJointController = joint.robotPart.GetComponent<ArticulationJointController>();
                var drive = articulationJointController.articulation.xDrive;
                drive.target = 0;
                articulationJointController.articulation.xDrive = drive;
            }
        });
    }

    //检查是否有输入
    void Update()
    {
        RobotController robotController = robot.GetComponent<RobotController>();
        for (int i = 0; i < robotController.joints.Length; i++)
        {
            float inputVal = Input.GetAxis(robotController.joints[i].inputAxis);
            if (inputVal == 0)
                inputVal = axisBtnControl.axisBtn[i].inputVal;
            if (Mathf.Abs(inputVal) > 0)
            {
                RotationDirection direction = GetRotationDirection(inputVal);
                robotController.RotateJoint(i, direction);
                return;
            }
        }
        robotController.StopAllJointRotations();

    }

    //确定旋转方向
    static RotationDirection GetRotationDirection(float inputVal)
    {
        if (inputVal > 0)
        {
            return RotationDirection.Positive;
        }
        else if (inputVal < 0)
        {
            return RotationDirection.Negative;
        }
        else
        {
            return RotationDirection.None;
        }
    }
}
