﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Legacy.WPFRegionalManager.ViewModels;
using Legacy.WPFRegionalManager.ViewModels.Patient;

namespace Legacy.WPFRegionalManager.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientDetailView : UserControl
    {
        public PatientDetailView()
        {
            InitializeComponent();
        }

        public PatientDetailViewModel _vm;
        public PatientDetailView(PatientDetailViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }
    }
}

