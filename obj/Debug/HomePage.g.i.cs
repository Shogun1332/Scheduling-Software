﻿#pragma checksum "..\..\HomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "876EB5838312FCA7046507C9113A20F6BD90270F87CA12DDD4C627CB7D92453A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using C969___Scheduling_Software;
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


namespace C969___Scheduling_Software {
    
    
    /// <summary>
    /// HomePage
    /// </summary>
    public partial class HomePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homeButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button apptButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button customerButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calendarButton;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reportsButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid homeDataGrid;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle noAppointmentsRectangle;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label noAppointmentsLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/C969 - Scheduling Software;component/homepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HomePage.xaml"
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
            this.homeButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\HomePage.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.homeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.apptButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\HomePage.xaml"
            this.apptButton.Click += new System.Windows.RoutedEventHandler(this.apptButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.customerButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\HomePage.xaml"
            this.customerButton.Click += new System.Windows.RoutedEventHandler(this.customerButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.calendarButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\HomePage.xaml"
            this.calendarButton.Click += new System.Windows.RoutedEventHandler(this.calendarButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.reportsButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\HomePage.xaml"
            this.reportsButton.Click += new System.Windows.RoutedEventHandler(this.reportsButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.homeDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.noAppointmentsRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 8:
            this.noAppointmentsLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
