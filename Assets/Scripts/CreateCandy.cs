using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCandy : MonoBehaviour
{
    [SerializeField] private PathCreator[] _paths;
    [SerializeField] private GameObject[] _prefabsCandys;
    [SerializeField] private int numberCandy;
    [SerializeField] private List<CharacterMovement> _currentCandyInGame;
    [SerializeField] private int _currentCountCandy;

    public List<CharacterMovement> CurrentCandyInGame { get => _currentCandyInGame;}
    public PathCreator[] Paths { get => _paths;}

    private void Awake()
    {
        for (int i = 0, j = 0; i < numberCandy; i++, j++)
        {
            if (j == _prefabsCandys.Length)
            {
                j = 0;
            }
            Create(j);            
        }
    }

    private void Start()
    {        
        MoveAll();        
    }

    private void Move(int i)
    {
        _currentCandyInGame[i].enabled = true;
    }

    private void MoveAll()
    {
        _currentCountCandy = 0;
        StartCoroutine(Delay());                     
    }

    private IEnumerator Delay()
    {        
        yield return new WaitForSeconds(1);
        Move(_currentCountCandy);
        _currentCountCandy += 1;
        if (_currentCountCandy < _currentCandyInGame.Count)
        {
            StartCoroutine(Delay());
        }        
    }

    private void Create(int i)
    {        
        var newCandy = Instantiate(_prefabsCandys[i]);
        newCandy.GetComponent<CharacterMovement>().Speed = Random.Range(0.5f, 1.5f);
        newCandy.GetComponent<CharacterMovement>().PathCreator = _paths[Random.Range(0, _paths.Length)];
        _currentCandyInGame.Add(newCandy.GetComponent<CharacterMovement>());
        newCandy.GetComponent<CharacterMovement>().enabled = false;        
    }
}
