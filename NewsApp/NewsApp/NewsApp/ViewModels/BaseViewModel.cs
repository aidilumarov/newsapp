﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewsApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
