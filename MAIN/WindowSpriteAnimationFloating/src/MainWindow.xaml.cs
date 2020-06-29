using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WindowSpriteAnimationFloating.src;

namespace WindowSpriteAnimationFloating
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap original;
        private Bitmap[] frames = new Bitmap[0];
        private ImageSource[] imgFrame = new ImageSource[0];

        private int frame = -1;

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt"))
            {
                string[] readData = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt").ToList().ConvertAll(x => x.Split('=')[1]).ToArray();

                if (readData.Length == 3)
                {
                    globalClass.ImagePath = readData[0];
                    globalClass.SpriteCount = int.Parse(readData[1]);
                    globalClass.SpriteRowCount = int.Parse(readData[2]);
                }
            }
        }

        private void NextFrame(object sender, EventArgs e)
        {
            if(frame == 0)
            {
                this.Width = SpriteImage.Source.Width;
                this.Height = SpriteImage.Source.Height;
            }

            frame = (frame + 1) % globalClass.SpriteCount;
            SpriteImage.Source = imgFrame[frame];
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            original = System.Drawing.Image.FromFile(globalClass.ImagePath) as Bitmap;
            frames = new Bitmap[globalClass.SpriteCount];
            imgFrame = new ImageSource[globalClass.SpriteCount];

            for (int i = 0; i < globalClass.SpriteCount; i++)
            {
                frames[i] = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(frames[i]))
                {
                    g.DrawImage(original, new Rectangle(0, 0, 100, 100), new Rectangle(i * 100, 0, 100, 100), GraphicsUnit.Pixel);

                    var handler = frames[i].GetHbitmap();
                    try
                    {
                        imgFrame[i] = Imaging.CreateBitmapSourceFromHBitmap(handler, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    }
                    finally { DeleteObject(handler); }
                }
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.0167 * 3);
            timer.Tick += NextFrame;
            timer.Start();

            MouseDown += MainWindow_MouseDown;

            var menu = new System.Windows.Forms.ContextMenu();
            var noti = new NotifyIcon
            {
                Icon = new Icon(@"C:\Users\LG\Desktop\C#Proj\MAIN\WindowSpriteAnimationFloating\Resource\icons8_asteroid.ico"),
                Visible = true,
                Text = "Sprite Animation"
            };

            var item = new MenuItem()
            {
                Index = 0,
                Text = "Settings"
            };
            item.Click += (object se, EventArgs ev) => {
                SettingsWindow w = new SettingsWindow(); 
                w.ShowDialog(); 
                timer.Stop();
                MouseDown -= MainWindow_MouseDown;
                this.Window_Loaded(sender, e);
            };
            var item2 = new MenuItem()
            {
                Index = 1,
                Text = "Exit"
            };
            item2.Click += (object se, EventArgs ev) => { System.Windows.Application.Current.Shutdown(); };

            menu.MenuItems.AddRange(new MenuItem[] { item, item2 });
            noti.ContextMenu = menu;
        }
    }
}
