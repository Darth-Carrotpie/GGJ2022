using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraController : MonoBehaviour {
    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.System.GameEnd(), OnEndGame);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.System.GameEnd(), OnEndGame);
    }
    void OnStartGame(GameMessage msg) {
        gameObject.SetActive(false);
    }
    void OnEndGame(GameMessage msg) {
        gameObject.SetActive(true);
    }
}