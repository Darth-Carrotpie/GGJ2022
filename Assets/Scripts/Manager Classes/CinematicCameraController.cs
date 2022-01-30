using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraController : MonoBehaviour {

    void Start() {
        EventCoordinator.StartListening(EventName.Environment.ChurchCleanUp(), OnChurchCleanUp);
        EventCoordinator.StartListening(EventName.System.GameEnd(), OnEndGame);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Environment.ChurchCleanUp(), OnChurchCleanUp);
        EventCoordinator.StopListening(EventName.System.GameEnd(), OnEndGame);
    }
    void OnChurchCleanUp(GameMessage msg) {
        gameObject.SetActive(false);
    }
    void OnEndGame(GameMessage msg) {
        gameObject.SetActive(true);
    }
}