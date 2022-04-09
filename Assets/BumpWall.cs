using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BumpWall : MonoBehaviour
{
    [SerializeField]
    private List<ManualTransform> _possiblePositions = new List<ManualTransform>();

    private float _counter; 

    private void Start()
    {
        _counter = 0;
        _possiblePositions.Add(new ManualTransform
        {
            Position = transform.position,
            Rotation = transform.rotation
        });
        _possiblePositions.Add(new ManualTransform 
        {
            Position = new Vector3(-1, 0, 20),
            Rotation = new Quaternion(0f,180,0f,180f)
        });
        _possiblePositions.Add(new ManualTransform
        {
            Position = new Vector3(-5, 0, 15),
            Rotation = new Quaternion(0f, 90, 0f, 65f)
        });
        _possiblePositions.Add(new ManualTransform
        {
            Position = new Vector3(-20, 0, 19),
            Rotation = new Quaternion(0f, 75f, 0f, 45f)
        });
    }

    private void OnCollisionExit(Collision collision)
    {
        _counter = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        _counter += Time.deltaTime;
        if(_counter >= 2) {
            var newTransform = _possiblePositions.ElementAt(new System.Random().Next(_possiblePositions.Count));
            transform.position = newTransform.Position;
            transform.localRotation = newTransform.Rotation;
        }
    }

    private class ManualTransform
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
    }
}
