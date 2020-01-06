using UnityEngine;

public class SwingPlayerDetector : MonoBehaviour
{

    private GameObject _strix;
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;

    private void Update()
    {
        if (_strix != null)
        {
            Vector3 position = _strix.transform.position;
            position = new Vector3(
                Mathf.Clamp(position.x,leftBound.position.x,rightBound.position.x),
                position.y,
                position.z);
            _strix.transform.position = position;
        }
    }

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
            _strix = null;
        }
    }
}
