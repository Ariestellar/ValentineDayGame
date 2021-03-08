using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] private List<GameObject> _protrudingCandies;
    [SerializeField] private GameOver _gameOver;
    public List<GameObject> ProtrudingCandies { get => _protrudingCandies; }
    public void RemoveProtrudingCandies()
    {
        foreach (var candies in _protrudingCandies)
        {
            candies.SetActive(false);
        }
    }

    public void Victory()
    {
        _gameOver.Victory();
    }
}
