using System;
using UnityEngine;

public class CandyCounter : MonoBehaviour
{
    [SerializeField] private int _number;
    [SerializeField] private PlaceForObject[] _placesInBox;

    public Action CountingIsOver;

    private void Awake()
    {
        foreach (var places in _placesInBox)
        {
            places.FilledUp += Add;
        }
    }
    private void Start()
    {
        _number = 0;
    }

    private void Add()
    {
        _number += 1;
        if (_number == 8)
        {
            CountingIsOver?.Invoke();
        }
    }

    private void Subtract()
    {
        _number -= 1;
    }
}
