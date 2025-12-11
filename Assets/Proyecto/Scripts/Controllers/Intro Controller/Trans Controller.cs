using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Trans_Controller : MonoBehaviour
{
    private bool activo = false;

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("Idioma", 0);
        CambiarIdioma(ID);
    }

    public void CambiarIdioma(int localeID)
    {
        if (localeID >= LocalizationSettings.AvailableLocales.Locales.Count)
        {
            Debug.LogError($"ID de Localización {localeID} fuera de rango.");
            return;
        }
        var requestedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];

        if (activo && LocalizationSettings.SelectedLocale == requestedLocale)
            return;
        StartCoroutine(Change(localeID));
    }

    public IEnumerator Change(int ID)
    {
        activo = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[ID];
        PlayerPrefs.SetInt("Idioma", ID);
        Debug.Log("Idioma cambiado a: " + LocalizationSettings.SelectedLocale);
        activo = false;
    }
}
