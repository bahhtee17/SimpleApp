﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExampleApp.Infrastructure.Commands;
using ExampleApp.ViewModel.Base;

namespace ExampleApp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
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
        }
    }

}
