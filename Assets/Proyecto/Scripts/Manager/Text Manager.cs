using System.Collections;
using UnityEngine;
using TMPro;

public class TextArquitetch : MonoBehaviour
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;

    private TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;

    public string currentText => tmpro.text;

    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = "";
    public int preTextLength = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod { instant, typewriter, desvanecer}

    public BuildMethod buildMethod = BuildMethod.typewriter;
}
