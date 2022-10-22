namespace CodeBase.Skills
{
    public interface IDynamicSkillView : ISkillView
    {
        void SetAvailableView();

        void SetUnavailableView();

        void SetStudiedView();
    }
}