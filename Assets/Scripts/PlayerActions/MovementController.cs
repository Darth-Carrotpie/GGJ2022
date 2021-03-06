using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    Turtle turtle;
    bool accelerating;
    bool decelerating;
    float turtleSpeed = 2f;
    bool isHiding;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StartListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.Input.ChangeHidden(), OnChangeHidden);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StopListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.Input.ChangeHidden(), OnChangeHidden);
    }
    void OnStartGame(GameMessage msg) {
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnChangeHidden(GameMessage msg) {
        if (turtle.playerID != msg.playerID)return;
        isHiding = !isHiding;
        accelerating = false;
    }
    void OnAccelerate(GameMessage msg) {
        if (isHiding)return;
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
        if (isHiding)return;
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
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            if (velocity.magnitude < 2f)
                ChangeSpeed(turtleSpeed);
        }
        if (decelerating) {
            accelerating = false;
            Decelerate();
        }
    }

    void ChangeSpeed(float speed) {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Acceleration);
    }

    void Decelerate() {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity = velocity / 1.05f;
    }
}