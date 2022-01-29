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
        public static string Accelerate() { return "Input_Accelerate"; }
        public static string Decelerate() { return "Input_Decelerate"; }
        public static string Turn() { return "Input_Turn"; }
        public static string Hide() { return "Input_Hide"; }
        public static string Fireball() { return "Input_Fireball"; }

        public static string StartLevel() { return "Input_StartLevel"; }
        public static string None() { return null; }
        public static List<string> Get() {
            return new List<string> {
                None(),
                StartLevel(),
                Accelerate(),
                Decelerate(),
                Turn(),
                Hide(),
                Fireball()
            };
        }
    }
    public class Player {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }
    public class Economy {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }
    public class Environment {
        public static string None() { return null; }
        public static List<string> Get() { return new List<string> { None() }; }
    }
    public class System {
        public static string StartGame() { return "System_StartGame"; }
        public static List<string> Get() { return new List<string> { StartGame() }; }
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