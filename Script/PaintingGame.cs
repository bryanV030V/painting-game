using UnityEngine;

public class PaintingGame : MonoBehaviour
{
    public GameObject paintBrushPrefab;

    private GameObject paintBrush;
    private LineRenderer currentLine;
    private bool isPainting = false;
    private Color[] paintColors = { Color.black, Color.red, Color.green, Color.blue }; // Add more colors as needed
    private int currentColorIndex = 0;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }
    }

    void StartPainting()
    {
        paintBrush = Instantiate(paintBrushPrefab, GetMousePosition(), Quaternion.identity);
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

    void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % paintColors.Length;
        paintBrush.GetComponent<SpriteRenderer>().color = paintColors[currentColorIndex];
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}
