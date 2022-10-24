namespace CodeBase.Experience.Presenters
{
    public interface IExperiencePresenter
    {
        void Add(int valueExp);
        bool TryTake(int value);
    }
}