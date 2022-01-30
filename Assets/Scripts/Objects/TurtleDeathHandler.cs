using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleDeathHandler : MonoBehaviour {
    Turtle turtle;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<DeathPlane>() == null)return;
        EventCoordinator.TriggerEvent(EventName.System.PlayerDeath(), GameMessage.Write().WithSourceTurtle(turtle));
    }
}