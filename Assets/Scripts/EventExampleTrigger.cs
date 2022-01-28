using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExampleTrigger : MonoBehaviour {
    void Start() {

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            EventCoordinator.TriggerEvent(EventName.System.StartGame(), GameMessage.Write().WithCoordinates(new Vector2(0, 0)));
        }
    }
}