using System.Collections;
using UnityEngine;

public class ObjectInHand : MonoBehaviour
{
    [SerializeField] private TypeInteractiveObjects _type;    
    [SerializeField] private float _speedSetupInPlace;    
    public TypeInteractiveObjects Type { get => _type;}

    public void MoveToPlace(Transform transformPosition)
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Collider>().enabled = false;        
        StartCoroutine(Move(transformPosition));
    }

    private IEnumerator Move(Transform transformPosition)
    {        
        while (transform.position != transformPosition.position)
        {            
            transform.position = Vector3.MoveTowards(transform.position, transformPosition.position, _speedSetupInPlace * Time.deltaTime);
            transform.rotation = transformPosition.rotation;
            yield return null;
        }        
    }

}


