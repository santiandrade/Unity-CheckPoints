using UnityEngine;

/// <summary>
/// Simple player controller based on a Rigidbody
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Public Variables
    
    public float Speed = 8.0F;
    public float JumpForce = 10.0F; 

    #endregion

    #region Private Variables
    
    private Rigidbody thisRigidbody;
    private bool isJumping; 

    #endregion

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        isJumping = false;
    }

    void Update()
    {
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            thisRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        thisRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, thisRigidbody.velocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;

        if (collision.gameObject.tag == "Enemy")
        {
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
    }
}