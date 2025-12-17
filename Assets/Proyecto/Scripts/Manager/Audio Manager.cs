using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audiosource;

    [SerializeField] private AudioClip sonido_hover;
    [SerializeField] private AudioClip sonido_click;

    private void Awake()
    {
        if (audiosource == null)
            audiosource = GetComponent<AudioSource>();

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void ReproducirClick() => ReproducirSonido(sonido_click);
    public void ReproducirHover() => ReproducirSonidoConInterrupcion(sonido_hover);

    private void ReproducirSonido(AudioClip clip)
    {
        if (audiosource != null)
        {
            audiosource.clip = clip;
            audiosource.Play();
            Debug.Log($"AudioManager: Reproduciendo el clip de audio '{clip.name}'");
        }
        else if (clip == null)
            Debug.LogWarning($"AudioManager: El clip de audio '{clip.name}' es nulo");
    }

    private void ReproducirSonidoConInterrupcion(AudioClip clip)
    {
        if (audiosource != null)
        {
            audiosource.Stop();
            audiosource.clip = clip;
            audiosource.Play();
            Debug.Log($"AudioManager: Reproduciendo el clip de audio '{clip.name}'");
        }
        else if (clip == null)
            Debug.LogWarning($"AudioManager: El clip de audio '{clip.name}' es nulo");
    }

    private void OnValidate()
    {
        if (audiosource == null)
        {
            audiosource = GetComponent<AudioSource>();
        }
    }
}
