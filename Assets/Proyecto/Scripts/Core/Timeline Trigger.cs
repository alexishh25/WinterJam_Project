using UnityEngine;

public class TimelineTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnlyOnce = true;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered && triggerOnlyOnce)
            return;

        TimelineManager.Instance.EmpezarSecuencia();
        hasTriggered = true;
    }
}
