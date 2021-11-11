
using UnityEngine;

public class PlayerController3d : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] float smoothness = 0.3f;
    [SerializeField] float sideForce;
    [SerializeField] string watIsGround;
    [SerializeField] float jumpDuration;
    
    bool isGrounded;
    private float jumpCounter;
    private  Rigidbody rigidbody;
    private Vector3 vector = Vector3.zero;

    [SerializeField] float jumpMullti;
    [SerializeField] float fallMullti;
    bool jump = false;
    bool fall = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == watIsGround)
        {
            isGrounded = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == watIsGround)
        {
            isGrounded = false;
            
        }
    }

    
    public void move(float sideDir,bool requestJump,bool isFalling)
    {
        
        if (requestJump && isGrounded)
        {
            jump = true;
        }
        if (isFalling && !isGrounded)
        {
            fall = true;
        }
        Vector3 targetVelocity = new Vector3(sideDir * sideForce,rigidbody.velocity.y,rigidbody.velocity.z);

        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref vector, smoothness);


    }

   
   
    private void FixedUpdate()
    {
        if (jump)
        {
            rigidbody.AddForce(Vector3.up * jumpMullti, ForceMode.Impulse);
            jump = false;
        }
        if (fall)
        {
            rigidbody.AddForce(Vector3.up * -fallMullti, ForceMode.Impulse);
            fall = false;
        }
    }








}
