   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      .    (Trendyol.Views.SuperAdminDeleteAdminView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� $��
/Admin.jpg��6   $��-61,-248,-60,-139q�6$     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 50Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   �� 5   
   $	��500��5   	   $��	2,0,-14,0q�5   	   ���#fff$��Center=�5    	    �� Padding$ 30q�5!   	   $	��150��5"   	    �� CornerRadius$ 50��5#   	   $	��458��6    J� RenderTransformOrigin$ 0.5,0.5&�6(   z�5%      V� 5&      .~�5'      ��  �� ScaleY$ 1Q�6%   �� 5(       �� AngleX$ -0.004Q�6$   �� 5)      T� 5*      	 T� X$	 -0.25Q�6)   5+       5-      3  -System.Windows.Media.Effects.DropShadowEffect  5.      
   
BlurRadius$	
 100Q�5/      ._�51      �� .+�52      �� $#��Удаление админа��53       �� TextAlignment$ Center=�54      $��20(�55      $
��Bold"�56      $��0,0,0,20q�57      $	��236��6#   � 58      5;      5=      �� 5>   
   -   5         ��Name$ BackCommand��5?      ���#f27a1a #  MaterialDesignFlatLightBgButton#��[  5B      
�������
�������$
��Left=�5E      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5F      $	��Top=�5G      $��38��6%   $��64��61   $��526,180,0,0q�6<   ��5@      �� *Back+.��5H      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5I      $��31��6(   $��63��64   $��Center=�6?   5J      �� 5K   
   $��492,237,438,184q�6   .��5L      �� $��1��6    �� SelectionMode$ Single=�5O      $��17(�5P      $
��Bold"�5Q      $	��336��5R      $	��417��6   ��5M      �� *Admin+ �� SelectedItem 5N      �� *SelectedAdmin+��5S      �� 5T      .R�5U      ]� .+�5V      �� $��1��5W   !   .+�5X   "   �� $��Админ ID: ��6(   �� 5Y   "   $��Логин: ��6(   5Z      �� 5[      $��0��5\      .+�5]   "   �� ��6(   �� *	AdminId+�� 5^   "   ��6(   �� *Name+5_      5`      5a      5c      5d      �� 5e   
   $��68��5g      
���  ��
���  ��
�������$
��Left=�5k      $ 15��5l      $��834,183,0,553q�5m      #��[  5n      ��5f      �� *DeleteAdmin+.��5o        $��35��5p   	   $��24��5q   	   $ Delete=�5r   	   $��Center=�6   5s      5t      5u      