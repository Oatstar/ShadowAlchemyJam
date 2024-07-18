using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTriggerController : MonoBehaviour
{
    LevelController levelController;
    private void Start()
    {
        levelController = GetComponentInParent<LevelController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelController.TriggerLevelEnd();
    }
}
