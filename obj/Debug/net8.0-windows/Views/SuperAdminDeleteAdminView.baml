   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      .    (Trendyol.Views.SuperAdminDeleteAdminView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5        �� ScaleX$  -1Q�6!   5      �� 5   
   �� 5   
   $	��500��5   	   $��	2,0,-14,0q�5   	   ���#fff$��Center=�5   	    �� Padding$ 30q�5   	   $	��150��5   	    �� CornerRadius$ 50��5   	   $	��458��6    J� RenderTransformOrigin$ 0.5,0.5&�6(   z�5      V� 5      .~�5       ��  �� ScaleY$ 1Q�6%   �� 5!       �� AngleX$ -0.004Q�6$   �� 5"      T� 5#       T� X$ -0.25Q�6)   5$       J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         
BlurRadius$	 100Q�5(      ._�5*      �� .+�5+      �� $#��Удаление админа��5,      	 �� TextAlignment$	 Center=�5-      $��20(�5.      $
��Bold"�5/      $��0,0,0,20q�50      $	��236��6#   � 51      54      56      �� 57   
   -   5        
 ��Name$
 BackCommand��58      ���#f27a1a #  MaterialDesignFlatLightBgButton#��[  5;      
�������
�������$
��Left=�5>      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5?      $	��Top=�5@      $��38��6%   $��64��61   $��526,180,0,0q�6<   ��59      �� *Back+.��5A      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5B      $��31��6(   $��63��64   $��Center=�6?   5C      �� 5D   
   $��492,237,438,184q�6   .��5E      �� $��1��6    �� SelectionMode$ Single=�5H      $��17(�5I      $
��Bold"�5J      $	��336��5K      $	��417��6   ��5F      �� *Admin+ �� SelectedItem 5G      �� *SelectedAdmin+��5L      �� 5M      .R�5N      ]� .+�5O      �� $��1��5P   !   .+�5Q   "   �� $��Админ ID: ��6(   �� 5R   "   $��Логин: ��6(   5S      �� 5T      $��0��5U      .+�5V   "   �� ��6(   �� *	AdminId+�� 5W   "   ��6(   �� *Name+5X      5Y      5Z      5\      5]      �� 5^   
   $��68��5`      
���  ��
���  ��
�������$
��Left=�5d      $ 15��5e      $��834,183,0,553q�5f      #��[  5g      ��5_      �� *DeleteAdmin+.��5h        $��35��5i   	   $��24��5j   	   $ Delete=�5k   	   $��Center=�6   5l      5m      5n      