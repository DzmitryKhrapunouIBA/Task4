namespace BLL.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        public string ProjectName { get; set; }

        public ProjectViewModel(string projectName)
        {
            ProjectName = projectName;
        }
    }
}
