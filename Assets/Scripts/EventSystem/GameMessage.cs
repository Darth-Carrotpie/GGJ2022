using System;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0414
//idea for upgrade: this could be composite, made out of generic MessagePage or smth like it, whithin which would contain isSet states and other things if needed;

//Naming Convention:
//1. Message parts must be named starting "With".
//2. Message part name must contain meaningfull 1-2 words of what the part is meant to contain.
//3. Meaningfull part must not contain abstracts, but rather concrete purposes. I.e. not "WithString", but "WithPlayerName".

public class GameMessage : BaseMessage {
    public static GameMessage Write() {
        return new GameMessage();
    }

    public Vector2 _coordinates;
    private bool coordinatesSet;
    public Vector2 coordinates {
        get {
            if (coordinatesSet)
                return _coordinates;
            else throw new Exception("No <coordinates> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithCoordinates(Vector2 value) {
        _coordinates = value;
        coordinatesSet = true;
        return this;
    }

    public Transform _playerTransform;
    private bool playerTransformSet;
    public Transform playerTransform {
        get {
            if (playerTransformSet)
                return _playerTransform;
            else throw new Exception("No <playerTransform> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithPlayerTransform(Transform value) {
        _playerTransform = value;
        playerTransformSet = true;
        return this;
    }

    //example to handle empty messages better
    /*private string _strMessage;
    public string strMessage {
        get {
            if (strMessageSet)
                return _strMessage;
            else throw new Exception("No strMessage was set before request for GameMessage: " + this);
        }
        set { _strMessage = value; }
    } //must not be type of bool (if bool needed, use int)
    private bool strMessageSet; // must be private bool
    public GameMessage WithStringMessage(string value) {
        strMessage = value;
        strMessageSet = true;
        return this;
    }*/
}