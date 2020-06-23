public interface IObservable
{
    #region Methods

    void AddObserver(IObserver observer);

    void RemoveObserver(IObserver observer);

    void NotifyObservers();

    #endregion
}
