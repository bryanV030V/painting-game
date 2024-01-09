using UnityEngine;

public class PaintingGame : MonoBehaviour
{
    public GameObject paintBrushPrefab;

    private GameObject paintBrush;
    private LineRenderer currentLine;
    private bool isPainting = false;
    private Color[] paintColors = { Color.black, Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartPainting();
        else if (Input.GetMouseButtonUp(0))
            StopPainting();

        if (isPainting)
            UpdatePainting();

        if (Input.GetKeyDown(KeyCode.Delete))
            DeletePaint();

        if (Input.GetKeyDown(KeyCode.C))
            ChangeColor();
    }

    public void SaveCanvas(string artworkName)
    {
        Texture2D canvasTexture = CaptureCanvas();
        SaveCanvasAsImage(canvasTexture, artworkName);
    }

    void StartPainting()
    {
        paintBrush = Instantiate(paintBrushPrefab, GetMousePosition(), Quaternion.identity);
        paintBrush.GetComponent<SpriteRenderer>().color = paintColors[currentColorIndex];
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
            Destroy(paintBrush);
    }

    void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % paintColors.Length;
        paintBrush.GetComponent<SpriteRenderer>().color = paintColors[currentColorIndex];
    }

    public void SaveCanvasFromMenu()
    {
        Texture2D canvasTexture = CaptureCanvas();
        SaveCanvasAsImage(canvasTexture, "SavedFromMenu");
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }

    Texture2D CaptureCanvas()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        Camera.main.targetTexture = rt;

        Texture2D canvasTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        canvasTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        canvasTexture.Apply();

        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        return canvasTexture;
    }

    void SaveCanvasAsImage(Texture2D canvasTexture, string artworkName)
    {
        string artworkDirectory = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Artwork");

        if (!System.IO.Directory.Exists(artworkDirectory))
            System.IO.Directory.CreateDirectory(artworkDirectory);

        string filePath = System.IO.Path.Combine(artworkDirectory, $"{artworkName}.png");
        System.IO.File.WriteAllBytes(filePath, canvasTexture.EncodeToPNG());

        Debug.Log($"Artwork saved to: {filePath}");
    }
}
