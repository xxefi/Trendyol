   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      (    "Trendyol.Views.RemoveAccountWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      1	viewModel!clr-namespace:Trendyol.ViewModels  5      .��5      � .+�5   
   �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�6(     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   $	��450��5      $��
21,0,-33,0q�5      
�������$��Center=�5       �� Padding$ 30q�5      $	��150��5       �� CornerRadius$ 40��5       $	��344��6    J� RenderTransformOrigin$ 0.5,0.5&�6    z�5!      V� 5"      .~�5#      ��  �� ScaleY$ 1Q�6%   �� 5$       �� AngleX$ -0.304Q�6$   �� 5%      T� 5&      	 T� X$	 -0.745Q�6)   5'       5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*      
   
BlurRadius$	
 100Q�5+      ._�5/      �� .+�51      �� $#��Удалить аккаунт��52   	   
���   �$��20(�54   	   $
��Bold"�55   	   $��0,0,0,20q�56   	   $	��162��6   �� 57      -   5         ��Name$ textBoxLogin��5;   	   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#f27a1a �� TextAlignment$ Center=�59      
�������
���   ����#f27a1a �� SelectionBrush �#f27a1a �� SelectionTextBrush �#f27a1a$��16(�5A       !  MaterialDesignOutlinedTextBox#��[  5B   	   $��56��6@   $	��276��6L   ��5:      �� *FIN+.��5B   X   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5C      �� 5D      
���   �$��16(�5F      $(��"✍ Введите свой FIN...��5G       ! MaterialDesignButtonTextBlock#��[ 5H      $	��250��6H   .��5I   *   5J      � 5K      �� 5L      -   5        $ passBox��5Q   	   $��0,5,0,0q�5M       �#f27a1a$ Center=�5P      
���   �
����������#f27a1a �#f27a1a �#f27a1a$��16(�5W      #��[  5X   	   $��56��6@   $	��276��6L   ��5O      �� *Phone+.��5X   X    5Y      �� 5Z      
���   �$��16(�5\      $7��1✍ Введите номер телефона...��5]      #��[ 5^      $	��250��6D   .��5_   *   5`      �� 5a      -   5        $ passwordBox��5e      $��0,5,0,0q�5b       �#f27a1a
���   �
����������#f27a1a �#f27a1a �#f27a1a$ Center=�5k      $��16(�5l      #��[  5m      $��55��6H   $	��276��6T   ��5d      �� *
Password+.��5m   `    5n      �� 5o      
���   �$��16(�5q      $7��1✍ Введите текущий пароль...��5r      #��[ 5s      $	��250��6L   .��5t   *   5u      �� 5v      -   5         ��Name$ deleteButton��5x      $#��Удалить аккаунт��5w      
���  ��
�������$��2q�5|       ! MaterialDesignPaperDarkButton#��[ 5}      
���  ��$��	0,20,0,20q�5      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5�      $��35��5�      $	��336��5�      ��5y      �� *Delete+5�      �� 5�      $��22��5�      $	��218��5�      5�      5�      �� 5�   
   -   5        $
 back��5�      ���#f27a1a$��60��5�      $
��Left=�5�       # MaterialDesignFlatLightBgButton#��[ 5�      
�������
�������$ 10��5�      $��567,241,0,495q�6'   ��5�      �� *Back+.��5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��72��5�   	   $��29��5�   	      Kind$ ArrowBackCircle=�5�   	   $��Center=�6    $��Center=�6=   5�      5�      5�      