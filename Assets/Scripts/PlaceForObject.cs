using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForObject : MonoBehaviour
{
    [SerializeField] private TypeInteractiveObjects _type;
    //[SerializeField] private MeshRenderer _lightPlace;      
    [SerializeField] private Transform _candyInPlace;
    [SerializeField] private GameObject _red;
    [SerializeField] private GameObject _green;
    
    private bool _isFilled;      
    
    public Action FilledUp;    

    public bool IsFilled { get => _isFilled;}
    public Transform CandyInPlace { get => _candyInPlace;}

    public void InsertInPlace(ObjectInHand objectInHand)
    {        
        if (_type == objectInHand.Type)
        {
            _isFilled = true;
            _red.SetActive(false);
            _green.SetActive(true);
        }
        else
        {
            _red.SetActive(true);
            _green.SetActive(false);
        }
    }

    public void EmptyPlace()
    {
        _red.SetActive(false);
        _green.SetActive(false);
        _isFilled = false;
    }

    public void Install()
    {        
        FilledUp?.Invoke();
        _red.SetActive(false);
        _green.SetActive(false);
    }
}
