using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public InputField musicInputField;
    public AudioSource audioSource;

    void Start()
    {
        // Ensure that the AudioSource component is attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Attach the listener for the InputField
        musicInputField.onEndEdit.AddListener(PlayMusicFromInput);
    }

    void PlayMusicFromInput(string musicPath)
    {
        // Check if the input is not empty
        if (!string.IsNullOrEmpty(musicPath))
        {
            // Attempt to load and play the music file
            StartCoroutine(LoadAndPlayMusic(musicPath));
        }
    }

    System.Collections.IEnumerator LoadAndPlayMusic(string musicPath)
    {
        // Use UnityWebRequest to load the audio file
        using (UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequestMultimedia.GetAudioClip(musicPath, UnityEngine.AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Error loading music: " + www.error);
            }
            else
            {
                // Successfully loaded the music file
                AudioClip audioClip = UnityEngine.Networking.DownloadHandlerAudioClip.GetContent(www);

                // Play the loaded music
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}
