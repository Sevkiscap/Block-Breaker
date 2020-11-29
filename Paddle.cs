using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    [SerializeField] float widthUU = 16f;
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 13.9f;


    // Update is called once per frame
    void Update()
    {
       float xPos = Input.mousePosition.x / Screen.width * widthUU;
        Vector2 PaddlePos = new Vector2(transform.position.x, transform.position.y);
        PaddlePos.x = Mathf.Clamp(xPos, minX, maxX);
        transform.position = PaddlePos;
    }
}
