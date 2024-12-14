using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleanorMovement : MonoBehaviour
{
    public float horizontalSpeed = 0.5f;
    public float verticalSpeed = 0.5f;
    protected Rigidbody2D body;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16]; 
    protected const float shellRadius = 0.01f;
    public float interactableRadius = 0.5f;
    public GameObject QuestionDisplay = null;  // definitely needs to be moved on different iterations of this code. 

    public Sprite side = null; 
    public Sprite up = null; 
    public Sprite down = null; 
    private SpriteRenderer spriteRenderer = null; 
    //private Eleanor Eleanor = GameObject.Find("Eleanor").GetComponent<Eleanor>(); 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = GetMovementVector();
        // Debug.Log(move); 
        bool moved = PerformMovement(move); 
        if (!moved) { 
            Debug.Log("Wasn't able to move"); 
        }

        if (Input.GetKeyDown(KeyCode.Escape)) { 
            if (!Util.PopUpShown & !DialogueHandler.IsTextBoxShown()) { 
                Debug.Log("Call to Application.Exit()");
                //Application.Exit(); 
            }
        }
    }

    /// <summary>
    ///  Returns a Vector2 representing the desired movement of the player derived from WASD input
    /// </summary>
    /// <returns>Vector2 representing desired movement of the player.</returns>
    private Vector2 GetMovementVector() { 
        Vector2 move = new Vector2(0.0f, 0.0f); 

        if (Input.GetKey(KeyCode.W))
        {
            move.y = verticalSpeed * Time.deltaTime;
            Eleanor.SetRotation(0);
            spriteRenderer.sprite = up; 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move.y = -verticalSpeed * Time.deltaTime;
            Eleanor.SetRotation(2);
            spriteRenderer.sprite = down; 
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x = -horizontalSpeed * Time.deltaTime;
            Eleanor.SetRotation(1);
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = true; 
        
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x = horizontalSpeed * Time.deltaTime;
            Eleanor.SetRotation(3);
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = false;
        }

        
        return move; 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="move">a Vector2 describing the desired movement of the player</param>
    /// <returns>true if given movement is valid, and false otherwise. </returns>
    private bool PerformMovement(Vector2 move) { 
        /*if (move.magnitude < 0.02) { // if we're not moving don't bother updating things!
            Eleanor.moving = false;  
            return true; 
        }*/
        //Eleanor.moving = true; 
        int numCollisions = body.Cast(move, hitBuffer, move.magnitude + shellRadius);
        if (numCollisions == 0) // if moving in this direction means that we won't collide with anything
        {
            body.position += move;
            return true;
        }
        else { 
            Vector2 moveX = new Vector2(move.x, 0.0f);
            Vector2 moveY = new Vector2(0.0f, move.y);
            int numCollisionsX = body.Cast(moveX, hitBuffer, moveX.magnitude + shellRadius);
            int numCollisionsY = body.Cast(moveY, hitBuffer, moveY.magnitude + shellRadius);
            if (numCollisionsX == 0) { 
                body.position += moveX; 
                return true; 
            }
            else if (numCollisionsY == 0) { 
                body.position += moveY; 
                return true; 
            }
            return false; 
        }
    }
}
