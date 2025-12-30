using UnityEngine;

public class TimelineTrigger : MonoBehaviour
{
    [SerializeField] private TimelineManager timelineManager;
    [SerializeField] private bool triggerOnlyOnce = true;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (timelineManager == null)
        {
            Debug.LogWarning("¡TimelineTrigger no tiene asignado un TimelineManager!");
            return;
        }

        if (hasTriggered && triggerOnlyOnce)
            return;

        timelineManager.EmpezarSecuencia();
        hasTriggered = true;
    }
}   
