using PathCreation.Examples;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

//Компонент управляет движением объекта когда тот находится "в руке"
public class ClickHandler : MonoBehaviour
{
    private CandyCounter _orderCheker;
    [SerializeField] private int _numberObjectsToBePlaced;
    //[SerializeField] private float _distanceFromCamera;
    [SerializeField] private StartGame _startGame;
    [SerializeField] private float _offsetZ;
    [SerializeField] private float _offsetY;
    [SerializeField] private GameObject _fieldMovement;
    [SerializeField] private GameObject _tableMovement;

    [SerializeField] private ObjectInHand _objectInHand;
    [SerializeField] private PlaceForObject _placeForObject;    
    [SerializeField] private Camera _camera;
    [SerializeField] private AnimatorFunctions _animatorFunctions;

    private void Awake()
    {
        _orderCheker = GetComponent<CandyCounter>();
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _startGame.HidePanel();
            RaycastHit hit;
            Ray rayAttack = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(rayAttack, out hit) && EventSystem.current.IsPointerOverGameObject() == false)
            {                
                if (hit.transform.gameObject.GetComponent<ObjectInHand>())
                {
                    PlaceMovement(true);

                    if (_objectInHand == null)//Если первый раз коснулись объекта
                    {
                        //Берем объект в руку
                        _objectInHand = hit.transform.gameObject.GetComponent<ObjectInHand>();
                        _objectInHand.GetComponent<CharacterMovement>().enabled = false;

                        _objectInHand.GetComponent<Rigidbody>().isKinematic = true;                        
                        _objectInHand.gameObject.layer = 2;

                        
                    }                    
                }
                else//Если тянем не отрывая от экрана указывая на что угодно кроме объекта:
                {
                    //Если объект в руках:
                    if (_objectInHand != null)
                    {
                        //Меняем ему позицию при попадании в поле движения                         
                        if (hit.transform.gameObject.name == "FieldMovement")
                        {
                            _objectInHand.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z - _offsetZ);
                        }
                        else if (hit.transform.gameObject.name == "TableMovement")
                        {
                            _objectInHand.transform.position = new Vector3(hit.point.x, hit.point.y + _offsetY, hit.point.z);
                        }

                        //Если натыкаемся на место для объекта
                        if (hit.transform.gameObject.GetComponent<PlaceForObject>())
                        {
                            if (hit.transform.gameObject.GetComponent<PlaceForObject>().IsFilled != true)
                            {
                                if (_placeForObject != null)
                                {
                                    _placeForObject.EmptyPlace();
                                    _placeForObject = null;
                                }
                                _placeForObject = hit.transform.gameObject.GetComponent<PlaceForObject>();                                
                                _placeForObject.InsertInPlace(_objectInHand);
                            }                            
                        }
                        else
                        {
                            if (_placeForObject == true)
                            {
                                _placeForObject.EmptyPlace();                                
                            }
                        }
                    }
                }
            }
        }
        else//Если оторвали от экрана палец
        {
            PlaceMovement(false);
            
            if (_objectInHand != null)
            {
                _objectInHand.GetComponent<Rigidbody>().isKinematic = false;
                //Если в руках объект:
                if (_placeForObject != null)
                {
                    if (_placeForObject.IsFilled == false)
                    {
                        _placeForObject.EmptyPlace();
                    }
                    else if(_placeForObject.IsFilled == true)
                    {
                        
                        _objectInHand.MoveToPlace(_placeForObject.CandyInPlace);
                        _placeForObject.Install();
                        _objectInHand.GetComponent<Collider>().enabled = false;
                        if (_objectInHand.Type == TypeInteractiveObjects.StarlikeCandy)
                        {
                            _animatorFunctions.ProtrudingCandies.Add(_objectInHand.gameObject);
                        }
                        
                    }                    
                }                
                _objectInHand.gameObject.layer = 0;                
                _objectInHand = null;
                _placeForObject = null;
            }            
        }
    }

    private void PlaceMovement(bool value)
    {
        _fieldMovement.gameObject.SetActive(value);
        _tableMovement.gameObject.SetActive(value);
    }
}
