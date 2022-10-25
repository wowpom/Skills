namespace CodeBase.Skills.Presenters
{
    public interface ISkillPresenter
    {
        string Id { get; }
        void Select(bool isSelect);
    }
}
