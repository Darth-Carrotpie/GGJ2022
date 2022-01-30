using System.Collections.Generic;
using System.Linq;

//Naming Convention:
//1. Event names must be unique (thus add prefix of their master class for easier debugging).
//2. Event names must represent of what they do. If after what happened, then what they 'DID' (past tense!)
//3. Master class names which holds event names must define nature of events which they hold.
//3.1. If events don't have a meaningfull origin, place them in their master class by what is their intended impact / target (i.e. UI);

public class EventName {
    public class UI {
        public static string ShowScoreScreen() { return "UI_ShowScoreScreen"; }
        public static string ScoreScreenShown() { return "UI_ScoreScreenShown"; }
        public static string ShowCooldownNotReady() { return "UI_ShowCooldownNotReady"; }
        public static List<string> Get() { return new List<string> { ShowScoreScreen(), ScoreScreenShown(), ShowCooldownNotReady() }; }
    }
    public class Editor {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }
    public class Input {
        public static string PlayerAmountSelected() { return "Input_PlayerAmountSelected"; }
        public static string Accelerate() { return "Input_Accelerate"; }
        public static string Decelerate() { return "Input_Decelerate"; }
        public static string TurnLeft() { return "Input_TurnLeft"; }
        public static string TurnRight() { return "Input_TurnRight"; }
        public static string ChangeHidden() { return "Input_ChangeHidden"; }
        public static string Fireball() { return "Input_Fireball"; }

        public static string StartLevel() { return "Input_StartLevel"; }
        public static string None() { return null; }
        public static List<string> Get() {
            return new List<string> {
                PlayerAmountSelected(),
                Accelerate(),
                Decelerate(),
                TurnLeft(),
                TurnRight(),
                ChangeHidden(),
                Fireball(),
                StartLevel(),
                None(),
            };
        }
    }
    public class Player {
        public static string HasAppeared() { return "Player_HasAppeared"; }
        public static string HasHidden() { return "Player_HasHidden"; }
        public static string Bump() { return "Player_Bump"; }
        public static string PowerIncreased() { return "Player_PowerIncreased"; }
        public static List<string> Get() { return new List<string> { HasAppeared(), HasHidden(), Bump(), PowerIncreased() }; }
    }
    public class Economy {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }
    public class Environment {
        public static string StartChurchDestruction() { return "Environment_StartChurchDestruction"; }
        public static string ChurchCleanUp() { return "Environment_ChurchCleanUp"; }
        public static List<string> Get() { return new List<string> { StartChurchDestruction(), ChurchCleanUp() }; }

    }
    public class System {
        public static string GameEnd() { return "System_GameEnd"; }
        public static string PlayerDeath() { return "System_PlayerDeath"; }
        public static string StartGame() { return "System_StartGame"; }
        public static string TurtleCreated() { return "System_TurtleCreated"; }
        public static string TurtleDestroyed() { return "System_TurtleDestroyed"; }
        public static List<string> Get() { return new List<string> { GameEnd(), PlayerDeath(), StartGame(), TurtleCreated(), TurtleDestroyed() }; }
    }
    public class AI {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }

    public static List<string> Get() {
        return new List<string> {}.Concat(UI.Get())
            .Concat(Editor.Get())
            .Concat(Input.Get())
            .Concat(AI.Get())
            .Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
    }
}