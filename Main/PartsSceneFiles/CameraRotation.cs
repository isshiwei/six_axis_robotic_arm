using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform ��̨ҡͷ��;
    public Transform ��̨������;
    public Transform ��ͷ����������;
    Vector3 �����һ֡λ��;
    public float ҡͷ�ٶ� = .2f;
    public float �����ٶ� = .2f;
    public float �������Ƕ� = 15;
    public float ������С�Ƕ� = -85;
    public float �����ٶ� = .25f;
    public float �����������ֵ = 3f, ����������Сֵ = -3f;
    float �Ƕȼ��� = 0;
    float �������� = 0;
    void Start()
    {
        ԭʼ���� = ��̨������.localEulerAngles;
        ԭʼ���� = ��ͷ����������.localPosition;
        ԭʼҡͷ = ��̨ҡͷ��.localEulerAngles;
        _��λ_();
    }
    Vector3 ԭʼ����;
    Vector3 ԭʼ����;
    Vector3 ԭʼҡͷ;
    public void _��λ_()
    {
        ��̨������.localEulerAngles = ԭʼ����;
        ��ͷ����������.localPosition = ԭʼ����;
        ��̨ҡͷ��.localEulerAngles = ԭʼҡͷ;
        �Ƕȼ��� = 0;
        �������� = 0;
    }
    public void _ǰ��ͼ_()
    {
        ��̨������.localEulerAngles = Vector3.zero;
        ��ͷ����������.localPosition = ԭʼ����;
        ��̨ҡͷ��.localEulerAngles = Vector3.up * 90;
        �Ƕȼ��� = (ԭʼ���� - ��̨������.localEulerAngles).x;
        �������� = 0;
    }
    public void _����ͼ_()
    {
        ��̨������.localEulerAngles = Vector3.zero;
        ��ͷ����������.localPosition = ԭʼ����;
        ��̨ҡͷ��.localEulerAngles = Vector3.up * 23;
        �Ƕȼ��� = (ԭʼ���� - ��̨������.localEulerAngles).x;
        �������� = 0;
    }
    public void _����ͼ_()
    {
        ��̨������.localEulerAngles = Vector3.right * 85;
        ��ͷ����������.localPosition = ԭʼ����;
        ��̨ҡͷ��.localEulerAngles = Vector3.up * 90;
        �Ƕȼ��� = (ԭʼ���� - ��̨������.localEulerAngles).x;
        �������� = 0;
    }
    public enum ��ͷ����
    {
        ��λ��ͼ = 0, ����ͼ, ǰ��ͼ, ����ͼ
    }
    public void _�л���ͷ_(��ͷ���� �л�����)
    {
        _�л���ͷ_((int)�л�����);
    }
    public void _�л���ͷ_(int �л�����)
    {
        switch (�л�����)
        {
            case 0:
                _��λ_();
                break;
            case 1:
                _����ͼ_();
                break;
            case 2:
                _ǰ��ͼ_();
                break;
            case 3:
                _����ͼ_();
                break;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            �����һ֡λ�� = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            ��̨ҡͷ��.Rotate(Vector3.up * (�����һ֡λ�� - Input.mousePosition).x * ҡͷ�ٶ�);
            float �����Ƕ��˶��ݴ� = (�����һ֡λ�� - Input.mousePosition).y * �����ٶ�;
            if (�Ƕȼ��� + �����Ƕ��˶��ݴ� < �������Ƕ� && �Ƕȼ��� + �����Ƕ��˶��ݴ� > ������С�Ƕ�)
            {
                �Ƕȼ��� += �����Ƕ��˶��ݴ�;
                ��̨������.Rotate(Vector3.left * �����Ƕ��˶��ݴ�);
            }
        }
        float ���������ݴ� = Input.mouseScrollDelta.y * �����ٶ�;
        if (�������� + ���������ݴ� > ����������Сֵ && �������� + ���������ݴ� < �����������ֵ)
        {
            �������� += ���������ݴ�;
            ��ͷ����������.Translate(Vector3.forward * Input.mouseScrollDelta.y * �����ٶ�);
        }
        �����һ֡λ�� = Input.mousePosition;
    }
}
