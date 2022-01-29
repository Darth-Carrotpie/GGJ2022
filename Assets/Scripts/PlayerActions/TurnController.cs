using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    Turtle turtle;
    bool turningLeft;
    bool turningRight;
    float turnSpeed = 1f;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.TurnLeft(), OnTurnLeft);
        EventCoordinator.StartListening(EventName.Input.TurnRight(), OnTurnRight);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.TurnRight(), OnTurnRight);
        EventCoordinator.StopListening(EventName.Input.TurnLeft(), OnTurnLeft);
    }

    void OnTurnRight(GameMessage msg) {
        if (turtle.playerID == msg.playerID) {
            if (msg.contState == ContStateEnum.Start) {
                turningRight = true;
            }
            if (msg.contState == ContStateEnum.Stop) {
                turningRight = false;
            }
        }
    }
    void OnTurnLeft(GameMessage msg) {
        if (turtle.playerID == msg.playerID) {
            if (msg.contState == ContStateEnum.Start) {
                turningLeft = true;
            }
            if (msg.contState == ContStateEnum.Stop) {
                turningLeft = false;
            }
        }
    }
    void Update() {
        if (turningLeft || turningRight) {
            ChangeTurnAngle(turnSpeed);
        }
    }

    void ChangeTurnAngle(float speed) {

        float rotateRight = turningRight ? turnSpeed : 0f;
        float rotateLeft = turningLeft ? -turnSpeed : 0f;
        GetComponent<Transform>().Rotate(0, rotateLeft + rotateRight, 0, Space.Self);
    }
}