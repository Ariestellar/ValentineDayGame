using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    [SerializeField] private CandyCounter _candyCounter;
    [SerializeField] private GameObject _capBox;
    [SerializeField] private GameObject _gameOverPanel;
    //[SerializeField] private Text _gameOverText;

    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private Image _omedetou;
    [SerializeField] private Text _omedetouText;
    [SerializeField] private Transform _button1;
    [SerializeField] private Transform _button2;

    private void Awake()
    {
        _candyCounter.CountingIsOver += CloseCandyBox;        
    }

    private void CloseCandyBox()
    {
        _capBox.SetActive(true);
    }

    public void Defeat()
    {
        _gameOverPanel.SetActive(true);        
    }

    public void Victory()
    {
        _victoryPanel.SetActive(true);
        _omedetouText.DOFade(1, 2);
        _omedetou.DOFade(1, 2).OnComplete(()=> ShowButton());
               
    }

    private void ShowButton()
    {
        _button1.DORotate(new Vector3(0, 0, 0), 2);
        _button2.DORotate(new Vector3(0, 0, 0), 2);
    }
}
