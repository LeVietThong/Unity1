using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class Minimap : MonoBehaviour
{
    
    public Transform player;
    public RectTransform minimapRectTransform;
   

    public Vector2 zoomedSize = new Vector2(400f, 400f);
    public float zoomScale = 3.0f;
    public float originalScale = 1.0f;
    
    private bool isZoomed = false;


    public void ZoomIn()
    {
        if (isZoomed)
        {
            // Quay trở lại kích thước ban đầu
            minimapRectTransform.localScale = new Vector3(originalScale, originalScale, 1.0f);
        }
        else
        {
            // Phóng to Minimap
            minimapRectTransform.localScale = new Vector3(zoomScale, zoomScale, 1.0f);
        }

        isZoomed = !isZoomed;
    }

    
    private void Start()
    {
        
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            ZoomIn();
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }   
}
