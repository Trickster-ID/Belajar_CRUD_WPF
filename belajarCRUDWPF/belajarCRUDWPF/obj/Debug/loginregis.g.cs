﻿#pragma checksum "..\..\loginregis.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3B206042D64B26A15BDE901DF4132F93E6290BB75DEDB5A1AA1BB704E9AD3393"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using belajarCRUDWPF;


namespace belajarCRUDWPF {
    
    
    /// <summary>
    /// loginregis
    /// </summary>
    public partial class loginregis : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\loginregis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_login;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\loginregis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_pass;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\loginregis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_to_forgot;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\loginregis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;
        
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
            System.Uri resourceLocater = new System.Uri("/belajarCRUDWPF;component/loginregis.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\loginregis.xaml"
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
            
            #line 15 "..\..\loginregis.xaml"
            ((belajarCRUDWPF.loginregis)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_login = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\loginregis.xaml"
            this.txt_login.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_login_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_pass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 97 "..\..\loginregis.xaml"
            this.txt_pass.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_pass_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_to_forgot = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\loginregis.xaml"
            this.btn_to_forgot.Click += new System.Windows.RoutedEventHandler(this.btn_to_forgot_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_login = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\loginregis.xaml"
            this.btn_login.Click += new System.Windows.RoutedEventHandler(this.btn_login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

