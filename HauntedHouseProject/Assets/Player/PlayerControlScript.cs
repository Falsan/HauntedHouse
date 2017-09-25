using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

    Rigidbody rb;

    string primaryWeapon;
    string secondaryWeapon;
    string defence;

    bool controlsEnabled;

	// Use this for initialization
	void Start ()
    {

        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;

        controlsEnabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            float thrust = 0.0f;
            Vector3 direction = Vector3.zero;

            if (controlsEnabled)
            {

                for (int iter = 0; iter < InputManagerScript.instance.GetKeysPressed().Count; iter++)
                {
                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[1].GetKeyCode())
                    {
                        direction = Vector3.forward;
                        thrust = 400.0f;
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[2].GetKeyCode())
                    {
                        direction = Vector3.right;
                        thrust = -400.0f;
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[3].GetKeyCode())
                    {
                        direction = Vector3.right;
                        thrust = 400.0f;
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[4].GetKeyCode())
                    {
                        direction = Vector3.forward;
                        thrust = -400.0f;
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[0].GetKeyCode())
                    {
                        //FirePrimaryWeapon();
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[5].GetKeyCode())
                    {
                        //FireSecondaryWeapon();
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[6].GetKeyCode())
                    {
                        //ActivateDefence();
                    }
                }

                InputManagerScript.instance.ClearKeysPressed();

                rb.AddRelativeForce(direction * thrust, ForceMode.Force);
            }
        }
    }

    public void SetControls(bool toSet)
    {
        controlsEnabled = toSet;
    }

    public string GetPrimaryWeapon()
    {
        return primaryWeapon;
    }

    public string GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }

    public string GetDefence()
    {
        return defence;
    }
}
