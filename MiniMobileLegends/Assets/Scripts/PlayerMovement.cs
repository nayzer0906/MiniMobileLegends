using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    [SerializeField] private FixedJoystick moveJoystick;
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    private int currentHealth;
    
    private Animator playerAnim;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if (moveJoystick.isDraging)
        {
            playerAnim.SetBool("Rival_Run", true);
            RotateCharacter();
            MoveCharacter();
        }
        else
        {
            playerAnim.SetBool("Rival_Run", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth/ (float)maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void RotateCharacter()
    {
        var charLook = new Vector3(moveJoystick.Horizontal, 0f, moveJoystick.Vertical);
        transform.rotation = Quaternion.LookRotation(charLook);
    }

    private void MoveCharacter()
    {
        playerRigidbody.velocity = this.transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(10);
    }
}
