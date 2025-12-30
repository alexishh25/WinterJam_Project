using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavi : MonoBehaviour
{
    public void Jugar() => SceneManager.LoadScene("Visual Novel");

    public void Salir() => Application.Quit();
}
