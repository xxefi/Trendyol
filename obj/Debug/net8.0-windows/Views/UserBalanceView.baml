   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      $    Trendyol.Views.UserBalanceView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � .+�5      � .+�5      �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�60     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6%   5      �� 5      $��/signup_img.png��6   $��-64,110,978,124q�61   �� 5      $��/signup_img.png��6   $��1434,114,-574,128q�61   z�5      �� 5       �� ScaleX$ -1Q�6)   5      �� 5      �� 5      $	��500��5      $��	2,0,-14,0q�5      
�������$��Center=�5!       �� Padding$ 30q�5"      $	��150��5#       �� CornerRadius$ 50��5$      $	��216��6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5&      V� 5'      .~�5(      ��  �� ScaleY$ 1Q�6-   �� 5)       �� AngleX$ -0.004Q�6,   �� 5*      T� 5+      	 T� X$	 -0.25Q�61   5,       5.      3  -System.Windows.Media.Effects.DropShadowEffect  5/      
   
BlurRadius$	
 100Q�50      ._�52      �� .+�53      �� $��Баланс��54   
   
���   � �� TextAlignment$ Center=�56   
   $��20(�57   
   $
��Bold"�58   
   $��0,0,0,20q�59   
   $��77��6   � 5:      �� 5;      $%��Пополнить баланс��5=   
    !  MaterialDesignPaperDarkButton#��[  5>   
   $��16(�5?      ���#f27a1a$��0,70,-10,20q�5A   
   $��39��6   $	��401��6+   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5B      ���#f27a1a$��2q�5D      ��5<      �� *Pay+5D      5F      5H      �� 5I      $��/Wallet.png��5J      $��593,332,694,356q�6*   �� 5K      $��24(�5L      $��683,356,443,385q�5M      �� 5N      
���   ��6   �� *	Balance+5O       �� 5P      $	�₼��6   
���   �5Q      5R      5S      �� 5U      -   5         ��Name$ BackCommand��5X      $��64��5V      $	��Top=�6    # MaterialDesignFlatLightBgButton#��[ 5W      $��592,300,0,0q�5Y      $��38��5Z      $
��Left=�5[      ���#f27a1a$ 8��5]      
�������
���������5^      �� *Back+.��5a      '  !MaterialDesignThemes.Wpf.PackIcon  $��63��5b         Kind$ ArrowBackCircle=�6   $��31��63   $��Center=�6?   5c      5d      5e      5f      