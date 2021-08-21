using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class TasksListingViewModel : ViewModelBase
    {
        IUserService _userService;

        private readonly TasksStore _tasksStore;
        private readonly ObservableCollection<TaskViewModel> _tasks;
        public IEnumerable<TaskViewModel> Tasks => _tasks;
        

        public ICommand AddNewTaskCommand { get; }

        public TasksListingViewModel(TasksStore tasksStore, INavigationService addTaskNavigationService, IUserService userService)
        {
            _tasksStore = tasksStore;
            _userService = userService;

            AddNewTaskCommand = new NavigateCommand(addTaskNavigationService);
            _tasks = new ObservableCollection<TaskViewModel>();

            _tasksStore.TaskAdded += OnTaskAdded;
        }

        private void OnTaskAdded(string taskName, int assigneeId, string status, string description)
        {
            var assignee = _userService.GetFullName(assigneeId);
            _tasks.Add(new TaskViewModel(taskName, status, description, assignee));
        }
    }
}