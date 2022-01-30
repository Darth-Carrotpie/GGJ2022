using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFireballShoot : MonoBehaviour {

    Turtle turtle;
    public GameObject effect;
    public Transform source;

    private void Start() {
        if (turtle == null) turtle = GetComponent<Turtle>();
        EventCoordinator.StartListening(EventName.Input.Fireball(), Shoot);
    }

    void OnChangeHidden(GameMessage msg)
    {
        if (turtle.playerID != msg.playerID) return;
    }

   void Shoot(GameMessage msg) {
        if (turtle.playerID == msg.playerID)
        {
            GameObject fx = Instantiate(effect, source.position, source.rotation);
        }
    }
}