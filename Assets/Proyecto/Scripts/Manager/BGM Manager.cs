using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }

    [Header("Configuracion")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private float fadeDuration = 1.5f;

    private bool isMuted = false;

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ReproducirBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip) return;

        bgmSource.clip = clip;
        bgmSource.Play();
    }

    /// <summary>
    /// Cambia la música con un efecto de fundido (Fade).
    /// </summary>
    public void CambiarBGM(AudioClip newClip, float duration = -1f)
    {
        float fadeTime = duration > 0 ? fadeDuration : duration;

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeTransition(newClip, fadeTime));
    }

    public void AlternarMute()
    {
        isMuted = !isMuted;

        if (isMuted)
            bgmSource.volume = 0;
        else
            bgmSource.volume = 1;
    }

    public IEnumerator FadeTransition(AudioClip newClip, float duration)
    {
        if (bgmSource.isPlaying)
        {
            float startVolume = bgmSource.volume;
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                bgmSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
                yield return null;
            }

            bgmSource.clip = newClip;
            bgmSource.Play();

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                bgmSource.volume = Mathf.Lerp(0, startVolume, t / duration);
                yield return null;
            }
        }
    }

    public void FadingBGM(float duracion = 2.0f)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadingCorrutina(duracion));
    }

    public IEnumerator FadingCorrutina(float duracion)
    {
        if (bgmSource.isPlaying)
        {
            float volumeninicial = bgmSource.volume;

            for (float t = 0; t < duracion; t += Time.deltaTime)
            {
                bgmSource.volume = Mathf.Lerp(volumeninicial, 0, t / duracion);
                yield return null;
            }
            bgmSource.volume = 0;
            bgmSource.Stop();
            bgmSource.volume = volumeninicial;
        }
    }
}
