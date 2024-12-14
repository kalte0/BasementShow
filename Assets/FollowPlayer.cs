using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float playerRangeFromCenter = 5.0f; 
    public bool showPlayerRange = false; 
    public float drag = 0.85f; // every frame, multiply the velocity by this amount to make it smaller.
    public float stopSpeed = 0.01f; // once the velocity is <= this, stop moving. 
    private float velocity = 0.0f; // on x axis. 
    
    
    // Start is called before the first frame updates
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += playerOutOfRange(); 

        if (Mathf.Abs(velocity) <= stopSpeed) { 
            velocity = 0.0f; 
        }
        else {
            velocity *= drag; 
            this.transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        }
        //Debug.Log("velocity: " + velocity);  
    }

    void OnDrawGizmos() { 
        if (showPlayerRange) { 
            Gizmos.color = new Color(1, 0, 0, 0.5f); 
            Gizmos.DrawCube(transform.position, new Vector3(playerRangeFromCenter, playerRangeFromCenter+25, 0));
        }
    }


    float playerOutOfRange() { 
        GameObject player = GameObject.Find("Eleanor"); 
        if (player == null) { 
            Debug.Log("Player not found"); 
            return -99999; 
        }
        float playerX = player.transform.position.x; 
        float thisX = this.transform.position.x; 

        float distance = playerX - thisX; // negative if player is left of box, positive if to right of box. 
        //Debug.Log(distance);
        if (Mathf.Abs(distance) > playerRangeFromCenter) { 
            return distance - playerRangeFromCenter; 
        }
        return 0; 
    }

}
