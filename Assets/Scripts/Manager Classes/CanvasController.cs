using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
    public GameObject menuButtonPanel;
    public GameObject gameplayPanel;
    public GameObject endGamePanel;
    public GameObject playerPanelPrefab;

    void Start() {
        EventCoordinator.StartListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StartListening(EventName.System.TurtleCreated(), OnPlayerCreate);
        EventCoordinator.StartListening(EventName.System.GameEnd(), OnEnd);
    }
    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.System.StartGame(), OnStartGame);
        EventCoordinator.StopListening(EventName.System.TurtleCreated(), OnPlayerCreate);
        EventCoordinator.StopListening(EventName.System.GameEnd(), OnEnd);
    }

    void OnStartGame(GameMessage msg) {
        menuButtonPanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    void OnPlayerCreate(GameMessage msg) {
        if (msg.playerID > 10) {
            GameObject newPanel = Instantiate(playerPanelPrefab);
            newPanel.transform.parent = gameplayPanel.transform;
            newPanel.GetComponent<PlayerPanelController>().playerID = msg.playerID;
        }
    }
    void OnEnd(GameMessage msg) {
        endGamePanel.SetActive(true);
        gameplayPanel.SetActive(false);
    }
}