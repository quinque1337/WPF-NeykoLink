   M S B A M L   `   `   `  ����D  @MegaPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MegaPhone.WindowFolder.Buttons_DataBase'MegaPhone.WindowFolder.Buttons_DataBase  5   	   :    4MegaPhone.WindowFolder.Buttons_DataBase.Add_Employee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:MegaPhone.WindowFolder.Buttons_DataBase     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$/  )Добавление Сотрудника��5	   	   $	��500��5
   	   $	��400��5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   .��5      � .+�5   
   �� $	��400��5      $	��500��5         DarkBlue#���   5      $��2q�5        BorderColor#���  5       �� CornerRadius$ 15��5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��Center=�5      $��Center=�5      ._�5      �  � RowDefinitions 5      �� 5      $	��50* �6$   �� 5      $	��10* �6$   .+�5       �� $��2��6   .+�5!      �� -   5        $��
UsernameTB��5!      .  (MaterialDesignThemes.Wpf.TextFieldAssist   LeadingIcon$ BadgeAccount=�60   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Введите юзернейм��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    ! MaterialDesignOutlinedTextBox#��[ 6     BigLabelColor#���  67  	   HasLeadingIcon	 . 
   
Background
 6^   Z� 6d  G� 5"      -   5        $��
PasswordTB��5"   "   $ PasswordAdd=�64   $! Введите пароль��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    + 'MaterialDesignOutlinedRevealPasswordBox#��[ 6  #���  6B  	 . 
 6a   Z� 6o  �� 5#      -   5        $��RoleCB��5#      $ AccountQuestionMark=�6-   $ Выберите роль��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    " MaterialDesignOutlinedComboBox#��[ 6  #���  69  	 . 
 6b   Z� .@�5$      �� $��Сотрудник��6'   
 � Tag$ employee��6;   �� 5%      $��
Админ��6'   $ admin��67   5&      �� 5'      -   5        $��
FullNameTB��5'      $ Passport=�6T   $ Введите ФИО��6~   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�   #��[ 6�   #���  6.  	 . 
 60   Z� 6[  (  "System.Windows.Controls.DatePicker  5(      -   5        $��BirthDateDP��5(   !   $ 	DateRange=�6X   $. (Введите дату рождения��6�   $��10q�6�   $	��250��6�   $��2q�6�   #���  6�    $  MaterialDesignOutlinedDatePicker#��[ 6  #���  6@  	 . 
 64   Z� 6m  5)      �� 5*       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6S   $��1��6n   .+�5+   "   �� -   5         ��Name$	 Add��5+   )   $��6��5,   "   $	��150��5-   "   $��50��5.   "     	LightBlue#���  5/   "   
�������$��Nunito)�51   "   $��18(�52   "   $
��Bold"�53   "   $��15q�54   "   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��55   "   6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush# �  56   "   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsDisabled .   MaterialDesignFlatButton#���  58   "   z�5:      �� 5;       �� ScaleX$	 0.9Q�6-    �� ScaleY$	 0.9Q�6:   .��5=      �� $ 
Horizontal=�6%   .+�5>      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�5?   !   $��25��5@   "   $��25��5A   "      Kind$ DatabaseAdd=�5B   "   �� 5C      $��2q�6(   $��Добавить��63   5D      5E      �� 5F      -   5        $
 Exit��5F      $��6��5G      $	��150��5H      $��50��5I       	 
ErrorColor#��� 	 5J      
�������$��Nunito)�5L      $��18(�5M      $
��Bold"�5N      $��15q�5O      $ 15��5P      # �  5Q       . #���  5S      z�5U      �� 5V      $	 0.9Q�6-   $	 0.9Q�6:   .��5X      �� $ 
Horizontal=�6%   .+�5Y        $��2q�5Z      $��25��5[      $��25��5\      $ DatabaseOff=�5]      �� 5^      $��2q�6(   $��Отмена��63   5_      5`      5a      5b      5c      5d      5e      