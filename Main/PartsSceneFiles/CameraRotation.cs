using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform 云台摇头点;
    public Transform 云台俯仰点;
    public Transform 镜头推拉父物体;
    Vector3 鼠标上一帧位置;
    public float 摇头速度 = .2f;
    public float 俯仰速度 = .2f;
    public float 俯仰最大角度 = 15;
    public float 俯仰最小角度 = -85;
    public float 推拉速度 = .25f;
    public float 推拉距离最大值 = 3f, 推拉距离最小值 = -3f;
    float 角度计数 = 0;
    float 推拉计数 = 0;
    void Start()
    {
        原始俯仰 = 云台俯仰点.localEulerAngles;
        原始推拉 = 镜头推拉父物体.localPosition;
        原始摇头 = 云台摇头点.localEulerAngles;
        _归位_();
    }
    Vector3 原始俯仰;
    Vector3 原始推拉;
    Vector3 原始摇头;
    public void _归位_()
    {
        云台俯仰点.localEulerAngles = 原始俯仰;
        镜头推拉父物体.localPosition = 原始推拉;
        云台摇头点.localEulerAngles = 原始摇头;
        角度计数 = 0;
        推拉计数 = 0;
    }
    public void _前视图_()
    {
        云台俯仰点.localEulerAngles = Vector3.zero;
        镜头推拉父物体.localPosition = 原始推拉;
        云台摇头点.localEulerAngles = Vector3.up * 90;
        角度计数 = (原始俯仰 - 云台俯仰点.localEulerAngles).x;
        推拉计数 = 0;
    }
    public void _右视图_()
    {
        云台俯仰点.localEulerAngles = Vector3.zero;
        镜头推拉父物体.localPosition = 原始推拉;
        云台摇头点.localEulerAngles = Vector3.up * 23;
        角度计数 = (原始俯仰 - 云台俯仰点.localEulerAngles).x;
        推拉计数 = 0;
    }
    public void _顶视图_()
    {
        云台俯仰点.localEulerAngles = Vector3.right * 85;
        镜头推拉父物体.localPosition = 原始推拉;
        云台摇头点.localEulerAngles = Vector3.up * 90;
        角度计数 = (原始俯仰 - 云台俯仰点.localEulerAngles).x;
        推拉计数 = 0;
    }
    public enum 镜头方向
    {
        归位视图 = 0, 顶视图, 前视图, 右视图
    }
    public void _切换镜头_(镜头方向 切换方向)
    {
        _切换镜头_((int)切换方向);
    }
    public void _切换镜头_(int 切换方向)
    {
        switch (切换方向)
        {
            case 0:
                _归位_();
                break;
            case 1:
                _顶视图_();
                break;
            case 2:
                _前视图_();
                break;
            case 3:
                _右视图_();
                break;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            鼠标上一帧位置 = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            云台摇头点.Rotate(Vector3.up * (鼠标上一帧位置 - Input.mousePosition).x * 摇头速度);
            float 俯仰角度运动暂存 = (鼠标上一帧位置 - Input.mousePosition).y * 俯仰速度;
            if (角度计数 + 俯仰角度运动暂存 < 俯仰最大角度 && 角度计数 + 俯仰角度运动暂存 > 俯仰最小角度)
            {
                角度计数 += 俯仰角度运动暂存;
                云台俯仰点.Rotate(Vector3.left * 俯仰角度运动暂存);
            }
        }
        float 推拉距离暂存 = Input.mouseScrollDelta.y * 推拉速度;
        if (推拉计数 + 推拉距离暂存 > 推拉距离最小值 && 推拉计数 + 推拉距离暂存 < 推拉距离最大值)
        {
            推拉计数 += 推拉距离暂存;
            镜头推拉父物体.Translate(Vector3.forward * Input.mouseScrollDelta.y * 推拉速度);
        }
        鼠标上一帧位置 = Input.mousePosition;
    }
}
