using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TextToLocalized;
    [SerializeField]
    private string textToLoad;
    private string EnglishText;

    // Reference to LocalizationManager to check the language
    private LocalizationManager localizationManager;

    private void Start()
    {
        // Find LocalizationManager automatically
        localizationManager = FindObjectOfType<LocalizationManager>();
        if (localizationManager == null)
        {
            Debug.LogError("LocalizationManager not found in the scene!");
        }

        EnglishText = TextToLocalized.text;
    }

    void Update()
    {
        // Check if the language is Ukrainian
        if (localizationManager != null && localizationManager.IsUkrainian)
        {
            TextToLocalized.text = textToLoad;
        }
        else
        {
            TextToLocalized.text = EnglishText;
        }
    }
}
