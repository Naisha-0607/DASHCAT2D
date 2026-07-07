using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class FINALBHAIUFO: MonoBehaviour



{
    private VideoPlayer vp;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();

        vp.loopPointReached += EndVideo;
    }

    void EndVideo(VideoPlayer source)
    {
        SceneManager.LoadScene("GameOver");
    }
}