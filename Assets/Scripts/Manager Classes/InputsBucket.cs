using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsBucket : Singleton<InputsBucket> {

    public List<PlayerInputs> inputs;

    public static PlayerInputs GetInputs(int playerID) {
        return Instance.inputs[playerID];
    }
}