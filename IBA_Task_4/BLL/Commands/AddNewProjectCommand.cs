using BLL.Contracts;
using BLL.Stores;
using BLL.ViewModels;

namespace BLL.Commands
{
    public class AddNewProjectCommand : CommandBase
    {
        private readonly AddProjectViewModel _addProjectViewModel;
        private readonly ProjectsStore _projectsStore;
        private readonly INavigationService _navigationService;

        public AddNewProjectCommand(AddProjectViewModel addProjectViewModel, ProjectsStore projectsStore, INavigationService navigationService)
        {
            _addProjectViewModel = addProjectViewModel;
            _projectsStore = projectsStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string projectName = _addProjectViewModel.ProjectName;
            _projectsStore.AddProject(projectName);
            _navigationService.Navigate();
        }
    }
}
