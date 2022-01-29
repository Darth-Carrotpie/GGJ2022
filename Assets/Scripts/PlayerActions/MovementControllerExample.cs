using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerExample : MonoBehaviour {
    Turtle turtle;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.Accelerate(), OnMoveStart);
    }
    void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.Accelerate(), OnMoveStart);

    }
    void OnMoveStart(GameMessage msg) {
        if (msg.playerID == turtle.playerID) {
            Debug.Log("move: " + msg.playerID);
            //commence movement
        }
    }
}