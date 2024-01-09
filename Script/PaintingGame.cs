﻿using UnityEngine;

public class PaintingGame : MonoBehaviour
{
    public GameObject paintBrushPrefab;
    public Color paintColor = Color.black;

    private GameObject paintBrush;
    private LineRenderer currentLine;
    private bool isPainting = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPainting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopPainting();
        }

        if (isPainting)
        {
            UpdatePainting();
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeletePaint();
        }
    }

    void StartPainting()
    {
        paintBrush = Instantiate(paintBrushPrefab, GetMousePosition(), Quaternion.identity);
        paintBrush.GetComponent<SpriteRenderer>().color = paintColor;
        currentLine = paintBrush.GetComponent<LineRenderer>();
        currentLine.positionCount = 0;
        isPainting = true;
    }

    void UpdatePainting()
    {
        currentLine.positionCount++;
        currentLine.SetPosition(currentLine.positionCount - 1, GetMousePosition());
    }

    void StopPainting()
    {
        isPainting = false;
    }

    void DeletePaint()
    {
        if (paintBrush != null)
        {
            Destroy(paintBrush);
        }
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}