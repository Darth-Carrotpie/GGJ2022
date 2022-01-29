using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    Turtle turtle;
    bool accelerating;
    bool decelerating;
    float turtleSpeed = 2f;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StartListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StopListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg) {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnAccelerate(GameMessage msg) {
        if (turtle.playerID == msg.playerID) {
            if (msg.contState == ContStateEnum.Start) {
                accelerating = true;
            }
            if (msg.contState == ContStateEnum.Stop) {
                accelerating = false;
            }
        }
    }
    void OnDecelerate(GameMessage msg) {
        if (turtle.playerID == msg.playerID) {
            if (msg.contState == ContStateEnum.Start) {
                decelerating = true;
            }
            if (msg.contState == ContStateEnum.Stop) {
                decelerating = false;
            }
        }
    }
    void Update() {
        if (accelerating) {
            decelerating = false;
            ChangeSpeed(turtleSpeed);
        }
        if (decelerating) {
            accelerating = false;
            ChangeSpeed(-turtleSpeed * 2);
        }
    }

    void ChangeSpeed(float speed) {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Acceleration);
    }

}