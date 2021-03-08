using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _sharedPanel;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HonMei()
    {
        HideVictoryPanel();
    }

    public void GiriСhoco()
    {
        HideVictoryPanel();
    }

    private void HideVictoryPanel()
    {
        _victoryPanel.SetActive(false);
        _sharedPanel.SetActive(true);
    }
}
