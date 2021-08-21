using BLL.Commands;
using BLL.Contracts;
using BLL.Stores;
using System.Windows.Input;

namespace BLL.ViewModels
{
    public class AddTaskViewModel : ViewModelBase
    {
        private string _taskName;
        private int _assignee;
        private string _status;
        private string _description;

        public string TaskName
        {
            get
            {
                return _taskName;
            }
            set
            {
                _taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        public int Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                _assignee = value;
                OnPropertyChanged(nameof(Assignee));
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTaskViewModel(TasksStore tasksStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddNewTaskCommand(this, tasksStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}