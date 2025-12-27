using UnityEngine;

public class BotCoverPointDetector : MonoBehaviour
{
    [SerializeField] private float radius = 10f;
    [SerializeField] private LayerMask targetLayer;

    public Transform GetTarget()
    {
        var hits = Physics.OverlapSphere(transform.position, radius, targetLayer);
        
        Transform nearest = null;
        float minDistance = Mathf.Infinity;
        
        foreach (var hit in hits)
        {
            float sqr = Vector3.Distance(transform.position, hit.transform.position);

            if (sqr < minDistance)
            {
                minDistance = sqr;
                nearest = hit.transform;
            }
        }
        
        return nearest;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}