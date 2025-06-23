using Assets.ScriptableObjects;
using UnityEngine;

public class LerpToViewpoint : MonoBehaviour
{
    public Transform Viewpoint;
    public int InteractDistance;
    private bool _transitioning;
    private Transform _parent;
    private bool _occupied;
    private Vector3 _initialPosition;
    public float LerpSpeed = 0f;
    public PlayerState PlayerState;

    void Start()
    {
        _initialPosition = transform.localPosition;
        _parent = transform.parent;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!_transitioning && !_occupied)
            {
                var layer_mask = LayerMask.GetMask("ViewportSlot");
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                if (Physics.Raycast(ray, out RaycastHit vpHit, InteractDistance, layer_mask))
                {
                    PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Interact;

                    Viewpoint = vpHit.collider.transform;
                    transform.parent = null;
                    _transitioning = true;
                    Cursor.lockState = CursorLockMode.None;
                    var canvas = GameObject.Find("Player").GetComponentInChildren<Canvas>();
                    if(canvas is not null)
                    {
                        canvas.enabled = false;
                    }
                }
            }
            else if (_occupied || _transitioning)
            {
                //todo: Lerp back to original position
                _transitioning = false;
                _occupied = false;
                Cursor.lockState = CursorLockMode.Locked;
                transform.parent = _parent;
                transform.localPosition = _initialPosition;
               // GameObject.Find("Player").GetComponentInChildren<Canvas>().enabled = true;

                var canvas = GameObject.Find("Player").GetComponentInChildren<Canvas>();
                if (canvas is not null)
                {
                    canvas.enabled = true;
                }

                PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Walk;
            }
        }

        if (_transitioning)
        {
            if (Vector3.Distance(gameObject.transform.position, Viewpoint.transform.position) < 0.015)
            {
                _transitioning = false;
                _occupied = true;
                return;
            }

            //Debug.Log($"{Vector3.Distance(gameObject.transform.position, Viewpoint.transform.position)}");
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Viewpoint.position, Time.deltaTime * LerpSpeed);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Viewpoint.rotation, Time.deltaTime * LerpSpeed);
        }
    }
}
