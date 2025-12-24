using System;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

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
