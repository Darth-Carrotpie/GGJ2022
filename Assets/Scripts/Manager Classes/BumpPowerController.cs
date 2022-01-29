using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpPowerController : Singleton<BumpPowerController> {
    public float powerIncrement = 0.2f;
    public Dictionary<int, float> power = new Dictionary<int, float>();

    public static void IncreasePower(int playerID) {
        if (Instance.power.ContainsKey(playerID)) {
            Instance.power[playerID] += Instance.powerIncrement;
            EventCoordinator.TriggerEvent(EventName.Player.PowerIncreased(), GameMessage.Write().WithPlayerID(playerID));
        } else {
            Instance.power[playerID] = 1f;
        }
    }

    public static float GetPower(int playerID) {
        if (!Instance.power.ContainsKey(playerID))
            Instance.power[playerID] = 1f;
        return Instance.power[playerID];

    }
}