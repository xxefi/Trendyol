   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5   	   9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5   	        Trendyol.Views.LoginWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Trendyol.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   2
viewmodels!clr-namespace:Trendyol.ViewModels  5   	     � UseLayoutRounding$
  True��5   	   
���   �$	��768��5      $
��1366��6)   .��5      � $��0,30,0,0q�6   .+�5   
   �� $��/Trendyol.jpg��6   $��-103,-611,-367,-607q�6'    J� Opacity$ 1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   $	��470��5   	   $��	2,0,-14,0q�5      ���#fff$��Center=�5       �� Padding$ 30q�5       $	��150��5!       �� CornerRadius$ 38��5"      $	��393��6    J� RenderTransformOrigin$ 0.5,0.5&�6$   z�5#      V� 5$      .~�5%      ��  �� ScaleY$ 1Q�6%   �� 5&      	 �� AngleX$	 -0.304Q�6$   �� 5'      T� 5(      
 T� X$
 -0.745Q�6)   5)       5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         
BlurRadius$	 100Q�5-      ._�51      �� .+�52      �� $��Вход��53      $��20(�54      $
��Bold"�55      $��0,0,0,20q�56      $��54��6   �� 57      -   5         ��Name$ textBoxLogin��5:      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#f27a1a   TextFieldCornerRadius$ 15��5<      $��0,0,0,0q�5=      
���   ����#fff �� SelectionBrush �#f27a1a �� SelectionTextBrush �#f27a1a �� SelectedText$ #f27a1a��5B      $��16(�5C       !  MaterialDesignOutlinedTextBox#��[  5D      $��57��6L   $	��276��6X   ��59      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�.��5D   d   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5E      �� 5F      $��16(�5G       �� TextAlignment$ Center=�5H      $"��✍ Введите e-mail...��5I      
���   � ! MaterialDesignButtonTextBlock#��[ 5K      $	��210��6L   .��5L   *   5M      � 5N      G� 5O      -   5         G�Name$ passBox��5Q      $��0,5,0,0q�5P       �#f27a1a
���   �$ 15��5T      ���#fff G� SelectionBrush �#f27a1a G� SelectionTextBrush �#f27a1a$��16(�5Y       + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5Z      $��55��6N   $	��276��6Z    5[      �� 5\      $��16(�5]      $ Center=�5^      $(��"✍ Введите пароль...��5_      
���   �#��[ 5a      $	��210��6H   5c      �� 5d      $��22��5e      $	��218��5f      �� 5g      -   5         ��Name$ 
forgotPass��5i      $#��Сбросить пароль��5h      
���   �$��2q�5l       ! MaterialDesignPaperDarkButton#��[ 5m      
���   �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5o      $��39��5p      $��0, 0, 30, 0q�5q      $��Right=�5r      $	��159��5s      ��5j      �� *Forgot+5s      �� 5t      $��или��5v      $��18��6    $ 0.531,0.528&�6,   $��20��6P   �� 5w      -   5        $ guest��5y      $"��Войти как гость��5x      
���   �$��2q�5|      #��[ 5}      
���   �$ 15��5      $��0,0,0,0q�5�      $��34��5�      $	��342��5�      ��5z      �� *Guest+5�      �� 5�      -   5        $ 
AuthButton��5�      $��
Войти��5�      $
��Left=�5�      $��40, -145, 0, 0q�5�      
���   �$��2q�5�      #��[ 5�      
���   �$ 15��5�      $��40��5�      $	��149��5�      {�5�      �� *LoginEnabled+��5�      �� *Login+5�      �� 5�      -   5        $ createAccount��5�      $#��Создать аккаунт��5�      #��[ 5�      ���#f27a1a$��2q�5�      ���#f27a1a$��0,5,0,0q�5�      $ 15��5�      $��35��5�      $	��342��6!    �� 	IsDefault$
 True��6-   ��5�      �� *Create+5�   -   5�      5�      5�      5�      