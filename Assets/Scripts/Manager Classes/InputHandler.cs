using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public int playerID;
    public PlayerInputs myInputs;

    public static string Accelerate() { return "Input_Accelerate"; }
    public static string Decelerate() { return "Input_Decelerate"; }
    public static string Turn() { return "Input_Turn"; }
    public static string Hide() { return "Input_Hide"; }
    public static string Fireball() { return "Input_Fireball"; }

    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(myInputs.accelerate)) {

        }
        if (Input.GetKeyUp(myInputs.accelerate)) {

        }
        if (Input.GetKeyDown(myInputs.decelerate)) {

        }
        if (Input.GetKeyUp(myInputs.decelerate)) {

        }
        if (Input.GetKeyDown(myInputs.turnLeft)) {

        }
        if (Input.GetKeyUp(myInputs.turnLeft)) {

        }
        if (Input.GetKeyDown(myInputs.turnRight)) {

        }
        if (Input.GetKeyUp(myInputs.turnRight)) {

        }
        if (Input.GetKeyDown(myInputs.hide)) {

        }
        if (Input.GetKeyDown(myInputs.fireball)) {

        }
    }
}