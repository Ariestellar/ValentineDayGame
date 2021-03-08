using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Image _tranzitPanel;
    [SerializeField] private Image _brifingBackgroundPanel;
    [SerializeField] private GameObject _brifingPanel;
    [SerializeField] private Text _brifingText1;
    [SerializeField] private Text _brifingText2;
    [SerializeField] private Text _brifingText3;
    [SerializeField] private bool _isBriffingCompleted;
    [SerializeField] private CanvasScaler _canvasScaler;

    private void Start()
    {
        if (Screen.width <= 480)
        {
            _canvasScaler.scaleFactor = 0.4f;
        }
        else if (Screen.width <= 750)
        {
            _canvasScaler.scaleFactor = 0.65f;
        }
        else if (Screen.width <= 1080)
        {
            _canvasScaler.scaleFactor = 1;
        }

        if (GameStats.IsLaunch)
        {
            _brifingPanel.SetActive(false);
        }
        else
        {
            _tranzitPanel.DOFade(0, 2).OnComplete(FadeText1);
            GameStats.IsLaunch = true;
        }  
    }

    public void HidePanel()
    {
        if (_isBriffingCompleted)
        {
            _brifingBackgroundPanel.DOFade(0, 2);
            _brifingText1.DOFade(0, 2);
            _brifingText2.DOFade(0, 2);
            _brifingText3.DOFade(0, 2).OnComplete(() => _brifingPanel.SetActive(false));
        }          
    }

    private void FadeText1()
    {        
        _brifingText1.DOFade(1, 1).OnComplete(FadeText2);        
    }
    private void FadeText2()
    {
        StartCoroutine(StartText(()=>_brifingText2.DOFade(1, 1).OnComplete(FadeText3), 2));  
    }
    private void FadeText3()
    {
        StartCoroutine(StartText(() => _brifingText3.DOFade(1, 1).OnComplete(()=> _isBriffingCompleted = true), 2));        
    }

    private IEnumerator StartText(Action action, int sec)
    {
        yield return new WaitForSeconds(sec);
        action();
    }
}
