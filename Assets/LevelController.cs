using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerPrefab;
    GameObject playerObject;
    public List<GameObject> lightObjects;
    public List<GameObject> shadowBlockers = new List<GameObject> { };

    private void Awake()
    {
        SpawnPlayer();

        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "ShadowBlocker")
                shadowBlockers.Add(child.gameObject);

            if (child.gameObject.name == "FOV")
                lightObjects.Add(child.gameObject);
        }
        
        foreach (GameObject lightObject in lightObjects)
        {
            lightObject.GetComponent<FovController>().SetStartValues(playerObject);
        }

    }

    private void Start()
    {
        foreach (GameObject shadowBlock in shadowBlockers)
        {
            ShadowCaster2D shadowCaster = shadowBlock.transform.GetComponent<ShadowCaster2D>();
            if (shadowCaster != null)
            {
                Debug.Log("destroying shadowcastrers");
                DestroyImmediate(shadowCaster);
                shadowBlock.AddComponent<ShadowCaster2D>();
            }
            else
                Debug.Log("shadowcaster is null");

            //shadowBlock.AddComponent<ShadowCaster2D>();
            //shadowBlock.GetComponent<ShadowCaster2D>().trimEdge = 0.01f;
            //shadowBlock.GetComponent<ShadowCaster2D>().alphaCutoff = 0f;
        }
    }

    void SpawnPlayer()
    {
        playerObject = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void TriggerLevelEnd()
    {
        Debug.Log("Level Ends");
    }
  
}
