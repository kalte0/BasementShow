using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HazelPositioner
{

    static int Pointer = 0; // points to the frame of Hazel's current position in the underlying data structure. Eleanor fills in information on the previous frame. 
    static int FrameLag = 100; // number of frames between Eleanor's current frame and Hazel's current frame. 
    static int EleanorPointer = (Pointer -  1); 

    

    static float[,] path = new float[FrameLag, 4]; // 3 values store x, y and sprite rotation.
    private static GameObject EleanorObj = GameObject.Find("Eleanor"); // store reference to Eleanor. 
    private static float zValue = EleanorObj.transform.position.z; // Set to the same z value as Eleanor. 

    /*
    * The HazelPositioner maintains up to date information in its Update() method, which can then be fetched with GetPosition(). 
    */
    public static void Update() { 
        if (Eleanor.moving == false) { 
            return; // don't update if Eleanor isn't moving.
        }
        if (EleanorPointer < 0) { 
            EleanorPointer = FrameLag + EleanorPointer; 
        } else if (EleanorPointer >= 100) { 
            EleanorPointer = EleanorPointer - FrameLag; 
        }

        Debug.Log("EleanorPointer: " + EleanorPointer);
        Debug.Log("Pointer: " + Pointer);

        // fills in information at position (Pointer - 1)
        path[EleanorPointer, 0] = EleanorObj.transform.position.x; // x
        path[EleanorPointer, 1] = EleanorObj.transform.position.y; // y
        path[EleanorPointer, 2] = zValue; // z (Shouldn't change, so I capture it at the start instead of looking it up every time.)
        if (Eleanor.GetRotation() == 0) { 
            path[EleanorPointer, 3] = 0f; // rotation (0 is up, 1 is left, 2 is down, 3 is right)
        }
        else if (Eleanor.GetRotation() == 1) { 
            path[EleanorPointer, 3] = 1f; // rotation (0 is up, 1 is left, 2 is down, 3 is right)
        }
        else if (Eleanor.GetRotation() == 2) { 
            path[EleanorPointer, 3] = 2f; // rotation (0 is up, 1 is left, 2 is down, 3 is right)
        }
        else if (Eleanor.GetRotation() == 3) { 
            path[EleanorPointer, 3] = 3f; // rotation (0 is up, 1 is left, 2 is down, 3 is right)
        }
        else { 
            Debug.Log("Invalid rotation value: " + Eleanor.GetRotation()); 
        }
        path[EleanorPointer, 3] = 0f; // rotation (0 is up, 1 is left, 2 is down, 3 is right)

        Pointer = (Pointer + 1) % FrameLag;
        EleanorPointer = Pointer - 1;
    }

    // Note to self: Does this kind of thing need atomic variables / the ability for multiple things to make calls to read / write simultaneously? 
    public static Vector3 GetPosition() { 
        return new Vector3(path[Pointer, 0], path[Pointer, 1], path[Pointer, 2]);
    }

    public static float GetRotation()
    { 
        return path[Pointer, 3];
    }

}
