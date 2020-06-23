using UnityEngine;

public class PursuerLight : MonoBehaviour
{
    [SerializeField] private Transform _persecutedObject;
    private Transform _myTransform;

    private void Start()
    {
        _myTransform = transform;
    }

    private void Update()
    {
        var position = _persecutedObject.position + new Vector3(0, 0, -1.5f);
        _myTransform.position = position;
    }
}
