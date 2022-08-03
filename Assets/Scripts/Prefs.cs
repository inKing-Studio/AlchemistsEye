using UnityEngine;

static class Prefs {
    const Difficulty DEFAULT_DIFFICULTY = global::Difficulty.Normal;
    const Mode DEFAULT_MODE = global::Mode.Daily;

    public static int Difficulty {
        get => PlayerPrefs.GetInt("Difficulty", (int)DEFAULT_DIFFICULTY);
        set => PlayerPrefs.SetInt("Difficulty", value);
    }
    public static int Mode {
        get => PlayerPrefs.GetInt("Mode", (int)DEFAULT_MODE);
        set => PlayerPrefs.SetInt("Mode", value);
    }
    public static void Save() => PlayerPrefs.Save();
}