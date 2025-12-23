using UnityEngine;
using TMPro;
using UnityEngine.Localization.Components;

[System.Serializable]
public class DialogueContainer
{
    public GameObject root;
    public LocalizeStringEvent nameLocalize, dialogueLocalize;
    public TMP_Text nameText, dialogueText;
}
