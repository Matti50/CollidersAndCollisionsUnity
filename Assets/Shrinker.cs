using UnityEngine;

public class Shrinker : MonoBehaviour
{
    public Vector3 SmallScale { get; } = new Vector3(0.5f, 0.5f, 0.5f);
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ISizeable>();
        if(player == null)
        {
            Debug.LogWarning("Object not sizeable, doing nothing");
            return;
        }
        player.ChangeSize(SmallScale);
    }
}
