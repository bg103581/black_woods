using System;
using UnityEngine;

public class SwingPlayerDetector : MonoBehaviour
{

    private GameObject _strix;

    public GameObject GetStrix()
    {
        return _strix;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }

        if (other.gameObject.GetComponent<Strix>())
        {
            _strix = other.gameObject;
            _strix.GetComponent<Rigidbody>().constraints += (int) RigidbodyConstraints.FreezePositionX;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }

        if (other.gameObject.GetComponent<Strix>())
        {
            _strix.GetComponent<Rigidbody>().constraints -= (int) RigidbodyConstraints.FreezePositionX;
            _strix = null;
        }
    }
}
