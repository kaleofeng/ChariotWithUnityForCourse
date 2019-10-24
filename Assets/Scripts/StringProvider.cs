using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StringProvider {

    public static StringProvider Instance { get; private set; } = new StringProvider();

    private static Dictionary<SystemLanguage, string> ID_LANGUAGES = new Dictionary<SystemLanguage, string> {
        { SystemLanguage.English, "en_US" },
        { SystemLanguage.Chinese, "zh_CN" },
        { SystemLanguage.ChineseSimplified, "zh_CN" },
        { SystemLanguage.ChineseTraditional, "zh_CN" },
    };

    private Dictionary<SystemLanguage, Dictionary<string, string>> idStringMap = new Dictionary<SystemLanguage, Dictionary<string, string>>();

    public void LoadAll() {
        foreach (var item in ID_LANGUAGES) {
            idStringMap[item.Key] = new Dictionary<string, string>();

            var languagePath = "langs/" + item.Value;
            var ta = Resources.Load<TextAsset>(languagePath);
            var text = ta.text.Replace("\r", "");
            var lines = text.Split('\n');
            foreach (var line in lines) {
                if (string.IsNullOrEmpty(line)) {
                    continue;
                }
                var keyAndValue = line.Split('=');
                idStringMap[item.Key].Add(keyAndValue[0], keyAndValue[1]);
            }
        }
    }

    public string GetString(string key) {
        Dictionary<string, string> stringMap = null;
        if (idStringMap.ContainsKey(Application.systemLanguage)) {
            stringMap = this.idStringMap[Application.systemLanguage];
        }

        if (stringMap == null) {
            if (idStringMap.ContainsKey(SystemLanguage.English)) {
                stringMap = this.idStringMap[SystemLanguage.English];
            }
        }

        var value = key;
        if (stringMap != null) {
            if (stringMap.ContainsKey(key)) {
                stringMap.TryGetValue(key, out value);
            }
        }
        return value;
    }
}
