   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Trendyol.CustomMessageBoxTrendyol.CustomMessageBox  5   	   )    #Trendyol.CustomMessageBox.ErrorView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Trendyol.CustomMessageBox     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������$��Regular"�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5       � 
ResizeMode$ NoResize=�5   	    � Topmost$
 True��5   	    � WindowStyle$
 None=�5   	   $��	Open Sans)�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Ошибка��5   	   $	��150��6   $	��300��5   	   ��5	   	   Z� ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � ��	 �� Value	 5      �� 5      
 �� 
TargetType"
 �6&   .R�5      �� 
������� �� CornerRadius$ 40��65   ._�5      �� .u�5   "   �� 5      5      5      5!      5"      .��5$      �� $ 25��6   
������� J� Effect 5&   
   3  -System.Windows.Media.Effects.DropShadowEffect  5'         ShadowDepth$ 0Q�6      Color$ Black��6/      Opacity$
 0.25Q�6=   ._�5*   
   � ��6   Z�  � RowDefinitions 5+      �� 5,      $	��20* �6    �� 5-      $	��60* �6    �� 5.      $	��20* �6     � 	Resources 50      ��%�   '��       �� 51      " ��6   .�52      ��  � ��
	 �����63   �� 53       � ��
	 �����64   �� 54       � ��$	 16(�61   �� 55       � ��
	 ��� �63   �� 56       � ��	 60   �� *ChangeUserDateTime+57      58      .+�59      � $��0��6)   ��6   Z�  � ColumnDefinitions 5:      �� 5;      $	��20* �6'   �� 5<      $	��80* �6'   .+�5>      �� -   5        $��txtTitle��5>      $��Ошибка��6,   
���iii�$��Center=�6O   $��20(�6j   $
��Bold"�6x   $��2��6�   $��	10,0,50,0q�6�   5?      � 5@      $��1��6)   ��6   Z�  5A      �� 5B      $	��30* �6'   �� 5C      $	��70* �6'   .+�5E      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��msgLogo��5E         Kind$ Error=�6-   $��0��6:   $��Center=�6J   $��Center=�6e   $��50��6�   $��50��6�   
���  ��6�   �� 5F      -   5        $��
txtMessage��5F      $��1��6.   $9��3Неправильный e-mail или пароль��6>   
���iii�$��14(�6y   $��Center=�6�   $
��Left=�6�   $
��Wrap=�6�   5G      � 5H      $��1��6)   $��0,83,0,0q�66   $��2��6H   ��6   Z�  5I      �� 5J      $	��20* �6'   �� 5K      $	��40* �6'   �� 5L      $	��40* �6'   �� 5M      $	��20* �6'   .+�5O      �� -   5        $��btnOk��5O      $��1��6&   $��OK��66   $��Center=�6D   $��Center=�6a   $��80��6|   
����������	#FF698EF1$��30��6�   $��2��6�   ��6�   Z� 6�   5R      5S      5T      5U      