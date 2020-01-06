using UnityEngine;

public class ObjectCatchable : MonoBehaviour
{
    [SerializeField] private GameObject _strixCatchZone;

    [HideInInspector]
    public GameObject objectRef;
    [HideInInspector]
    public float distance;

    private bool _isItemDragged;

    private void Awake()
    {
        objectRef = gameObject;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, _strixCatchZone.transform.position);
        if (_isItemDragged)
        {
            Vector3 D = _strixCatchZone.transform.position - transform.position;
            Vector3 pullDir = D.normalized;
                float pullF = 10;
                float pullForDist = (distance-3)/2.0f;
                if(pullForDist>20) pullForDist=20;
                pullF += pullForDist;
                GetComponent<Rigidbody>().velocity += pullDir*(pullF * Time.deltaTime);
        }
    }

    public static int CompareDistance(ObjectCatchable object1, ObjectCatchable object2)
    {
        return object1.distance.CompareTo(object2.distance);
    }

    public void DragItem()
    {
        _isItemDragged = !_isItemDragged;
    }
    
}
