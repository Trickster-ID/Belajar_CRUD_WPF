   M S B A M L   `   `   `  ����I  EbelajarCRUDWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:belajarCRUDWPFbelajarCRUDWPF  5          belajarCRUDWPF.loginregis   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:belajarCRUDWPF     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5          � WindowStartupLocation$  CenterScreen=�5	       � Title$ 
loginregis��5
      $	��300��5      $	��350��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      .+�5      �� $��2��6    �� CornerRadius$ 10��6&   ��5      �� 5      .��5      �  � Offset$	 0.0Q�6'    � Color$ #7be9f7��64   � 5      $ 1Q�6'   $ #f083da��62   5      5       �� 5"      $��	0,0,0,165q�6   $��Center=�6,   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon  $��50��5$      $��50��5%      $��Center=�5&      
�������	   Kind$	 Analog=�5(      
 J� Opacity$	
 0.8Q�5)      �� 5*      $��0,10,0,0q�5+      $��Center=�5,      $��	helvetica)�5-      $��22(�5.      
�������$	
 0.8Q�50      $��Login��51      52      �� 54      .+�56      �� $��40,170,40,0q�6    �� Orientation$ 
Horizontal=�62   .+�57      �� -   5         ��Name$ 	txt_login��58      $	��192��59      $
��Left=�5:      $
��Left=�5;      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email��5<      
������ $��0q�5>      $��	helvetica)�5?      $��18(�5@      $��Light"�5A      
�������$	
 0.8Q�5C      5D        5E      $��29��5F      $��29��5G      
�������$	 Account=�5I      $	
 0.8Q�5J      5K      �� 5L      $	��220��5M      $��2��5N      $��0,0,0,0q�5O      
�������$	
 0.5Q�5Q      �� 5S      $��
40,20,40,0q�6   $ 
Horizontal=�61   .+�5T      G� -   5         G�Name$ txt_pass��5U      $	��192��5V      $
��Left=�5W      $
��Left=�5X      $ Password��5Y      
������ $��0q�5[      $��	helvetica)�5\      $��18(�5]      $��Light"�5^      
�������$	
 0.8Q�5`      5a        5b      $��29��5c      $��29��5d      
�������$	 TextboxPassword=�5f      $	
 0.8Q�5g      5h      �� 5i      $	��220��5j      $��2��5k      $��0,0,0,0q�5l      
�������$	
 0.5Q�5n      �� 5p      $ 
Horizontal=�6   .+�5r      �� -   5         ��Name$ btn_to_forgot��5s      $	��100��5t      $��35��5u      $��	40,30,0,0q�5v      
������ 
�������$��
Fogot Pass��5z      �� 5{      -   5        $ 	btn_login��5|      $	��100��5}      $��35��5~      $��
18,30,20,0q�5      
������ 
�������$��Login��5�      5�      5�      5�      5�      5�      