using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCrosshair : MonoBehaviour
{
    [SerializeField] RectTransform crosshairTransform;
    [SerializeField] float crosshairInteractionScale = 0.3f;
    private Vector3 initialCrosshairScale;
    [SerializeField] LayerMask interactableLayers;
    [SerializeField] float sphereCastDistance = 3f;
    [SerializeField] float sphereCastRadius = 0.25f;
    private Outline hitOutline;

    void Start()
    {
        initialCrosshairScale = crosshairTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, sphereCastDistance, interactableLayers))
        // if(Physics.SphereCast(transform.position, sphereCastRadius, transform.TransformDirection(Vector3.forward), out hit, sphereCastDistance, interactableLayers))
        {
            hitOutline = hit.transform.gameObject.GetComponent<Outline>();
            hitOutline.OutlineWidth = 20;

            crosshairTransform.localScale = new Vector3(crosshairInteractionScale, crosshairInteractionScale, crosshairInteractionScale);
        }
        else
        {
            if(hitOutline)
            {
                hitOutline.OutlineWidth = 6.5f;
                hitOutline = null;

                crosshairTransform.localScale = initialCrosshairScale;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * sphereCastDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
