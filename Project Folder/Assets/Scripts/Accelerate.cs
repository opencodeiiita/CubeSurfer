using UnityEngine;

public class Accelerate : MonoBehaviour
{
   
    public Rigidbody rb;
    public float initialForce = 0f;   
    public float maxForce = 250f;  
    public float accelerationTime = 0.5f;
    private float currentForce = 0f;   

    public TrailRenderer tr;

    void Start()
    {
        currentForce = initialForce;
    }
    
  void FixedUpdate()
    {
        tr.enabled=false;
        
        if(Input.GetKey("w"))
    {
        tr.enabled=true;

        float t = Mathf.Clamp01(Time.time / accelerationTime);
        currentForce = Mathf.Lerp(initialForce, maxForce, t);

        rb.AddForce(transform.forward * currentForce, ForceMode.Force);
    }
    }
}
