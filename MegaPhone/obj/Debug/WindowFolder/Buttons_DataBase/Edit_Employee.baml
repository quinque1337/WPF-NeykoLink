   M S B A M L   `   `   `  ����D  @MegaPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MegaPhone.WindowFolder.Buttons_DataBase'MegaPhone.WindowFolder.Buttons_DataBase  5   	   ;    5MegaPhone.WindowFolder.Buttons_DataBase.Edit_Employee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:MegaPhone.WindowFolder.Buttons_DataBase     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$/  )Добавление Сотрудника��5	   	   $	��500��5
   	   $	��400��5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   .��5      � .+�5   
   �� $	��400��5      $	��500��5         DarkBlue#���   5      $��2q�5        BorderColor#���  5       �� CornerRadius$ 15��5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��Center=�5      $��Center=�5      ._�5      �  � RowDefinitions 5      �� 5      $	��50* �6$   �� 5      $	��10* �6$   .+�5       �� $��2��6   .+�5!      �� -   5        $��
UsernameTB��5!      .  (MaterialDesignThemes.Wpf.TextFieldAssist   LeadingIcon$ BadgeAccount=�6T   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Введите юзернейм��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    ! MaterialDesignOutlinedTextBox#��[ 6     BigLabelColor#���  67  	   HasLeadingIcon	 . 
   
Background
 60   Z� 6d  G� 5"      -   5        $��
PasswordTB��5"   "   $ PasswordAdd=�6X   $! Введите пароль��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    + 'MaterialDesignOutlinedRevealPasswordBox#��[ 6  #���  6B  	 . 
 64   Z� 6o  �� 5#      -   5        $��RoleCB��5#      $ AccountQuestionMark=�6Q   $ Выберите роль��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    " MaterialDesignOutlinedComboBox#��[ 6  #���  69  	 . 
 6-   Z� 6f  �� 5$      -   5        $��
FullNameTB��5$      $ Passport=�6T   $ Введите ФИО��6~   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�   #��[ 6�   #���  6.  	 . 
 60   Z� 6[  (  "System.Windows.Controls.DatePicker  5%      -   5        $��BirthDateDP��5%   !   $ 	DateRange=�6X   $. (Введите дату рождения��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    $  MaterialDesignOutlinedDatePicker#��[ 6  #���  6@  	 . 
 64   Z� 6m  5&      �� 5'       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6S   $��1��6n   .+�5(   "   �� -   5         ��Name$
 Edit��5(   )   $��6��5)   "   $	��200��5*   "   $��50��5+   "     	LightBlue#���  5,   "   
�������$��Nunito)�5.   "   $��18(�5/   "   $
��Bold"�50   "   $��5q�51   "   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��52   "   6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush# �  53   "   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsDisabled .   MaterialDesignFlatButton#���  55   "   z�57      �� 58       �� ScaleX$	 0.9Q�6-    �� ScaleY$	 0.9Q�6:   .��5:      �� $ 
Horizontal=�6%   .+�5;      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�5<   !   $��25��5=   "   $��25��5>   "      Kind$ DatabaseAdd=�5?   "   �� 5@      $��2q�6(   $ ��Редактировать��63   5A      5B      �� 5C      -   5        $
 Exit��5C      $��6��5D      $	��150��5E      $��50��5F       	 
ErrorColor#��� 	 5G      
�������$��Nunito)�5I      $��18(�5J      $
��Bold"�5K      $��5q�5L      $ 15��5M      # �  5N       . #���  5P      z�5R      �� 5S      $	 0.9Q�6-   $	 0.9Q�6:   .��5U      �� $ 
Horizontal=�6%   .+�5V        $��2q�5W      $��25��5X      $��25��5Y      $ DatabaseOff=�5Z      �� 5[      $��2q�6(   $��Отмена��63   5\      5]      5^      5_      5`      5a      5b      