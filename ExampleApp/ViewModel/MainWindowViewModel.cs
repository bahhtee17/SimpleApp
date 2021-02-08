using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExampleApp.Infrastructure.Commands;
using ExampleApp.Models;
using ExampleApp.ViewModel.Base;

namespace ExampleApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {


        private int _SelectedPageIndex;

        public int SelectedPageIndex { get => _SelectedPageIndex; set => Set(ref _SelectedPageIndex, value); }




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


        #region Commands
        // Поле 
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;


        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion


        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LimdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);


            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;
        }
    }

}
