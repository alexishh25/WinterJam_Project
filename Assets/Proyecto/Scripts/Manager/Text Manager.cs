using System.Collections;
using UnityEngine;
using TMPro;

public class TextArquitetch : MonoBehaviour
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;

    private TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;

    public string currentText => tmpro.text;

    public string targetText { get; private set;}
}
