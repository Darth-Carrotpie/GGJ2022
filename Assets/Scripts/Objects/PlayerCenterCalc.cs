using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenterCalc : MonoBehaviour {
    List<Transform> objectsToFollow;
    bool gameStarted = false;
    bool gameEnded = false;
    Vector3 velocity;
    float followTime = 0.75f;
    float zOffset = 4f;
    float recalcTime = 0.5f;
    float timer;
    Vector3 targetVec;
    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.System.PlayerDeath(), OnDeath);
        EventCoordinator.StartListening(EventName.System.GameEnd(), OnEndGame);
    }

    void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.System.PlayerDeath(), OnDeath);
        EventCoordinator.StopListening(EventName.System.GameEnd(), OnEndGame);
    }
    void OnDeath(GameMessage msg) {
        objectsToFollow.Remove(msg.sourceTurtle.transform);
    }
    void OnEndGame(GameMessage msg) {
        GetComponentInChildren<Camera>().enabled = false;
        gameEnded = true;
    }

    void OnStartGame(GameMessage msg) {
        objectsToFollow = TurtleFactory.GetPlayerTurtles();
        GetComponentInChildren<Camera>().enabled = true;
        gameStarted = true;
    }

    void FixedUpdate() {
        if (!gameStarted || objectsToFollow.Count == 0 || gameEnded)return;
        MoveToCenter();
        RotateForFun();
        timer += Time.deltaTime;
        if (timer > recalcTime) {
            timer = 0;
            targetVec = CalculateCenter(); // + new Vector3(-zOffset, 0, -zOffset);
        }
    }

    void MoveToCenter() {
        transform.position = Vector3.SmoothDamp(transform.position, targetVec, ref velocity, followTime);
    }
    void RotateForFun() {
        transform.localRotation = Quaternion.Euler(0, Mathf.Sin(Time.time) * 3f + Time.time * 2, 0);
    }
    float CalculateWidth() {
        var objectsBounds = new Bounds(objectsToFollow[0].position, Vector3.zero);
        for (int i = 0; i < objectsToFollow.Count; i++) {
            objectsBounds.Encapsulate(objectsToFollow[i].position);
        }

        return objectsBounds.size.x;
    }

    Vector3 CalculateCenter() {
        if (objectsToFollow.Count == 1)return objectsToFollow[0].position;

        var objectsBounds = new Bounds(objectsToFollow[0].position, Vector3.zero);
        for (int i = 0; i < objectsToFollow.Count; i++) {
            objectsBounds.Encapsulate(objectsToFollow[i].position);
        }
        return objectsBounds.center;
    }
}