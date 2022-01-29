using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
    public GameObject menuButtonPanel;
    public GameObject gameplayPanel;
    public GameObject playerPanelPrefab;

    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.System.TurtleCreated(), OnPlayerCreate);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.System.TurtleCreated(), OnPlayerCreate);
    }

    void OnStartGame(GameMessage msg) {
        menuButtonPanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    void OnPlayerCreate(GameMessage msg) {
        GameObject newPanel = Instantiate(playerPanelPrefab);
        newPanel.transform.parent = gameplayPanel.transform;
        newPanel.GetComponent<PlayerPanelController>().playerID = msg.playerID;
    }
}