using UnityEngine;
using UnityEngine.Events;

public class StackableObject : MonoBehaviour
{
    public UnityEvent<StackableObject> OnPickedUp = new UnityEvent<StackableObject>();
    public UnityEvent<StackableObject> OnDropped = new UnityEvent<StackableObject>();

    public Transform root;
    public bool pickedUp;
    public Vector3 offset;

    [SerializeField]
    private GameObject onDropFx;

    void Start()
    {
        if (root == null)
        {
            root = transform;
        }
    }

    public void MarkAsPickedUp()
    {
        pickedUp = true;
        OnPickedUp.Invoke(this);
    }

    public void DropAndDestroy()
    {
        Instantiate(onDropFx, transform.position, Quaternion.identity);
        OnDropped.Invoke(this);
        Destroy(gameObject);
    }
}
