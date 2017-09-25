using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstPersonCameraScript : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX = 0F;
    float rotationY = 0F;

    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F;

    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;

    public float frameCounter = 20;

    public GameObject camera;
    public GameObject player;

    Quaternion originalRotation;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        camera = GameObject.FindGameObjectWithTag("PlayerCamera");
        player = gameObject;
        //rb.freezeRotation = true;
        
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            rotAverageY = 0f;
            rotAverageX = 0f;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;

            rotArrayY.Add(rotationY);
            rotArrayX.Add(rotationX);

            if (rotArrayY.Count >= frameCounter)
            {
                rotArrayY.RemoveAt(0);
            }
            if (rotArrayX.Count >= frameCounter)
            {
                rotArrayX.RemoveAt(0);
            }

            for (int j = 0; j < rotArrayY.Count; j++)
            {
                rotAverageY += rotArrayY[j];
            }
            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }

            rotAverageY /= rotArrayY.Count;
            rotAverageX /= rotArrayX.Count;

            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);

            camera.transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            //player.transform.localRotation = camera.transform.localRotation;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotAverageX = 0f;

            rotationX += Input.GetAxis("Mouse X") * sensitivityX;

            rotArrayX.Add(rotationX);

            if (rotArrayX.Count >= frameCounter)
            {
                rotArrayX.RemoveAt(0);
            }
            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }
            rotAverageX /= rotArrayX.Count;


            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);
            camera.transform.localRotation = originalRotation * xQuaternion;
            //player.transform.localRotation = camera.transform.localRotation;
        }
        else
        {
            rotAverageY = 0f;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotArrayY.Add(rotationY);

            if (rotArrayY.Count >= frameCounter)
            {
                rotArrayY.RemoveAt(0);
            }
            for (int j = 0; j < rotArrayY.Count; j++)
            {
                rotAverageY += rotArrayY[j];
            }
            rotAverageY /= rotArrayY.Count;

            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            camera.transform.localRotation = originalRotation * yQuaternion;
            //player.transform.localRotation = camera.transform.localRotation;
        }

        rotArrayX.Clear();
        rotArrayY.Clear();
        player.transform.localRotation = new Quaternion(0, camera.transform.localRotation.y, 0, camera.transform.localRotation.w);
        

    }

}