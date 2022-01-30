using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleFireballShoot : MonoBehaviour {

    public GameObject effect;
    public Transform source;

    private void Start() {
        EventCoordinator.StartListening(EventName.Input.Fireball(), Shoot);
    }

    void Shoot(GameMessage msg) {
        GameObject fx = Instantiate(effect, source.position, source.rotation);
    }
}