using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject CameraGO;
    public Vector3 position;
    public float width, height;
    public GameObject player;
    public Rect NoTouch1, NoTouch2, NoTouch3;
    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    public void Start()
    {
        NoTouch1 = new Rect(1572f, 850f, 178.4f, 180.2f);
        NoTouch2 = new Rect(1748.2f, 45, 118.1f, 105.2f);
        NoTouch3 = new Rect(126f, 853f, 265.5f, 180);
    }

    void OnGUI()
    {
        GUI.Box(NoTouch1, "jump");
        GUI.Box(NoTouch2, "pause");
        GUI.Box(NoTouch3, "run");
    }

    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 inputGuiPosition = touch.position;
            inputGuiPosition.y = Screen.height - inputGuiPosition.y;

            if (!NoTouch1.Contains(inputGuiPosition) && !NoTouch2.Contains(inputGuiPosition) && !NoTouch3.Contains(inputGuiPosition))
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(pos.x * 7, pos.y * 7, -14.4f);

                transform.position = position;
            }
        }

        if(Input.touchCount == 0)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -14.4f);
        }
    }
}
