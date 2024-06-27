using System.Reactive.Linq;

namespace Application.Command;

/// <summary>
/// Предоставляет работы.
/// </summary>
public class JobProvider
{
    /// <summary>
    /// Работы.
    /// </summary>
    public IObservable<Job> JobsObservable;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public JobProvider() =>
        JobsObservable = Observable.Interval(TimeSpan.FromSeconds(5)).Select(x =>
        {
            var job = new Job();
            job.SetUp(DoSmth);
            return job;
        });

    private void DoSmth()
    {
    }
}
