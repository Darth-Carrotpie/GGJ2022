using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsBucket : Singleton<InputsBucket> {

    public List<PlayerInputs> inputs;

    public static PlayerInputs GetInputs(int inputInt) {
        return Instance.inputs[inputInt];
    }
    public static PlayerInputs GetDefault() {
        return Instance.inputs[0];
    }
}