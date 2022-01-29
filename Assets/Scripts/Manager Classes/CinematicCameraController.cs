using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraController : MonoBehaviour {
    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg) {
        gameObject.SetActive(false);
    }
}