using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance; // Глобальний доступ до цього класу
    public bool IsUkrainian = false; // Змінна, яка визначає поточну мову

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Не знищувати об'єкт при зміні сцени
        }
        else
        {
            Destroy(gameObject); // Уникнути дублювання
        }
    }

    public void ToggleLanguage()
    {
        IsUkrainian = !IsUkrainian; // Змінюємо булеву змінну для перемикання мови
    }
}
