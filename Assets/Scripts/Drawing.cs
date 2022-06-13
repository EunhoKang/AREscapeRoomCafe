using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera cam;
    public Material defaultMaterial;
    public GameObject wowo;
    private LineRenderer curLine;
    private int positionCount = 2;
    private Vector3 PrevPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        DrawMouse();
    }

    void DrawMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));

        if (Input.GetMouseButtonDown(0))
        {
            createLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            connectLine(mousePos);
        }
    }

    void createLine(Vector3 mousePos)
    {
        positionCount = 2;
        GameObject line = new GameObject("Line");
        LineRenderer lineRend = line.AddComponent<LineRenderer>();

        line.transform.parent = cam.transform;
        line.transform.position = mousePos;

        lineRend.startWidth = 0.01f;
        lineRend.endWidth = 0.01f;
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = defaultMaterial;
        lineRend.SetPosition(0, mousePos);
        lineRend.SetPosition(1, mousePos);

        curLine = lineRend;
    }

    void connectLine(Vector3 mousePos)
    {
        if (PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, mousePos)) >= 0.001f)
        {
            PrevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }
    }

    public void DeactivateChildren()
    {
        foreach (Transform child in cam.transform)
        {
            if(child.gameObject.name == "Line")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void activateChildren()
    {
        foreach (Transform child in cam.transform)
        {
            if (child.gameObject.name == "Line")
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void oneStepBack()
    {
        //wowo.transform.childCount
        //Destroy(cam.transform.GetChild(childCount-1));
        Debug.Log(wowo.transform.childCount);
        Debug.Log(wowo.transform.GetChild(2));
        
        Destroy(wowo.transform.GetChild(2));
    }

}