using Newtonsoft.Json.Linq;
public static class JsonExtensions {
    public static bool IsNullOrEmpty(this JToken token) {
        return (token == null) ||
            (token.Type == JTokenType.Array && !token.HasValues) ||
            (token.Type == JTokenType.Object && !token.HasValues) ||
            (token.Type == JTokenType.String && token.ToString() == string.Empty) ||
            (token.Type == JTokenType.Null);
    }
    public static bool ContainsPlayerData(this JToken token) {
        return (token["ownerID"] != null) &&
            (token["token"] != null) &&
            (token["coinCount"] != null) &&
            (token["selectedHat"] != null) &&
            (token["selectedScepter"] != null);
    }
}