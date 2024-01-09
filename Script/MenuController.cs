using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject paintingGame; // Drag the GameObject with the PaintingGame script attached to this field in the Inspector
    public GameObject menuPanel;

    void Start()
    {
        // Ensure the menu is hidden initially
        menuPanel.SetActive(false);
    }

    void Update()
    {
        // Open/Close menu with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void SaveCanvas()
    {
        // Call the SaveCanvasFromMenu function in PaintingGame script
        paintingGame.GetComponent<PaintingGame>().SaveCanvasFromMenu();
    }

    public void ContinueGame()
    {
        // Close the menu
        ToggleMenu();
    }

    public void QuitGame()
    {
        // Quit the game (only works in a built executable)
        Application.Quit();
    }

    void ToggleMenu()
    {
        // Toggle the visibility of the menu
        menuPanel.SetActive(!menuPanel.activeSelf);

        // Pause or resume the game
        Time.timeScale = (menuPanel.activeSelf) ? 0f : 1f;
    }
}
