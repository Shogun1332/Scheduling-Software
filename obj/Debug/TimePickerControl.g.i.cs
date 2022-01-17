﻿#pragma checksum "..\..\TimePickerControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "69B77BAEE6FF8A0F50A694843D53DB209FFAEAD538223C5604988F0532BE0E90"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace WorkDayManager3.WPF.UserControls {
    
    
    /// <summary>
    /// TimeControl
    /// </summary>
    public partial class TimeControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\TimePickerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHours;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\TimePickerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMinutes;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TimePickerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAmPm;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TimePickerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUp;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TimePickerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDown;
        
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
            System.Uri resourceLocater = new System.Uri("/C969 - Scheduling Software;component/timepickercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TimePickerControl.xaml"
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
            this.txtHours = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\TimePickerControl.xaml"
            this.txtHours.KeyUp += new System.Windows.Input.KeyEventHandler(this.txt_KeyUp);
            
            #line default
            #line hidden
            
            #line 17 "..\..\TimePickerControl.xaml"
            this.txtHours.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.txt_MouseWheel);
            
            #line default
            #line hidden
            
            #line 17 "..\..\TimePickerControl.xaml"
            this.txtHours.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.txt_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtMinutes = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\TimePickerControl.xaml"
            this.txtMinutes.KeyUp += new System.Windows.Input.KeyEventHandler(this.txt_KeyUp);
            
            #line default
            #line hidden
            
            #line 19 "..\..\TimePickerControl.xaml"
            this.txtMinutes.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.txt_MouseWheel);
            
            #line default
            #line hidden
            
            #line 19 "..\..\TimePickerControl.xaml"
            this.txtMinutes.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.txt_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtAmPm = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\TimePickerControl.xaml"
            this.txtAmPm.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtAmPm_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 20 "..\..\TimePickerControl.xaml"
            this.txtAmPm.KeyUp += new System.Windows.Input.KeyEventHandler(this.txt_KeyUp);
            
            #line default
            #line hidden
            
            #line 20 "..\..\TimePickerControl.xaml"
            this.txtAmPm.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.txt_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnUp = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\TimePickerControl.xaml"
            this.btnUp.Click += new System.Windows.RoutedEventHandler(this.btnUp_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDown = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\TimePickerControl.xaml"
            this.btnDown.Click += new System.Windows.RoutedEventHandler(this.btnDown_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
