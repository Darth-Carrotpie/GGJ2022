using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExampleListener : MonoBehaviour {
    void Start() {
        EventCoordinator.StartListening(EventName.Input.StartLevel(), OnStartLevel);
    }

    void OnDestroy() {
        EventCoordinator.StopListening(EventName.Input.StartLevel(), OnStartLevel);
    }

    void OnStartLevel(GameMessage msg) {
        Debug.Log("coords on start: " + msg.coordinates);
    }

    void Update() {

    }
}