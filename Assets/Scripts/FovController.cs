using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class FovController : MonoBehaviour
{
    public float fovAngle = 90f;
    public Transform fovPoint;
    public float range = 5;

    public Transform target;
    [SerializeField] Light2D fovLight;
    [SerializeField] PlayerController playerController;
    public LayerMask layers;

    public void SetStartValues(GameObject playerObject)
    {
        fovAngle = fovLight.pointLightInnerAngle;
        range = fovLight.pointLightInnerRadius;

        playerController = playerObject.GetComponent<PlayerController>();
        target = playerObject.transform;
    }
 

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
        RaycastHit2D r = Physics2D.Raycast(fovPoint.position, dir, range, layers);

        if (r.collider == null)
            return;

        if (angle < fovAngle / 2)
        {
            if (r.collider.CompareTag("Player"))
            {
                print("Player in light");
                playerController.ReceiveDamage();
                //playerController.InLightArea(true, fovLight.gameObject);
                Debug.DrawRay(fovPoint.position, dir, Color.red);
            }
            else
            {
                print("Player in shadow");
                //playerController.InLightArea(false, fovLight.gameObject);
            }
        }

    }
}