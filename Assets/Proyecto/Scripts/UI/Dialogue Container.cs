using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;

[System.Serializable]
public class DialogueContainer
{
    public GameObject root;
    public TMP_Text nameLocalize;
    public LocalizeStringEvent dialogueLocalize;
    public TMP_Text nameText, dialogueText;
}
