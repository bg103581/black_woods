using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StrixObjectDetector : MonoBehaviour
{

    private readonly List<ObjectCatchable> _objectsCatchable = new List<ObjectCatchable>();
    private GameObject _objectToCatch;

    public GameObject GetObjectToCatch()
    {
        return _objectToCatch;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("catchable_object"))
        {
            ObjectCatchable objectToAdd = other.gameObject.GetComponent<ObjectCatchable>();
            _objectsCatchable.Add(objectToAdd);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("catchable_object"))
        {
            ObjectCatchable objectToRemove = FindObjectRef(other.gameObject);
            _objectsCatchable.Remove(objectToRemove);
        }
    }

    private void Update()
    {
        if(_objectsCatchable.Count > 0)
        {
            if (_objectsCatchable.Count > 1)
            {
                SortListByDistance();
            }
            _objectToCatch = _objectsCatchable[0].objectRef;
        }
        else
        {
            _objectToCatch = null;
        }
    }

    private ObjectCatchable FindObjectRef(GameObject objectRef)
    {
        return _objectsCatchable.FirstOrDefault(objectCatchable => objectCatchable.objectRef == objectRef);
    }

    private void SortListByDistance()
    {
        _objectsCatchable.Sort(ObjectCatchable.CompareDistance);
    }
}
