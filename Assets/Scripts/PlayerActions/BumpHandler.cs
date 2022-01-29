using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpHandler : MonoBehaviour {
    Turtle turtle;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Player.Bump(), OnBump);
    }

    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Player.Bump(), OnBump);
    }
    void OnBump(GameMessage msg) {

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.relativeVelocity.magnitude > 2) {
            Vector3 theirVelocity = collision.rigidbody.velocity;
            Vector3 myVelocity = GetComponent<Rigidbody>().velocity;
            if (theirVelocity.magnitude > myVelocity.magnitude)return;
            Turtle targetTurtle = collision.collider.gameObject.GetComponentInParent<Turtle>();
            float targetHiddenCoef = targetTurtle.GetComponent<HideController>().isHiding ? 0.2f : 1f;
            float meHiddenCoef = GetComponent<HideController>().isHiding ? 3f : 1f;
            targetTurtle.GetComponent<Rigidbody>().AddForce(myVelocity.normalized * BumpPowerController.GetPower(turtle.playerID) * targetHiddenCoef * meHiddenCoef, ForceMode.Impulse);
            BumpPowerController.IncreasePower(turtle.playerID);
            EventCoordinator.TriggerEvent(EventName.Player.Bump(), GameMessage.Write().WithTargetTurtle(targetTurtle).WithSourceTurtle(turtle));
        }
    }
}