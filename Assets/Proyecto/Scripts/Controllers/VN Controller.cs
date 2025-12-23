using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static DialogueData;

public class VNController : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;

    [SerializeField] private DialogueContainer dialogueContainer = new DialogueContainer();
    [SerializeField] private Image characterimage;

    private int currentLineIndex = 0;

    private void Start()
    {
        dialogueContainer.root.SetActive(true);
        currentLineIndex = 0;
        ShowLine();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
    Mouse.current.leftButton.wasPressedThisFrame)
        {
            AdvanceDialogue();
        }
    }

    private void ShowLine()
    {
        DialogueLine line = dialogueData.lineas[currentLineIndex];

        dialogueContainer.dialogueText.text = line.speakerName;
        dialogueContainer.dialogueText.text = line.text;
        characterimage.sprite = line.characterImage;

        if (line.voiceClip != null)
        {
            GetComponent<AudioSource>().PlayOneShot(line.voiceClip);
        }
    }

    private void AdvanceDialogue()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueData.lineas.Length)
        {
            ShowLine();
        }
        else
        {
            dialogueContainer.root.SetActive(false);
        }
    }

}
