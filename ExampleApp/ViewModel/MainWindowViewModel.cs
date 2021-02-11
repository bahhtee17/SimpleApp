using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExampleApp.Infrastructure.Commands;
using ExampleApp.Models;
using ExampleApp.Models.Decanat;
using ExampleApp.ViewModel.Base;

namespace ExampleApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {


        public object[] CompositeCollection  { get; }

        private object _SelectedCompositeValue;
        public object SelectedCompositeValue 
        { get => _SelectedCompositeValue;
            set => Set(ref _SelectedCompositeValue, value);
        }


        public ObservableCollection<Group> Groups { get; }

        private Group _SelectedGroup;

        public Group SelectedGroup { get => _SelectedGroup; set => Set(ref _SelectedGroup, value); }


        //--------------------------------------------------------------------------------------------------

        #region SelectedPageIndex
        private int _SelectedPageIndex;

        public int SelectedPageIndex { get => _SelectedPageIndex; set => Set(ref _SelectedPageIndex, value); }

        #endregion


        #region IEnumerable TestDataPoints
        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints; set => Set(ref _TestDataPoints, value); }
        #endregion



        #region Title Программы
        /// <summary>
        /// Title Программы
        /// </summary>
        private string title = "Анализ статистики COVID-19";

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        #region Статус программы
        /// <summary>
        /// Статус программы
        /// </summary>
        private string status = "Прогресс";

        public string Status
        {
            get => status;
            set => Set(ref status, value);
        }
        #endregion


        //--------------------------------------------------------------------------------------------------

        #region Commands
        // Поле 
 public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;


        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();

        }


        public ICommand CreateGroupCommand { get; }

        private bool CanCreateGroupCommandExecute(object p) => true;

        private void OnCreateGroupCommandExecuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_group = new Group()
            {
                Name = $"Группа {group_max_index}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(new_group);
        }


        public ICommand DeleteGroupCommand { get; }

        private bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);

        private void OnDeleteGroupCommandexecuted(object p)
        {
            if (!(p is Group group)) return;
            Groups.Remove(group);
        }







        #endregion









        //------------------------------------------------------------------------------------------------------

        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LimdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            CreateGroupCommand = new LimdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
            DeleteGroupCommand = new LimdaCommand(OnDeleteGroupCommandexecuted, CanDeleteGroupCommandExecute);


            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;

            var student_index = 1;

            var students = Enumerable.Range(1, 10).Select(i => new Student 
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0

            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);


            var data_list = new List<object>();
            data_list.Add("Hello World");
            data_list.Add(45);
            var group = Groups[1];
            data_list.Add(group);
            data_list.Add(group.Students[0]);
            CompositeCollection = data_list.ToArray();

        }
    }

}
