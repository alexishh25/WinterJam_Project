using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SfxController : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource audiosource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audiosource.Stop();
        audiosource.Play();
    }

    private void OnValidate()
    {
        if (audiosource == null)
        {
            audiosource = GetComponent<AudioSource>();
        }
    }
}
