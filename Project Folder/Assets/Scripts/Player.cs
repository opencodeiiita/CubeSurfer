using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float sidewayForce = 20f;
    private float forceMultiplier = 100f;

    private bool hasCollided = false;

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (hasCollided) return;

        Vector2 inputVector = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        inputVector.y = 0; //we dont want to control the forward/back direction
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3();
        moveDir.x = inputVector.x * sidewayForce; //for left and right using input
        moveDir.z = 1f * forwardForce;  //for constant front movement
        moveDir *= Time.deltaTime;

        rb.AddForce(moveDir * forceMultiplier);
    }

    void OnCollisionEnter(Collision collision)
    {
        //in future we can use tags or even use TryGetComponent<>
        if (collision.collider.name != "Ground")
        {
            //in future we can call an event here
            hasCollided = true;
            Debug.Log("Game Over");
        }
    }

}
