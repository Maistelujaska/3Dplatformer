using UnityEngine;

public class Player : MonoBehaviour
{

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rb;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    public int superJumpsRemaining;
    private Logic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicC").GetComponent<Logic>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontalInput * 3, rb.linearVelocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.2f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 8f;
            if(superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining -= 1;
                logic.RemoveScore(1);
            }
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            if (other.gameObject.tag == "Dcoin")
            {
                logic.AddScore(1);
                superJumpsRemaining += 1;
            }
            else
            {
                logic.AddScore(5);
                superJumpsRemaining += 5;
            }
            Destroy(other.gameObject);
            //Destroy Coins
            //superJumpsRemaining+=1;
        }
    }
    

}
