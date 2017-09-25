﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UI
{

    public class Level1ButtonScript : MonoBehaviour
    {
        public GameObject levelToLoadObject;

        void Level1Button()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            GameObject temp = Instantiate(levelToLoadObject);
            //temp.GetComponent<LevelToLoadObjectScript>().SetLevelToLoad("Level1");
            SceneManager.MoveGameObjectToScene(temp, ApplicationManagerScript.instance.managementScene);
            ApplicationManagerScript.instance.SetCurrentApplicationState("CUTSCENESCENE");
        }
    }
}