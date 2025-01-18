using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance; // ���������� ������ �� ����� �����
    public bool IsUkrainian = false; // �����, ��� ������� ������� ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��������� ��'��� ��� ��� �����
        }
        else
        {
            Destroy(gameObject); // �������� ����������
        }
    }

    public void ToggleLanguage()
    {
        IsUkrainian = !IsUkrainian; // ������� ������ ����� ��� ����������� ����
    }
}
