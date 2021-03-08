using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private CreateCandy _createCandy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wine")
        {            
            _gameOver.Defeat();
        }
        else if(other.gameObject.name == "WineBottle")
        {            
            _gameOver.Defeat();
        }
        else if (other.gameObject.GetComponent<ObjectInHand>())
        {
            Debug.Log("Упала конфета");
            //other.gameObject.GetComponent<CharacterMovement>().enabled = true;
            //other.gameObject.GetComponent<CharacterMovement>().PathCreator = _createCandy.Paths[Random.Range(0, _createCandy.Paths.Length)];
            
        }
    }
}
