using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleModel : MonoBehaviour {
    Turtle turtle;
    public Animator anim;
    bool isHiding;
    void Start() {
        if (turtle == null)turtle = GetComponentInParent<Turtle>();
        if (anim == null)anim = GetComponentInChildren<Animator>();
        EventCoordinator.StartListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StartListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StartListening(EventName.Player.HasHidden(), OnHasHidden);
        EventCoordinator.StartListening(EventName.Player.HasAppeared(), OnHasAppeared);
    }
    void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.Accelerate(), OnAccelerate);
        EventCoordinator.StopListening(EventName.Input.Decelerate(), OnDecelerate);
        EventCoordinator.StopListening(EventName.Player.HasHidden(), OnHasHidden);
        EventCoordinator.StopListening(EventName.Player.HasAppeared(), OnHasAppeared);
    }
    void OnHasHidden(GameMessage msg) {
        if (turtle.playerID != msg.playerID)return;
        anim.SetBool("Hidden", true);
        isHiding = true;

    }
    void OnHasAppeared(GameMessage msg) {
        if (turtle.playerID != msg.playerID)return;
        anim.SetBool("Hidden", false);
        isHiding = false;
    }

    void OnAccelerate(GameMessage msg) {
        if (isHiding || turtle.playerID != msg.playerID)return;
        if (msg.contState == ContStateEnum.Start) {
            anim.SetBool("Walking", true);
        }
        if (msg.contState == ContStateEnum.Stop) {
            anim.SetBool("Walking", false);
        }
    }
    void OnDecelerate(GameMessage msg) {
        if (isHiding || turtle.playerID != msg.playerID)return;
        if (msg.contState == ContStateEnum.Start) {
            anim.SetBool("Walking", true);
        }
        if (msg.contState == ContStateEnum.Stop) {
            anim.SetBool("Walking", false);
        }
    }
}