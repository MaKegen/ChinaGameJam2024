using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject CanvasOff;//����رջ���

    public void changeCanvas()//�����л������ķ���
    {
        CanvasOff.SetActive(false);//ʵ�ֹرջ���
    }
}