namespace Application.Command;

/// <summary>
/// Исполняет появившиеся работы, сохраняет неудачно завершенные.
/// </summary>
public class Worker
{
    private List<Job> _failedJobs = new();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="provider"><see cref="JobProvider"/>.</param>
    public Worker(JobProvider provider) => provider.JobsObservable.Subscribe(RunJob);

    private void RunJob(Job job)
    {
        if (!job.Execute())
        {
            _failedJobs.Add(job);
        }
    }
}
