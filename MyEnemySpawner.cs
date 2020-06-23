using UnityEngine;


public class MyEnemySpawner : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _startEnemy;

    #endregion

    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_enemy, _startEnemy.position, _startEnemy.rotation);
        }
    }

    #endregion
}
