using Assets.Code;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public GameObject _target;
    public GameObject Cam;
    public PlayerCore PlayerCore;
    public int InteractDistance;
    public InteractMode InteractMode;

    public int Rotation;

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, .1f);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        int carryable = LayerMask.GetMask("Carryable");

        // Something else is "holding this now"
        if (_target != null && _target.transform.parent != Cam.transform)
        {
            InteractMode = InteractMode.None;
            _target = null;
            Rotation = 0;
            return;
        }

        if (InteractMode == InteractMode.Carrying)
        {
            if (_target == null) 
            {
                InteractMode = InteractMode.None;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotation+=90;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Rotation-=90;
            }

            _target.transform.rotation = Quaternion.Euler(0, Rotation, _target.transform.rotation.z);
        }

        if (!Input.GetKeyUp(KeyCode.Space)) return;

        if (_target != null)
        {
            _target.GetComponent<Rigidbody>().isKinematic = false;
            _target.transform.parent = null;
            _target = null;
            Rotation = 0;
            InteractMode = InteractMode.None;
        }
        else if (Physics.Raycast(ray, out var hit1, InteractDistance, carryable))
        {
            Debug.Log("PlayerInteract has interacted with a Carryable");
            var go = hit1.transform.parent.gameObject;
            _target = go;
            go.GetComponent<Rigidbody>().isKinematic = true;
            go.transform.parent = Cam.transform;
            InteractMode = InteractMode.Carrying;
        }
    }
}
