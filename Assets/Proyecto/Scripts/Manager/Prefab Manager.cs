using System;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;

    [System.Serializable]
    public struct PrefabData
    {
        public string prefabName;
        public GameObject parent;
        public GameObject prefabObject;
    }
    [Header("Prefab Objects")] public PrefabData[] prefabs;

    private Dictionary<string, PrefabData> prefabDict;
    private void Awake()
    {
        Instance = this;
        prefabDict = new Dictionary<string, PrefabData>();
        foreach (var data in prefabs)
        {
            if (!prefabDict.ContainsKey(data.prefabName)) prefabDict.Add(data.prefabName, data);
            else Debug.LogWarning("El prefab " + data.prefabName + " ya existe en el diccionario.");
        }
    }

    public void GenerarPrefab(string nombre) => Generar(nombre, Vector3.zero);

    public GameObject Generar(string nombre, Vector3 posicion)
    {
        if (prefabDict.ContainsKey(nombre))
        {
            PrefabData data = prefabDict[nombre];

            // Usamos el parent específico que asignaste en el Inspector para este prefab
            Transform padreFinal = data.parent != null ? data.parent.transform : this.transform;

            GameObject nuevoUI = Instantiate(data.prefabObject, padreFinal);

            // Ajustamos el RectTransform para UI
            RectTransform rect = nuevoUI.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchoredPosition = Vector2.zero;
                rect.localScale = Vector3.one; // Evita que se instancie con escalas raras
            }

            return nuevoUI;
        }
        Debug.LogWarning("El prefab " + nombre + " no existe.");
        return null;
    }
}
