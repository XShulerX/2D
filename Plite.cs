using UnityEngine;


public class Plite : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _door;
    private FixedJoint2D _fixedJoint;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _fixedJoint = GetComponent<FixedJoint2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(_fixedJoint == null)
        {
            Destroy(_door);
            Destroy(this);
        }
    }
    #endregion
}
