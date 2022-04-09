using UnityEngine;

public class PlayerController : MonoBehaviour, ISizeable
{
    private bool _passedPortal = false;
    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherGameobject = collision.gameObject;

        if (otherGameobject.tag == Tags.Floor)
            return;

        LogCollision(otherGameobject);
    }

    private void OnTriggerEnter(Collider other)
    {
        LogCollision(other.gameObject);

        if (other.gameObject.tag == Tags.Portal)
            Debug.Log("It has a Shrinker!");
    }

    private void LogCollision(GameObject gameObject)
    {
        Debug.Log($"Collisioned with: {gameObject.name}");
    }

    public void ChangeSize(Vector3 newSize)
    {
        _passedPortal = !_passedPortal;
        transform.localScale = _passedPortal ? newSize : _originalScale;
    }
}
