﻿#pragma checksum "..\..\..\src\SettingsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E453330C96620F96A06A2E5882BB0D829C97D33F5A59843021F74DDE5B53354D"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WindowSpriteAnimationFloating.src;


namespace WindowSpriteAnimationFloating {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbSize;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox xSize;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ySize;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ImagePath;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SpriteCount;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SpriteRowCount;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\src\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SpriteNextTime;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WindowSpriteAnimationFloating;component/src/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\src\SettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\src\SettingsWindow.xaml"
            ((WindowSpriteAnimationFloating.SettingsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\src\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Window_Close);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbSize = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\..\src\SettingsWindow.xaml"
            this.cbSize.Click += new System.Windows.RoutedEventHandler(this.checkBox_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.xSize = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ySize = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ImagePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 35 "..\..\..\src\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_FileExplore);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SpriteCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.SpriteRowCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SpriteNextTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 47 "..\..\..\src\SettingsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_SaveButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

