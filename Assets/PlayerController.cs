using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] bool inLightZone = false;
    [SerializeField] int playerHealth  = 50;
    int playerMaxHealth = 50;
    bool noDamagePeriod = false;
    float gracePeriod = 0.01f;

    void Start()
    {
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        playerHealth = playerMaxHealth;
        healthSlider.value = playerHealth;

        rb = GetComponent<Rigidbody2D>();
    }

    public void InLightArea(bool state, GameObject currentLightSource)
    {
        if(state)
        {
            // Perform the raycast
            Vector2 direction = currentLightSource.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

            // Check if the raycast hit anything
            if (hit.collider != null)
            {
                // Check if the collider has the tag "wall"
                if (hit.collider.CompareTag("ShadowBlocker"))
                {
                    Debug.Log("Raycast hit a shadowBlocker!");
                    inLightZone = false;
                }
                else if (hit.collider.gameObject == currentLightSource)
                {
                    Debug.Log("Raycast hit the current light source!");
                    inLightZone = true;
                }
            }
        }
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void ReceiveDamage()
    {
        if(!noDamagePeriod)
        {
            playerHealth--;
            healthSlider.value = playerHealth;
            StartCoroutine(GracePeriodTimer());
        }
    }

    IEnumerator GracePeriodTimer()
    {
        noDamagePeriod = true;
        yield return new WaitForSeconds(gracePeriod);
        noDamagePeriod = false;
    }
}
