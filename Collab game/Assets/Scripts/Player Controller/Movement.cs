using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;
    public float groundDrag = 6f; // new

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
        rigidBody.drag = groundDrag; // what i think is missing
    }

    private void Update()
    {
        myInput();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        //Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rigidBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
