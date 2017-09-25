using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    string GameState;

    float timePressedPause;
    float timeTaken;

	void Start () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GameState = "Playing";
    }
	
	void LateUpdate ()
    {
        if (PlayerStatusScript.instance != null)
        {
            if (PlayerStatusScript.instance.GetIsDead())
            {
                GameState = "PlayerDeath";
            }
        }

        if(GameState == "Playing")
        {
            for (int iter = 0; iter < InputManagerScript.instance.GetKeysPressed().Count; iter++)
            {
                if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[7].GetKeyCode())
                {
                    GameState = "Pause";
                    timePressedPause = Time.time;
                }
            }

        }
        else if(GameState == "Pause")
        {

        }
        if(GameState == "Win")
        {
            Debug.Log("Win");
            ApplicationManagerScript.instance.currentApplicationState = "WINSCREEN";
        }
        else if(GameState == "PlayerDeath")
        {
            ApplicationManagerScript.instance.currentApplicationState = "WINSCREEN";
        }
	}

    public string GetGameState()
    {
        return GameState;
    }
    public void SetGameState(string toSet)
    {
        GameState = toSet;
    }

    public float GetTimeTaken()
    {
        return timeTaken;
    }
}
