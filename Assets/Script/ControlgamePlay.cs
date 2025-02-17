using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGamePlay : MonoBehaviour
{
    private string sceneName; // Khai báo biến sceneName ở cấp độ lớp
    InputFieldLogger inp;

    void Start()
    {
        // Lấy scene hiện tại
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name; // Lưu tên scene
        inp = FindObjectOfType<InputFieldLogger>();
    }

    public void Restart()
    {
        // Tải lại scene hiện tại
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1; // Khôi phục thời gian

    }
    public void Playgame()
    {
        // Tải lại scene hiện tại
        SceneManager.LoadScene(1);
        Time.timeScale = 1; // Khôi phục thời gian

    }
    public void Continue()
    {
        Time.timeScale = 1;
        inp.showPausePannel(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Dừng game
        inp.showPausePannel(true);
    }
    public void Exit()
    {
        Application.Quit(); // Thoát game
    }
    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
}