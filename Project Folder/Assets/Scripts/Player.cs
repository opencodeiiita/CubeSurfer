using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event EventHandler OnGameOver;

    public static Player Instance { get; private set; }

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float sidewayForce = 20f;
    private float forceMultiplier = 100f;

    private bool hasCollided = false;

    float initialZ;//stores initial z coordinate for score purpose
    const float scoreMultiplier = 0.7f;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Another instance of Player already exists.");
            return;
        }
        Instance = this;
        initialZ = transform.position.z;
    }

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

            OnGameOver?.Invoke(this, EventArgs.Empty);

            Debug.Log("Game Over");
        }
    }

    public bool HasCollided()
    {
        return hasCollided;
    }

    public int getScore()
    {
        return Mathf.RoundToInt(scoreMultiplier * (transform.position.z - initialZ));
    }

}
