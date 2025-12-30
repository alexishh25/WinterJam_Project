using System;
using UnityEngine;
using UnityEngine.Localization;

#if UNITY_EDITOR
using UnityEditor.Localization;
#endif

[CreateAssetMenu(fileName = "Nuevo Dialogo", menuName = "Visual Novel / Script Diálogo")]
public class DialogueData : ScriptableObject
{
    public enum CharacterSide
    {
        Izquierda,
        Derecha
    }
    [Serializable]
    public struct DialogueLine
    {
        public string speakerName;
        public LocalizedString text;
        public CharacterSide position;
        public AudioClip voiceClip;
        public Sprite characterImage;
    }

    [Header("Script Content")] public DialogueLine[] lineas;
}
