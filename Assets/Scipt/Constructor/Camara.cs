using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    float mauseX;
    float mauseY;
    public bool InvertedMouse;

    void Update()
    {

        Vector3 mousePosition = Input.mousePosition;
        mauseX += Input.GetAxis("Mouse X");
        if (InvertedMouse)
        {
            mauseY += Input.GetAxis("Mouse Y");
        }
        else
        {
            mauseY -= Input.GetAxis("Mouse Y");
        }
        transform.eulerAngles = new Vector3(mauseY, mauseX, 0);
    }
}
