using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown ddMode, ddDifficulty;

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Start is called before the first frame update
    void Start()
    {
        //info = FindObjectOfType<LevelInfo>();

        ddMode.ClearOptions();
        ddMode.AddOptions(Enum.GetNames(typeof(Mode)).ToList());

        ddDifficulty.ClearOptions();
        ddDifficulty.AddOptions(Enum.GetNames(typeof(Difficulty)).ToList());

        ddMode.value = Prefs.Mode;
        ddDifficulty.value = Prefs.Difficulty;

        //menuScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += sceneLoaded;
    }

    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.SetActiveScene(arg0);

        //menuScene.DisableScene();

        //throw new System.NotImplementedException();
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void ChangeMode()
    {
        Prefs.Mode = ddMode.value;
        Prefs.Difficulty = ddDifficulty.value;
        Prefs.Save();
    }
}

static class SceneExtensions
{
    public static void EnableScene(this Scene scene)
    {
        var gameobjects = scene.GetRootGameObjects();
        if (gameobjects.Length == 0)
            return;

        if (gameobjects.Length == 1)
            gameobjects.First().SetActive(false);
    }

    public static void DisableScene(this Scene scene)
    {
        var gameobjects = scene.GetRootGameObjects();

        if (gameobjects.Length == 0)
            return;

        if (gameobjects.Length == 1)
            gameobjects.First().SetActive(false);
        else
        {
            var firstChild = gameobjects.First();

            var root = new GameObject(scene.name);
            root.transform.SetParent(firstChild.transform);
            root.transform.SetParent(null);
            foreach (var go in gameobjects)
                go.transform.SetParent(root.transform);

            root.SetActive(false);
        }
    }
} 