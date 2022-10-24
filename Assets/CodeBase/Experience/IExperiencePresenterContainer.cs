using CodeBase.Experience.Presenters;

namespace CodeBase.Experience
{
    public interface IExperiencePresenterContainer
    {
        IExperiencePresenter ExperiencePresenter { get; }
    }
}