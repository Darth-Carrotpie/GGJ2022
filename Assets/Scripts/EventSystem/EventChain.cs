using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventChain : MonoBehaviour {
    void Start() {
        EventCoordinator.Attach(EventName.System.StartGame(), OnStartGame);
    }
    void OnDestroy() {
        EventCoordinator.Detach(EventName.System.StartGame(), OnStartGame);
    }
    void OnStartGame(GameMessage msg) {
        EventCoordinator.TriggerEvent(EventName.UI.ShowCooldownNotReady(), msg);
    }
}