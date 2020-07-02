using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindowSpriteAnimationFloating.src;

namespace WindowSpriteAnimationFloating
{
    /// <summary>
    /// SettingsWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            // Window locate => right bottom
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 50;
        }

        private void Window_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Click_SaveButton(object sender, EventArgs e)
        {
            if(System.Windows.MessageBox.Show("Save?", "save", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                string[] arr = new string[] { "IMAGEPATH=" + ImagePath.Text, "SPRITECOUNT=" + SpriteCount.Text, "SPRITEROWCOUNT=" + SpriteRowCount.Text, "SPRITENEXTTIME=" + SpriteNextTime.Text };
                string[] manual = new string[] { "MANUALSIZECHANGE=" + cbSize.IsChecked?.ToString(), "MANUALWIDTH=" + xSize.Text, "MANUALHEIGHT=" + ySize.Text, "MANUALSTARTROW=" + rowStart.Text };

                FileInfo file = new FileInfo(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt");

                if (!file.Directory.Exists) file.Directory.Create();

                if (!file.Exists) file.Create();

                if (file.Exists)
                {
                    try
                    {
                        File.WriteAllLines(file.FullName, arr);
                        File.AppendAllLines(file.FullName, manual);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                globalClass.ImagePath = ImagePath.Text;
                globalClass.SpriteCount = int.Parse(SpriteCount.Text);
                globalClass.SpriteRowCount = int.Parse(SpriteRowCount.Text);
                globalClass.SpriteNextTime = double.Parse(SpriteNextTime.Text);

                globalClass.ManualWidth = int.Parse(xSize.Text);
                globalClass.ManualHeight = int.Parse(ySize.Text);
                globalClass.ManualStartRowPoint = int.Parse(rowStart.Text);

                System.Windows.MessageBox.Show("Success!", "save", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }

        private void Click_FileExplore(object sender, EventArgs e)
        {
            try
            {
                // Get image file path
                OpenFileDialog dialog = new OpenFileDialog();
                // Image file select filter
                dialog.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImagePath.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImagePath.Text = globalClass.ImagePath;
            SpriteCount.Text = globalClass.SpriteCount.ToString();
            SpriteRowCount.Text = globalClass.SpriteRowCount.ToString();
            SpriteNextTime.Text = globalClass.SpriteNextTime.ToString();

            cbSize.IsChecked = globalClass.ManualSizeChange;

            if(globalClass.ManualSizeChange)
            {
                xSize.IsEnabled = true;
                ySize.IsEnabled = true;
                rowStart.IsEnabled = true;
            }

            xSize.Text = globalClass.ManualWidth.ToString();
            ySize.Text = globalClass.ManualHeight.ToString();
            rowStart.Text = globalClass.ManualStartRowPoint.ToString();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if(cbSize.IsChecked != null && (bool)cbSize.IsChecked)
            {
                xSize.IsEnabled = true;
                ySize.IsEnabled = true;
                rowStart.IsEnabled = true;

                globalClass.ManualSizeChange = true;
            } 
            else
            {
                xSize.IsEnabled = false;
                ySize.IsEnabled = false;
                rowStart.IsEnabled = false;

                globalClass.ManualSizeChange = false;
            }
        }
    }
}
