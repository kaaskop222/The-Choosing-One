using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Camera camera;
    private float halfHeight;
    private float halfWidth;
    private float height;
    private float width;

    private bool cutSceneOn;

    private bool camIsMoving = false;

    private Vector3 newCamPos;
    [SerializeField]

    private float camSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = Mathf.Round(camera.aspect * halfHeight);
        height = halfHeight * 2;
        width = halfWidth * 2;

        cutSceneOn = this.GetComponent<PlayerMovement>().inCutScene;

        newCamPos = camera.transform.position;
   
    }

    // Update is called once per frame
    void Update()
    {

        float camMovementAmount = camSpeed * Time.deltaTime;
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, newCamPos, camMovementAmount);

        if(newCamPos == camera.transform.position){
            camIsMoving = false;
            cutSceneOn = false;
        }
        if(Mathf.Abs(transform.position.y - camera.transform.position.y) >= halfHeight && !camIsMoving){
            camIsMoving = true;
            cutSceneOn = true;
            newCamPos += new Vector3(0f, (Mathf.Sign(transform.position.y - camera.transform.position.y) * height), 0f);
        }

        if(Mathf.Abs(transform.position.x - camera.transform.position.x) >= halfWidth && !camIsMoving){
            camIsMoving = true;
            cutSceneOn = true;
            newCamPos += new Vector3((Mathf.Sign(transform.position.x - camera.transform.position.x) * width), 0f, 0f);
        }

        this.GetComponent<PlayerMovement>().inCutScene = cutSceneOn;

    }

}
