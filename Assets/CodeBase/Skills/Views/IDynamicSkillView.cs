namespace CodeBase.Skills.Views
{
    public interface IDynamicSkillView : ISkillView
    {
        void SetAvailableView();

        void SetUnavailableView();

        void SetStudiedView();
    }
}