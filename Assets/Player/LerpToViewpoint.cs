using UnityEngine;

public class LerpToViewpoint : MonoBehaviour
{
    public Transform Viewpoint;
    private bool _isTransitioning;
    private Transform _parent;
    private bool _isOccupied;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.localPosition;
        _parent = transform.parent;
    }

    void Update()
    {

        if (_isTransitioning)
        {
            if (Vector3.Distance(gameObject.transform.position, Viewpoint.transform.position) < 0.015)
            {
                _isTransitioning = false;
                _isOccupied = true;
                return;
            }

            Debug.Log($"{Vector3.Distance(gameObject.transform.position, Viewpoint.transform.position)}");
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Viewpoint.position, Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Viewpoint.rotation, Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!_isTransitioning && !_isOccupied)
            {
                transform.parent = null;              
                _isTransitioning = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(_isOccupied || _isTransitioning)
            {
                //todo: Lerp back to original position
                _isTransitioning = false;
                _isOccupied = false;
                Cursor.lockState = CursorLockMode.Locked;
                transform.parent = _parent;
                transform.localPosition = _initialPosition;
            }         
        }
    }
}
