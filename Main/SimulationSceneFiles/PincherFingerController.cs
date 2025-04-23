using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PincherFingerController : MonoBehaviour
{

    public float closedZ;

    Vector3 openPosition;
    ArticulationBody articulation;


    //初始化机械臂的控制参数
    void Start()
    {
        openPosition = transform.localPosition;
        articulation = GetComponent<ArticulationBody>();
        SetLimits();
    }

    void SetLimits()
    {
        float openZTarget = ZDriveTarget(0.0f);
        float closedZTarget = ZDriveTarget(1.0f);
        float min = Mathf.Min(openZTarget, closedZTarget);
        float max = Mathf.Max(openZTarget, closedZTarget);

        var drive = articulation.zDrive;
        drive.lowerLimit = min;
        drive.upperLimit = max;
        articulation.zDrive = drive;
    }


    // 获取当前机械爪的夹持状态和打开的位置
    public float CurrentGrip()
    {
        float grip = Mathf.InverseLerp(openPosition.z, closedZ, transform.localPosition.z);
        return grip;
    }

    public Vector3 GetOpenPosition()
    {
        return openPosition;
    }

    //控制机械爪的开合
    public void UpdateGrip(float grip)
    {
        float targetZ = ZDriveTarget(grip);
        var drive = articulation.zDrive;
        drive.target = targetZ;
        articulation.zDrive = drive;
    }

    public void ForceOpen(Transform transform)
    {
        transform.localPosition = openPosition;
        UpdateGrip(0.0f);
    }

    // 根据手指当前的夹取力度，计算出手指应该到达的位置
    float ZDriveTarget(float grip)
    {
        float zPosition = Mathf.Lerp(openPosition.z, closedZ, grip);
        float targetZ = (zPosition - openPosition.z) * transform.parent.localScale.z;
        return targetZ;
    }


}
