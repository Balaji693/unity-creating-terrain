
using UnityEngine;
using UnityEngine.SceneManagement;
public class Playercontroller : MonoBehaviour
{
    public Animator animator;
    Vector3 movedir = Vector3.zero;
    public Rigidbody rb;
    public float gravity = 8f;
    public FixedJoystick leftjoystick;
    public Rightjoystick rightjoystick;
    public Joybutton button;
    protected float cameraangleY = 2f;
    protected float cameraanglespeed = 2f;
 
   
    // Start is called before the first frame update


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
     leftjoystick = FindObjectOfType<FixedJoystick>();
        rightjoystick = FindObjectOfType<Rightjoystick>();
        button = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {

    
        //  Movement();
        JoystickMovement();
        buttonscript();
        fall();
      
       
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {

            animator.SetInteger("conditions", 1);
            movedir = new Vector3(0, 0, 1);
            transform.rotation = Quaternion.LookRotation(movedir);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("conditions", 0);
            movedir = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("conditions", 1);
            movedir = new Vector3(0, 0, -1);
            transform.rotation = Quaternion.LookRotation(movedir);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("conditions", 0);
            movedir = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {

            animator.SetInteger("conditions", 1);
            movedir = new Vector3(-1, 0, 0);
            transform.rotation = Quaternion.LookRotation(movedir);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            animator.SetInteger("conditions", 0);
            movedir = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.LookRotation(movedir);

        }
        if (Input.GetKey(KeyCode.D))
        {

            animator.SetInteger("conditions", 1);
            movedir = new Vector3(1, 0, 0);
            transform.rotation = Quaternion.LookRotation(movedir);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            animator.SetInteger("conditions", 0);
            movedir = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.LookRotation(movedir);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetInteger("conditions", 2);
            movedir = new Vector3(0, 0, 1);
            Invoke("stop", 0.8f);
        }
    }
    void JoystickMovement()
    {

        movedir = new Vector3(leftjoystick.Horizontal * 1f, 0, leftjoystick.Vertical * 1f);
        if (leftjoystick.Vertical != 0f)
        {
            
            animator.SetInteger("conditions", 1);
         
            transform.rotation = Quaternion.LookRotation(movedir);
        }
        if (leftjoystick.Horizontal != 0f)
        {
         
            animator.SetInteger("conditions", 1);

            transform.rotation = Quaternion.LookRotation(movedir);
        }
        else
        {
            animator.SetInteger("conditions", 0);
            movedir = new Vector3(0, 0, 0);
        }
        cameraangleY += rightjoystick.Horizontal * cameraanglespeed;
        transform.rotation =  Quaternion.LookRotation(movedir);
        transform.rotation = Quaternion.AngleAxis(cameraangleY + Vector3.SignedAngle(Vector3.forward, movedir.normalized + Vector3.forward * 0.001f, Vector3.up), Vector3.up);
        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(cameraangleY, Vector3.up) * new Vector3(0, 3, -3);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
    }
   void stop()
    {
        animator.SetInteger("conditions", 0);
        button.pressed = false;
    }
    void buttonscript()
    {
        if (button.pressed)
        {
            animator.SetInteger("conditions", 2);
            Invoke("stop", 0.8f); 
           
        }
        else
        {
            return;
        }
    }
 
    void fall()
    {

        if(rb.position.y < -1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        
    }


}
