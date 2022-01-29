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

    Vector2 _coordinates;
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

    Transform _playerTransform;
    private bool playerTransformSet;
    public Transform playerTransform {
        get {
            if (playerTransformSet)
                return _playerTransform;
            else throw new Exception("No <_playerTransform> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithPlayerTransform(Transform value) {
        _playerTransform = value;
        playerTransformSet = true;
        return this;
    }
    ContStateEnum _contState;
    private bool contStateEnumSet;
    public ContStateEnum contState {
        get {
            if (contStateEnumSet)
                return _contState;
            else throw new Exception("No <_contState> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithContState(ContStateEnum value) {
        _contState = value;
        contStateEnumSet = true;
        return this;
    }
    TurnSideEnum _turnSide;
    private bool turnSideSet;
    public TurnSideEnum turnSide {
        get {
            if (turnSideSet)
                return _turnSide;
            else throw new Exception("No <_turnSide> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithTurnSide(TurnSideEnum value) {
        _turnSide = value;
        turnSideSet = true;
        return this;
    }
    int _playerAmount;
    private bool playerAmountSet;
    public int playerAmount {
        get {
            if (playerAmountSet)
                return _playerAmount;
            else throw new Exception("No <_turnSide> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithPlayerAmount(int value) {
        _playerAmount = value;
        playerAmountSet = true;
        return this;
    }
    int _playerID;
    private bool playerIDSet;
    public int playerID {
        get {
            if (playerIDSet)
                return _playerID;
            else throw new Exception("No <_turnSide> was set before request for GameMessage: " + this);
        }
    }
    public GameMessage WithPlayerID(int value) {
        _playerID = value;
        playerIDSet = true;
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