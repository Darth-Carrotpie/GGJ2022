using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    Turtle turtle;
    bool turning;
    float turnSpeed = 0.3f;
    TurnSideEnum turnSide;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.Turn(), OnTurn);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.Turn(), OnTurn);

    }

    void OnTurn(GameMessage msg) {
        if (turtle.playerID == msg.playerID) {
            if (msg.contState == ContStateEnum.Start) {
                turning = true;
                turnSide = msg.turnSide;
            }
            if (msg.contState == ContStateEnum.Stop) {
                turning = false;
            }
        }
    }

    void Update() {
        if (turning) {
            ChangeTurnAngle(turnSpeed);
        }
    }

    void ChangeTurnAngle(float speed) {

        float rotateRight = turnSide == TurnSideEnum.Right ? turnSpeed : -turnSpeed;
        GetComponent<Transform>().Rotate(0, rotateRight, 0, Space.Self);
    }
}