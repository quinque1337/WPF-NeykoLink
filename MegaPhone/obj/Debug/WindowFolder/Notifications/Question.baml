   M S B A M L   `   `   `  ����D  @MegaPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MegaPhone.WindowFolderMegaPhone.WindowFolder  5   	   3    -MegaPhone.WindowFolder.Notifications.Question   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MegaPhone.WindowFolder     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Notify��5	   	   $	��250��5
   	   $	��550��5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � Icon$" /ImageFolder/Round Graph.png��5   :   .��5      �� $	��550��5   	   $	��250��5   	      DarkBlue#���   5   	   $��2q�5   	     BorderColor#���  5   	    �� CornerRadius$ 18��5   	    J� RenderTransformOrigin$ 0.5,0.5&�5   	   $��Center=�5   	   $��Center=�5   	   ._�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6I   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
HelpCircle=�6   $��70��5      $��70��5         NotifyColor#���  5!      $��0,0,5,0q�6I   �� 5#      -   5        $��NotifyTB��5#   $   $�� ��6   $��Center=�64   $	��450��5$      $
��Wrap=�5%      $��Nunito)�5&      $��18(�5'      $��Italic$�5(      $��	ExtraBold"�5)      #���  5*      5+      �� 5,      $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5-      �� -   5        	 ��Name$	 	YesButton��5-      $
��Да��6,   $��5q�69   $��6��5.      $	��120��5/      $��40��50        	LightBlue#���  51      
�������$��18(�53      $
��Bold"�54      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10��55      6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush# �  56      +  %MaterialDesignThemes.Wpf.RippleAssist   
IsDisabled .   MaterialDesignFlatButton#���  58       � Cursor$
 Hand��59   '   �� 5:      -   5        $	 NoButton��5:      $��Нет��6+   $��5q�69   $��6��5;      $	��120��5<      $��40��5=        
ErrorColor#���  5>      
�������$��18(�5@      $
��Bold"�5A      $
 10��5B      # �  5C       . #���  5E      $
 Hand��5F   &   5H      5I      5J      5K      