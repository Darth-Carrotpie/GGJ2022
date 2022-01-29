using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class InputFactory : Singleton<InputFactory> {

    List<InputHandler> handlers = new List<InputHandler>();
    int inputID = 0;

    public static void CreateInputsForPlayer(int playerID) {
        InputHandler newHandler = Instance.gameObject.AddComponent<InputHandler>();
        Instance.handlers.Add(newHandler);
        newHandler.playerID = playerID;
        newHandler.inputID = Instance.inputID;
        newHandler.SetInputs(InputsBucket.GetInputs(Instance.inputID));
        Instance.inputID++;
    }
    public static void DestroyInputsForPlayer(int playerID) {
        InputHandler handler = Instance.handlers.Where(x => x.playerID == playerID).FirstOrDefault();
        Instance.handlers.Remove(handler);
        Destroy(handler);
        Instance.inputID--;
    }
}