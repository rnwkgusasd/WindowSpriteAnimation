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

                FileInfo file = new FileInfo(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt");

                if (!file.Directory.Exists) file.Directory.Create();

                if (!file.Exists) file.Create();

                if (file.Exists)
                {
                    File.WriteAllLines(file.FullName, arr);
                }

                globalClass.ImagePath = ImagePath.Text;
                globalClass.SpriteCount = int.Parse(SpriteCount.Text);
                globalClass.SpriteRowCount = int.Parse(SpriteRowCount.Text);
                globalClass.SpriteNextTime = double.Parse(SpriteNextTime.Text);

                System.Windows.MessageBox.Show("Success!", "save", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }

        private void Click_FileExplore(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
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
        }
    }
}
