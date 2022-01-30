using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsController : MonoBehaviour {
    float timer;
    float timeForDestruction = 0.5f;
    float timeForCleanup = 4f;

    bool gameStarted;
    bool triggered;
    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg) {
        gameStarted = true;
    }
    void Update() {
        if (!gameStarted)return;
        timer += Time.deltaTime;
        if (timeForDestruction > timer && !triggered) {
            triggered = true;
            EventCoordinator.TriggerEvent(EventName.Environment.StartChurchDestruction(), GameMessage.Write());
        }
        if (timer > timeForCleanup) {
            EventCoordinator.TriggerEvent(EventName.Environment.ChurchCleanUp(), GameMessage.Write());
            Destroy(this);
        }
    }
}