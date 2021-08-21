using BLL.Contracts;
using BLL.Stores;
using BLL.ViewModels;

namespace BLL.Commands
{
    public class AddNewTaskCommand : CommandBase
    {
        private readonly AddTaskViewModel _addTaskViewModel;
        private readonly TasksStore _tasksStore;
        private readonly INavigationService _navigationService;

        public AddNewTaskCommand(AddTaskViewModel addTaskViewModel, TasksStore tasksStore, INavigationService navigationService)
        {
            _addTaskViewModel = addTaskViewModel;
            _tasksStore = tasksStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string taskName = _addTaskViewModel.TaskName;
            int assignee = _addTaskViewModel.Assignee;
            string status = _addTaskViewModel.Status;
            string description = _addTaskViewModel.Description;


            _tasksStore.AddTask(taskName, assignee, status, description);
            _navigationService.Navigate();
        }
    }
}