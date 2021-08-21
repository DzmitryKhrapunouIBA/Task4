using BLL.Contracts;
using DAL.Models;
using System.Windows;

namespace PL.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly IProjectService _projectService;
        //private readonly ITaskService _taskService;
        //private readonly IUserService _userService;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var project = new Project("TestProject");
        //    var user = new User("Dima", "Hr", "S", "Login", "1234", true);
        //    var task = new Task("Finish", 1, 1, "In progress", "Finish this task");


        //    var entry1 = _projectService.Create(project);
        //    var entry2 = _userService.Create(user);
        //    var entry3 = _taskService.Create(task);


        //    MessageBox.Show(entry2.FirstName);
        //}
    }
}
