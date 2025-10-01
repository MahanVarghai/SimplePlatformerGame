using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiBehavior : MonoBehaviour
{
    [SerializeField]
    private Canvas gameOverCanvas;
    public static UiBehavior Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void GameOverPanelEnable()
    {
        gameOverCanvas.enabled = true;
    }
    public void ResetTheScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
