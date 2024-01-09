using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ArtworkSaver : MonoBehaviour
{
    public InputField artworkNameInput;

    void SaveArtwork()
    {
        string artworkName = artworkNameInput.text;

        // Ensure the artwork name is not empty
        if (string.IsNullOrEmpty(artworkName))
        {
            Debug.LogWarning("Artwork name cannot be empty.");
            return;
        }

        // Access the PaintingGame script
        PaintingGame paintingGame = FindObjectOfType<PaintingGame>();

        if (paintingGame != null)
        {
            // Call the SaveCanvas function in PaintingGame script
            paintingGame.SaveCanvas(artworkName);
        }
        else
        {
            Debug.LogError("PaintingGame script not found in the scene.");
        }
    }
}
