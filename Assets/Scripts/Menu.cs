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
    TMP_Dropdown dropdown;
    public Mode mode;
    //LevelInfo info;

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Start is called before the first frame update
    void Start()
    {
        dropdown = FindObjectOfType<TMP_Dropdown>();
        //info = FindObjectOfType<LevelInfo>();

        dropdown.ClearOptions();
        dropdown.AddOptions(Enum.GetNames(typeof(Mode)).ToList());

        //menuScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += sceneLoaded;
    }

    private void sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.SetActiveScene(arg0);

        //menuScene.DisableScene();

        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //info.mode = mode;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void ChangeMode()
    {
        Debug.Log(dropdown.value);
        mode = (Mode)dropdown.value;
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