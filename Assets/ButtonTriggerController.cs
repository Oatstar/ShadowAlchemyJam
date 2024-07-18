using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerController : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    public string moveTriggerType = ""; // clockwise / counterclockwise / x / y
    public string moveType = ""; // spin / move
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerButton();
        }
    }

    void TriggerButton()
    {
        if (targetObject.name == "ShadowBlocker" || targetObject.name == "FOV")
        {
            Debug.Log("Stepping on a button trigger");
            if(moveType == "move")
            {
                ObjectMover objectMover = targetObject.GetComponent<ObjectMover>();
                if (objectMover != null)
                {
                    Debug.Log("Triggering move");

                    if (moveTriggerType == "x")
                        objectMover.moveX = !objectMover.moveX;
                    if (moveTriggerType == "y")
                        objectMover.moveY = !objectMover.moveY;
                }
            }
            else if (moveType == "spin")
            {
                Debug.Log("Triggering spin");

                ObjectSpinner objectSpinner = targetObject.GetComponent<ObjectSpinner>();
                if (objectSpinner != null)
                {
                    objectSpinner.spin = !objectSpinner.spin;
                }
            }
            

        }

    }
}
