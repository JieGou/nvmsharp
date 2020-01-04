﻿// Copyright (c) 2020 Ratish Philip 
//
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions: 
// 
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software. 
// 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE. 

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using NVMSharp.Common;
using NVMSharp.ViewModel;
using WPFSpark;

namespace NVMSharp.Views
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : SparkWindow
    {
        private const double GridRowHeight = 48;

        private CoreViewModel _coreViewModel;

        public EditWindow(CoreViewModel coreViewModel)
        {
            InitializeComponent();
            _coreViewModel = coreViewModel;
            this.DataContext = coreViewModel;
            UpdateInputGrid();
            UpdateSaveButtonState();
        }

        private void UpdateInputGrid()
        {
            switch (_coreViewModel.ModificationMode)
            {
                case ModificationModeType.NewValue:
                case ModificationModeType.EditValue:
                    inputGrid.RowDefinitions[0].Height = new GridLength(0);
                    break;
                default:
                    inputGrid.RowDefinitions[0].Height = new GridLength(GridRowHeight);
                    break;
            }
        }

        private void UpdateSaveButtonState()
        {
            var hasValidationError = !(String.IsNullOrWhiteSpace(_coreViewModel.ValidationMessage));
            switch (_coreViewModel.ModificationMode)
            {
                case ModificationModeType.NewValue:
                case ModificationModeType.EditValue:
                    saveBtn.IsEnabled = !hasValidationError && !(String.IsNullOrWhiteSpace(valueBox.Text));
                    break;
                default:
                    saveBtn.IsEnabled = !hasValidationError && !(String.IsNullOrWhiteSpace(nameBox.Text) || String.IsNullOrWhiteSpace(valueBox.Text));
                    break;
            }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnBrowseForFile(object sender, RoutedEventArgs e)
        {
            // Create a CommonOpenFileDialog to select files
            var cfd = new OpenFileDialog
            {
                CheckPathExists = true,
                CheckFileExists = true,
                Multiselect = false, // One file at a time
                Title = "Select File",
            };

            if (cfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Append the deimited path in the value textbox 
                valueBox.Text = String.IsNullOrWhiteSpace(valueBox.Text)
                    ? cfd.FileName
                    : $"{valueBox.Text};{cfd.FileName}";
            }
        }

        private void OnBrowseForFolder(object sender, RoutedEventArgs e)
        {

            // Display a CommonOpenFileDialog to select only folders  
            var cfd = new FolderBrowserDialog()
            {
                Description = "Select Folder",
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            if (cfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Append the delimited path in the value textbox 
                valueBox.Text = String.IsNullOrWhiteSpace(valueBox.Text)
                    ? cfd.SelectedPath
                    : $"{valueBox.Text};{cfd.SelectedPath}";
            }
        }

        private void HandleUserInput(object sender, TextChangedEventArgs e)
        {
            UpdateSaveButtonState();
        }
    }
}
