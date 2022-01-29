using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour {
    Turtle turtle;
    float hideBoost = 4f;
    public bool isHiding;
    void Start() {
        if (turtle == null)turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.ChangeHidden(), OnChangeHidden);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.ChangeHidden(), OnChangeHidden);
    }
    void Update() {
        //if (isHiding)
    }
    void OnChangeHidden(GameMessage msg) {
        if (turtle.playerID != msg.playerID)return;
        isHiding = !isHiding;
        if (isHiding) {
            Boost(hideBoost);
            EventCoordinator.TriggerEvent(EventName.Player.HasHidden(), msg);
        } else {
            EventCoordinator.TriggerEvent(EventName.Player.HasAppeared(), msg);
        }
    }
    void Boost(float speed) {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}