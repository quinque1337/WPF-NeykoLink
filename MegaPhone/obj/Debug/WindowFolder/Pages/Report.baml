   M S B A M L   `   `   `  ����D  @MegaPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MegaPhone.WindowFolder.PagesMegaPhone.WindowFolder.Pages  5      U QLiveCharts.Wpf, Version=0.9.8.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      )    #MegaPhone.WindowFolder.Pages.Report   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:MegaPhone.WindowFolder.Pages     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5
        N� Title$#  Создание отчета��5         DarkBlue N� 
Background# �   6   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��5q�6   $+��%Формирование отчета��6   $��24(�6:   $��Nunito)�6H   $��	ExtraBold"�6\   $��Italic$�6s   $��Center=�6�     BigLabelColor#��[ 6�   �� 5   
   -   5        $��SearchTB��5      $��0,0,5,0q�6"   $	��250��63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6?      
IsFloating .  $��2q�6�     BorderColor#���  6�    ! MaterialDesignOutlinedTextBox#��[ 6�   #��[ 6  $��Nunito)�6B  .  (MaterialDesignThemes.Wpf.TextFieldAssist   LeadingIcon$ DatabaseSearch=�6V     HasLeadingIcon . $��0��6�  $��Right=�6�  $��55��6�  $��1��6     
Background 6{   Z� 6  &   System.Windows.Controls.DataGrid  5   
   -   5        $��
EmployeeDG��5      $��1��5      $��0��6    $��3��60   $��5q�6D   $
��Left=�6O     MaterialDesignDataGrid#��[ 5      #���  6;   #��[ 5         CanUserResizeColumns .   & "MaterialDesignDataGridColumnHeader	   ColumnHeaderStyle#	 [ 5      
   CanUserAddRows
 .     SelectionMode$ Extended=�5         AutoGenerateColumns .  ��. $
��Auto=�5      $
��Auto=�5          
IsReadOnly .  J� RenderTransformOrigin$ 0.5,0.5&�5!      z�5#      V� 5$      .~�5%      �� �� 5&       �� AngleX$
 0.09Q�6$   �� 5'      T� 5(       T� X$ 0.536Q�6)   5)         Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *id+  5.      $ ФИО��6%   $ * 62    6<   �� *	full_name+  5/      $ Роль��6%   $ * 63    6=   �� *role+51      �� 54      -   5        $��PeriodComboBox��54      $ 	DateRange=�6-   $��3��6X   $��1��6e   $
��Left=�6u   $# Выберите период��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6   " MaterialDesignOutlinedComboBox#��[ 61  #���  6i   .  6�   Z� .@�55      �� $��За день��6   �� 56      $��За неделю��6   �� 57      $��За месяц��6   �� 58      $��За год��6   �� 59      $��За все время��6   5:      �� 5;   
   -   5         ��Name$	 Add��5;      $	��250��5<      $��	0,5,-15,0q�5=      $��3��5>      $��1��6   $��Right=�6*   $��50��5?        	LightBlue#���  5@      
�������$��Nunito)�5B      $��18(�5C      $
��Bold"�5D      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5E      6	  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner 	  Brush# �  5F      +
  %MaterialDesignThemes.Wpf.RippleAssist 
  
IsDisabled .   MaterialDesignFlatButton#���  5H       � Cursor$
 Hand��5I   #   z�5J      �� 5K       �� ScaleX$	 0.9Q�6!    �� ScaleY$	 0.9Q�6.   .��5M      ��  �� Orientation$ 
Horizontal=�6   .+�5N      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�5O      $��25��5P      $��25��5Q         Kind$ 
FileReport=�5R      �� 5S      $��2q�6   $)��#Сформировать отчет��6'   5T      5U      5V      5W      