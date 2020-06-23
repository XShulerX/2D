using System.Collections.Generic;
using UnityEngine;


public class CharacterData : MonoBehaviour, IObservable
{
    #region Fields

    private List<IObserver> _observers = new List<IObserver>();
    public int Score = 0;
    public float Speed;
    public float Health;
    public float MaxHealth;
    public float MinimalDistanceToGround;
    public float MinimalDistanceToEnemy;
    public float JumpForce;

    #endregion

    #region UnityMethods

    private void Start()
    {
        NotifyObservers();
    }

    #endregion


    #region IObservable

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void AddObserver(IObserver[] observers)
    {
        _observers.AddRange(observers);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach(IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }

    #endregion

}
