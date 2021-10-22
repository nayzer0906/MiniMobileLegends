using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    [SerializeField] private FixedJoystick moveJoystick;
    
    private Animator playerAnim;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (moveJoystick.isDraging)
        {
            playerAnim.SetBool("Rival_Run", true);
            RotateCharacter();
            MoveCharacter();
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
}
