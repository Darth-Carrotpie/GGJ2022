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

    void Shoot(GameMessage msg) {
        GameObject fx = Instantiate(effect, source.position, source.rotation);
    }
}