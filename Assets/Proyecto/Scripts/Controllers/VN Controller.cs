using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static DialogueData;

[ExecuteAlways]
public class VNController : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;

    [SerializeField] private DialogueContainer dialogueContainer = new DialogueContainer();
    [SerializeField] private Image characterimage;

    private int currentLineIndex = 0;

    [Header("Referencias de UI")]
    [SerializeField] private RectTransform characterTransform; 
    [SerializeField] private RectTransform dialogueTransform; 

    // Definimos las posiciones fijas (puedes ajustarlas en el Inspector)
    [Header("Configuración de Character")]
    [SerializeField] private Vector2 C_anchormin = new Vector2(0, 0);
    [SerializeField] private Vector2 C_anchormax = new Vector2(0, 0);

    [Header("Configuracion de TextBox")]
    [SerializeField] private Vector2 T_anchormin = new Vector2(0, 0);
    [SerializeField] private Vector2 T_anchormax = new Vector2(0, 0);

    private void Start()
    {
        C_anchormin = new Vector2(characterTransform.anchorMin.x, characterTransform.anchorMax.x);

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
        if (characterTransform == null || dialogueTransform == null) return;

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

    private void Edicion()
    {

    }


    #if UNITY_EDITOR
    private void OnValidate()
    {
        // Esto permite que al mover sliders o cambiar la línea en el Inspector, la Scene se actualice
        if (dialogueData != null && characterTransform != null && dialogueTransform != null)
        {
            if (currentLineIndex >= 0 && currentLineIndex < dialogueData.lineas.Length)
            {
                Edicion();
            }
        }
    }
    #endif
}
