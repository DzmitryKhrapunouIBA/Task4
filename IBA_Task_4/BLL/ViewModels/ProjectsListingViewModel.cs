using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class ProjectsListingViewModel : ViewModelBase
    {
        private readonly ProjectsStore _projectsStore;
        private readonly ObservableCollection<ProjectViewModel> _projects;
        public IEnumerable<ProjectViewModel> Projects => _projects;

        public ICommand AddProjectCommand { get; }

        public ProjectsListingViewModel(ProjectsStore projectsStore, INavigationService addProjectNavigationService)
        {
            _projectsStore = projectsStore;

            AddProjectCommand = new NavigateCommand(addProjectNavigationService);
            _projects = new ObservableCollection<ProjectViewModel>();

            _projectsStore.ProjectAdded += OnProjectAdded;
        }

        private void OnProjectAdded(string projectName)
        {
            _projects.Add(new ProjectViewModel(projectName));
        }
    }
}