using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nuevo Dialogo", menuName = "Visual Novel / Script Diálogo")]
public class DialogueData : ScriptableObject
{
    [Serializable]
    public struct DialogueLine
    {
        public string speakerName;
        [TextArea(2, 5)]
        public string text;
        public AudioClip voiceClip;
        public Sprite characterImage;
    }

    [Header("Script Content")] public DialogueLine[] lineas;
}
