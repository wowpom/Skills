namespace CodeBase.Skills.Views
{
    public interface IDynamicSkillView : ISkillView
    {
        void SetAvailableView();
        void SetStudiedView();
    }
}