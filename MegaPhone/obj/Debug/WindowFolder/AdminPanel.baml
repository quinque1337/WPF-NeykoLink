   M S B A M L   `   `   `  ����D  @MegaPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MegaPhone.WindowFolderMegaPhone.WindowFolder  5   	   '    !MegaPhone.WindowFolder.AdminPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MegaPhone.WindowFolder     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
AdminPanel��5	   	   $	��620��5
   	   $
��1000��5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � Icon$" /ImageFolder/Round Graph.png��5   	   .��5      � .+�5   
   �� $
��1000��5      $	��620��5         DarkBlue#���   5      $��2q�5        BorderColor#���  5       �� CornerRadius$ 15��5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��Center=�5      $��Center=�5      ._�5      �  � ColumnDefinitions 5      �� 5      $
��100* �6'   �� 5       $
��330* �6'    � RowDefinitions 5"      �� 5#      $	��20* �6$   �� 5$      $
��120* �6$   �� 5%      $	��20* �6$   .+�5'      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�66   $	��Top=�6S   $��0,16,0,0q�6k   .+�5(      �� $"��/ImageFolder/Round Graph.png��6   $��50��6B   $��50��6M   �� 5)      $��0��5*      $��	NeykoLink��5+        BigLabelColor#���  5,      $��Nunito)�5-      $��30(�5.      $��Italic$�5/      $��
ExtraBlack"�50        	BoldLabel#���  51      $��Center=�52      $��Center=�6)   53      �� 54      $��База данных��6   $��12(�55      $��Nunito)�56      $��Italic$�57        Headline#���  58      $��	ExtraBold"�59      $��20,72,20,20q�6/   $��3��6D   �� 5:      $��1��6   $��20,20,20,20q�6*   $��2��6?   .+�5;      �� -   5        $��	Statistic��5;   ?   +  %MaterialDesignThemes.Wpf.RippleAssist
   
IsDisabled
 . $	��191��6P   $��40��6\     MaterialDesignFlatButton#��[ 6h   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��6�   $��18(�6�   $��Nunito)�6�    � ToolTip$
 Icon��6�   
������ $��0q�6  .��5<      �� $	 
Horizontal=�6%   $	��182��6>   .+�5=      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
ChartDonut=�6*   $��27��6<   $��40��6H   #���  6S   �� 5>      $��Статистика��6$   $��Nunito)�69   $��Italic$�6M   $��	ExtraBold"�6`   $	��100��6w   #���  6�   $��Center=�6�   $��15(�6�   5@      5A      �� 5B      -   5        $��Clients��5B   ?   
 . $	��191��6N   $��40��6Z   #��[ 6f   $ 5��6�   $��18(�6�   $��Nunito)�6�   $
 Icon��6�   
������ $��0q�6  .��5C      �� $	 
Horizontal=�6%   $	��182��6>   .+�5D        $ PeopleGroup=�6*   $��27��6=   $��40��6I   #���  6T   �� 5E      $��Сотрудники��6$   $��Nunito)�69   $��Italic$�6M   $��	ExtraBold"�6`   $	��100��6w   #���  6�   $��Center=�6�   $��15(�6�   5G      5H      �� 5I      -   5        $��Tasks��5I   ?   
 . $	��191��6L   $��40��6X   #��[ 6d   $ 5��6�   $��18(�6�   $��Nunito)�6�   $
 Icon��6�   
������ $��0q�6  .��5J      �� $	 
Horizontal=�6%   $	��182��6>   .+�5K        $ Subtasks=�6*   $��27��6:   $��40��6F   #���  6Q   �� 5L      $��Задачи��6$   $��Nunito)�65   $��Italic$�6I   $��	ExtraBold"�6\   $	��100��6s   #���  6   $��Center=�6�   $��15(�6�   5N      5O      5P      �� 5Q      $��Инструменты��6   $��12(�5R      $��Nunito)�5S      $��Italic$�5T      #���  5U      $��1��5V      $��	ExtraBold"�5W      $��20,135,20,20q�6.   $��2��6D   �� 5X      $��1��6   $��20,155,20,20q�6*   $��2��6@   .+�5Y      �� -   5        $��Otchet��5Y   ?   
 . $	��191��6M   $��40��6Y   #��[ 6e   $ 5��6�   $��18(�6�   $��Nunito)�6�   $
 Icon��6�   
������ $��0q�6  .��5Z      �� $	 
Horizontal=�6%   $	��182��6>   .+�5[        $ FileDocumentArrowRight=�6*   $��27��6H   $��40��6T   #���  6_   �� 5\      $��
Отчет��6$   $��Nunito)�64   $��Italic$�6H   $��	ExtraBold"�6[   $	��100��6r   #���  6~   $��Center=�6�   $��15(�6�   5]      5^      5_      �� 5`      $��Аккаунт��6   $��12(�5a      $��Nunito)�5b      $��Italic$�5c      #���  5d      $��1��5e      $��	ExtraBold"�5f      $��20,190,21,244q�6*   $��30��6A   �� 5g      $��1��6   $��20,70,20,20q�6*   $��90��6?   .+�5h      �� -   5        $��ChangePassword��5h   ?   
 . $	��191��6U   $��40��6a   #��[ 6m   $ 5��6�   $��18(�6�   $��Nunito)�6�   $
 Icon��6�   
������ $��0q�6
  .��5i      �� $	 
Horizontal=�6%   $	��182��6>   .+�5j        $ KeyChain=�6*   $��27��6:   $��40��6F   #���  6Q   �� 5k      $��Смена пароля��6$   $��Nunito)�6;   $��Italic$�6O   $��	ExtraBold"�6b   $	��120��6y   #���  6�   $��Center=�6�   $��15(�6�   5m      5n      �� 5o      -   5        $
��Exit��5o   ?   
 . $	��191��6K   $��40��6W   #��[ 6c   $ 5��6�   $��18(�6�   $��Nunito)�6�   $
 Icon��6�   
������ $��0q�6   .��5p      �� $	 
Horizontal=�6%   $	��182��6>   .+�5q        $ 
AccountOff=�6*   $��27��6<   $��40��6H   #���  6S   �� 5r      $��
Выйти��6$   $��Nunito)�64   $��Italic$�6H   $��	ExtraBold"�6[   $	��100��6r   $��30��6~   #���  6�   $��Center=�6�   $��15(�6�   5t      5u      5v      �� 5w      $��3��6   $	 
Horizontal=�6*   $��Center=�6C   $��Center=�6`   .+�5x        $ BadgeAccount=�6"   $��45��66   $��45��6B   #���  6M   �� 5y      .+�5z      �� -   5        $��FIOLabel��5z       $��Nunito)�60   $��Italic$�6D   $��24��6W   $��
ExtraBlack"�6c   #���  6{   $
��Left=�6�   $��14(�6�   �� 5{      -	   5        $��	RoleLabel��5{       $��Nunito)�61   $��Italic$�6E   $��22��6X   $��
ExtraBlack"�6d   #���  6|   $
��Left=�6�   $��12(�6�   5|      5}      �� 5~      $��1��6   $��1��6*   $��1��6;   $��Center=�6K   $��Center=�6f   .+�5        $ Collage=�6"   $	��150��61   $	��150��6=   $��Center=�6J   #���  6g   �� 5�      $��30(�6   $
��Bold"�6*   $#��Выберите раздел��6<   #���  6V   5�       � 5�      -
   5          �Name$ 	MainFrame��5�        � NavigationUIVisibility$ Hidden=�6+   $��0��6K   $��3��6X   $��1��6i   5�      5�      5�      5�      