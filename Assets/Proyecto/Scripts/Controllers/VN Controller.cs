using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static DialogueData;
using static VNController;

[ExecuteAlways]
public class VNController : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;

    [SerializeField] private DialogueContainer dialogueContainer = new DialogueContainer();
    [SerializeField] private Image characterimage;

    private int currentLineIndex = 0;

    [Header("Character UI")]
    [SerializeField] private RectTransform characterTransform;

    [Header("Dialogue UI")]
    [SerializeField] private RectTransform dialogueRoot;
    [SerializeField] private RectTransform dialogueBackground;
    [SerializeField] private RectTransform dialogueText;
    [SerializeField] private RectTransform dialoguenameText;

    [System.Serializable]
    public struct RectPreset
    {
        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Vector2 anchoredPosition;
        public Vector2 sizeDelta;
    }

    [System.Serializable]
    public struct DialogueLayoutPreset
    {
        [Header("Dialogue Root")]
        public RectPreset root;

        [Header("Dialogue Children")]
        public RectPreset textbox;
        public RectPreset NameText;
        public RectPreset DialogueText;
        public RectPreset Pointer;
    }

    [System.Serializable]
    public struct VNLayoutPreset
    {
        [Header("Character (simple)")]
        public RectPreset character;

        [Header("Dialogue (composed)")]
        public DialogueLayoutPreset dialogue;
    }

    [Header("Presets")]
    [SerializeField] private RectPreset characterLeft;
    [SerializeField] private RectPreset characterRight;
    [SerializeField] private RectPreset dialogueLeft;
    [SerializeField] private RectPreset dialogueRight;

    private void Start()
    {
        dialogueContainer.root.SetActive(true);
        currentLineIndex = 0;
        ShowLine();
    }

    private void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        //    AdvanceDialogue();
    }

    private void ShowLine()
    {
        DialogueLine line = dialogueData.lineas[currentLineIndex];

        if (line.position == CharacterSide.Izquierda)
            MoverUI(izquierda: true);
        else
            MoverUI(izquierda: false);

        dialogueContainer.dialogueText.text = line.speakerName;
        dialogueContainer.dialogueText.text = line.text.GetLocalizedString();
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

    private void MoverUI(bool izquierda)
    {
        if (characterTransform == null || dialogueRoot == null) return;

        if (izquierda)
        {
            // Personaje a la izquierda, Diálogo a la derecha
            //characterTransform.anchoredPosition = new Vector2(-Mathf.Abs(charPosDerecha.x), charPosDerecha.y);
            //dialogueTransform.anchoredPosition = dialPosDerecha;

            // Opcional: Voltear al personaje para que mire al centro
            characterTransform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Personaje a la derecha, Diálogo a la izquierda
            //characterTransform.anchoredPosition = charPosDerecha;
            //dialogueTransform.anchoredPosition = dialPosIzquierda;

            // Opcional: Hacer espejo (Flip)
            characterTransform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void ApplyPreset(RectTransform rt, RectPreset preset)
    {
        if (rt == null) return;

        rt.anchorMin = preset.anchorMin;
        rt.anchorMax = preset.anchorMax;
        rt.anchoredPosition = preset.anchoredPosition;
        rt.sizeDelta = preset.sizeDelta;
    }

    private void ApplyDialogueLayout(DialogueLayoutPreset preset)
    {
        ApplyPreset(dialogueRoot, preset.root);
        ApplyPreset(dialogueBackground, preset.textbox);
        ApplyPreset(dialogueText, preset.DialogueText);
        ApplyPreset(dialoguenameText, preset.NameText);
    }

    private void ApplyVNLayout(VNLayoutPreset layout)
    {
        ApplyPreset(characterTransform, layout.character);
        ApplyDialogueLayout(layout.dialogue);
    }

    [SerializeField] private VNLayoutPreset leftLayout;
    [SerializeField] private VNLayoutPreset rightLayout;

    private void Edicion()
    {
        DialogueLine line = dialogueData.lineas[currentLineIndex];

        if (line.position == CharacterSide.Izquierda)
            ApplyVNLayout(leftLayout);
        else
            ApplyVNLayout(rightLayout);
    }



#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            UnityEditor.EditorApplication.delayCall += ApplyEdicionSafe;
        }
    }
#endif

#if UNITY_EDITOR
    private void ApplyEdicionSafe()
    {
        if (this == null) return; // objeto destruido
        Edicion();
    }
#endif
}
