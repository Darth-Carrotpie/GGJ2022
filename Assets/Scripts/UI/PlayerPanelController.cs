using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerPanelController : MonoBehaviour {

    public TextMeshProUGUI text;
    public int playerID;

    void Start() {
        EventCoordinator.StartListening(EventName.Player.PowerIncreased(), OnPowerChanged);
        EventCoordinator.StartListening(EventName.System.TurtleDestroyed(), PanelRemove);
    }

    private void OnDestroy() {
        EventCoordinator.StopListening(EventName.Player.PowerIncreased(), OnPowerChanged);
        EventCoordinator.StopListening(EventName.System.TurtleDestroyed(), PanelRemove);
    }

    void OnPowerChanged(GameMessage msg) {
        text.text = BumpPowerController.GetPower(playerID) * 10f + "%";
    }
    void PanelRemove(GameMessage msg) {
        if (msg.playerID == playerID) {
            Destroy(gameObject);
        }
    }
}