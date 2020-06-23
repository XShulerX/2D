using UnityEngine;


public class MyCamera : MonoBehaviour
{

    #region Fields

    private Transform _player;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_player.position + new Vector3(0,3,-10), transform.position, 0.9f);
    }
    #endregion
}
