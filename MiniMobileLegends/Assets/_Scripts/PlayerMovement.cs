using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    [SerializeField] private FixedJoystick moveJoystick;
    [SerializeField] public HealthBar healthBar;
    private bool isAlive = false;

    private Rigidbody playerRigidbody;
    private Animator playerAnim;
    private PlayerController playerController;
    private Transform playerTransform;
    public void Init()
    {
        playerRigidbody = transform.GetChild(0).GetComponent<Rigidbody>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerTransform = transform.GetChild(0).transform;
        isAlive = true;
    }

    private void FixedUpdate()
    {
        if (!isAlive) return;

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

    

    private void RotateCharacter()
    {
        var charLook = new Vector3(moveJoystick.Horizontal, 0f, moveJoystick.Vertical);
        playerTransform.rotation = Quaternion.LookRotation(charLook);
    }

    private void MoveCharacter()
    {
        playerRigidbody.velocity = playerTransform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TurretEnemy")
        {
            playerTransform.LookAt(other.transform);
            //playerAnim.SetTrigger("Rival_Shoot");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TurretEnemy")
        {
            if (!playerController.IsCooldown())
                StartCoroutine(playerController.TakeDamage(10));
        }
    }
}
