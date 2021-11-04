using System;
using System.Collections;
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
    
    private bool isCooldown = false;

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

    public IEnumerator TakeDamage(int damage)
    {
        isCooldown = true;
        currentHealth -= damage;
        healthBar.UpdateHealth((float)currentHealth/ (float)maxHealth);

        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
        
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
        if(other.tag == "TurretEnemy" || other.tag == "Enemy")
        {
            TakeDamage(10);
            transform.LookAt(other.transform);
            playerAnim.SetTrigger("Rival_Shoot");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TurretEnemy")
        {
            if (!isCooldown)
                StartCoroutine(TakeDamage(10));
        }
    }
}
