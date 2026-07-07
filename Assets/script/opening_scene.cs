using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextScene = "Main menu";

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("Video Player is not assigned!");
            return;
        }

        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            videoPlayer.Stop();
            SceneManager.LoadScene(nextScene);
        }
    }
}