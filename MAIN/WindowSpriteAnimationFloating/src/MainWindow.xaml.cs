﻿using System;
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
        #region Member Variables

        // Original Image
        private Bitmap original;
        // Image Frames
        private Bitmap[] frames = new Bitmap[0];
        // Image Frames ImageSource
        private ImageSource[] imgFrame = new ImageSource[0];

        // Animation Timer
        private DispatcherTimer timer;

        // Window System Tray Icon
        private NotifyIcon noti;

        // Frame Index
        private int frame = -1;

        #endregion

        #region DLL

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        #endregion

        #region Initialize

        public MainWindow()
        {
            InitializeComponent();

            // Read options.txt file. Setup program
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt"))
            {
                try
                {
                    string[] readData = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\CONFIG\\options.txt").ToList().ConvertAll(x => x.Split('=')[1]).ToArray();

                    if (readData.Length == 8)
                    {
                        globalClass.ImagePath = readData[0];
                        globalClass.SpriteCount = int.Parse(readData[1]);
                        globalClass.SpriteRowCount = int.Parse(readData[2]);
                        globalClass.SpriteNextTime = double.Parse(readData[3]);

                        globalClass.ManualSizeChange = bool.Parse(readData[4]);
                        globalClass.ManualWidth = int.Parse(readData[5]);
                        globalClass.ManualHeight = int.Parse(readData[6]);
                        globalClass.ManualStartRowPoint = int.Parse(readData[7]);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            // System tray icon settings
            var menu = new System.Windows.Forms.ContextMenu();
            noti = new NotifyIcon
            {
                Icon = new Icon(@"..\..\Resource\icons8_asteroid.ico"),
                Visible = true,
                Text = "Sprite Animation"
            };

            // system tray icon context menu items
            var item = new MenuItem()
            {
                Index = 0,
                Text = "Settings"
            };
            item.Click += (object se, EventArgs ev) => {
                // program's all function stop and open options window.
                timer.Stop();
                MouseDown -= MainWindow_MouseDown;
                SettingsWindow w = new SettingsWindow();
                w.ShowDialog();
                // reload this program
                this.Window_Loaded(this, new RoutedEventArgs());
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
        #endregion

        // Timer funciton.
        private void NextFrame(object sender, EventArgs e)
        {
            // Change next image
            frame = (frame + 1) % globalClass.SpriteCount;
            SpriteImage.Source = imgFrame[frame];

            // Set window size
            if (frame == 0)
            {
                this.Width = imgFrame[frame].Width;
                this.Height = imgFrame[frame].Height;
            }
        }

        // Animation image locate follow to mouse point on MouseDown
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // if image path is not currectly, set basic path
            if (globalClass.ImagePath == "" || !File.Exists(globalClass.ImagePath))
                globalClass.ImagePath = System.Windows.Forms.Application.StartupPath + @"\..\..\Resource\icons8_asteroid_64.png";

            frame = -1;

            original = System.Drawing.Image.FromFile(globalClass.ImagePath) as Bitmap;
            frames = new Bitmap[globalClass.SpriteCount];
            imgFrame = new ImageSource[globalClass.SpriteCount];

            // calculate each frame image size - width, height
            int spriteWidth = original.Width / (globalClass.SpriteCount / globalClass.SpriteRowCount);
            int spriteHeight = original.Height / globalClass.SpriteRowCount;

            // if size mode is manual mode
            if(globalClass.ManualSizeChange)
            {
                spriteWidth = globalClass.ManualWidth;
                spriteHeight = globalClass.ManualHeight;
            }

            for (int i = 0; i < globalClass.SpriteCount; i++)
            {
                // ``` y posision
                int heightPos = 0;
                // ``` x position
                int widthPos = i;
                // current row count
                int currRowCnt = i / (globalClass.SpriteCount / globalClass.SpriteRowCount);

                // y position is each frames height * now frames row index
                heightPos = spriteHeight * currRowCnt;

                // if size mde is manual mode
                if(globalClass.ManualSizeChange)
                {
                    // y position is each frames height * (now frames row index + start frames row index)
                    heightPos = spriteHeight * (globalClass.ManualStartRowPoint + currRowCnt);
                }

                // x position is each frames width * (now frames index - 1 rows total count)
                if(i >= (globalClass.SpriteCount / globalClass.SpriteRowCount))
                    widthPos = i - ((globalClass.SpriteCount / globalClass.SpriteRowCount) * currRowCnt);

                frames[i] = new Bitmap(spriteWidth, spriteHeight);
                using (Graphics g = Graphics.FromImage(frames[i]))
                {
                    // Get frame in original image
                    g.DrawImage(original, new Rectangle(0, 0, spriteWidth, spriteHeight), new Rectangle(widthPos * spriteWidth, heightPos, spriteWidth, spriteHeight), GraphicsUnit.Pixel);

                    var handler = frames[i].GetHbitmap();
                    try
                    {
                        // frame image convert to image source
                        imgFrame[i] = Imaging.CreateBitmapSourceFromHBitmap(handler, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    }
                    finally { DeleteObject(handler); }
                }
            }

            // frames change timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(globalClass.SpriteNextTime);
            timer.Tick += NextFrame;
            timer.Start();

            // animation can move by drag n drop
            MouseDown += MainWindow_MouseDown;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // clear timer
            if(timer != null && timer.IsEnabled)
            {
                timer.Stop();
                timer = null;
            }

            GC.SuppressFinalize(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // system tray icon remove
            if (noti != null)
            {
                noti.Visible = false;
                noti.Icon = null;
                noti.Dispose();
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            // program can not change state
            // if window state is changed to maximized, frames image size changed
            if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
        }
    }
}
