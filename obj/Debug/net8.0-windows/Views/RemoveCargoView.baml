   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      $    Trendyol.Views.RemoveCargoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � .+�5      �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�6,     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6!   5      �� 5      $��/signup_img.png��6   $��-64,110,978,124q�6-   �� 5      $��/signup_img.png��6   $��1434,114,-574,128q�6-   z�5      �� 5       �� ScaleX$ -1Q�6%   5      �� 5      $��14,-23,-14,23q�6   �� 5      $	��600��5      $��	38,0,22,0q�5      ���#fff$��Center=�5        �� Padding$ 30q�5!      $	��150��5"       �� CornerRadius$ 50��5#      $	��410��6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5%      V� 5&      .~�5'      ��  �� ScaleY$ 1Q�6)   �� 5(       �� AngleX$ -0.004Q�6(   �� 5)      T� 5*      	 T� X$	 -0.25Q�6-   5+       5-      3  -System.Windows.Media.Effects.DropShadowEffect  5.      
   
BlurRadius$	
 100Q�5/      ._�51      �� .+�52      �� $!��Отменить заказ��53   
    �� TextAlignment$ Center=�54   
   $��20(�55   
   $
��Bold"�56   
   $��0,0,0,20q�57   
   $	��429��6   � 58      59      5:      �� 5;       �� SelectionMode$ Single=�5>      $��17(�5?      $
��Bold"�5@      $	��300��5A      $	��534��6   $��430,254,402,214q�6'   ��5<      �� *Order+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5=      �� *SelectedOrder+$ PropertyChanged=���5B      �� 5C      .R�5D      ]� .+�5E      �� $��1��5F      .+�5G   "   �� $��ID заказа: ��6(   �� 5H   "   $��TrackingID: ��6(   �� 5I   "   $��Количество: ��6(   �� 5J   "   $��Имя товара: ��6(   �� 5K   "   $��Дата заказа: ��6(   �� 5L   "   $!��Статус заказа: ��6(   5M      �� 5N      $��1��5O   !   .+�5P   "   �� ��6(   �� *Id+�� 5Q   "   ��6(   �� *
TrackingId+�� 5R   "   ��6(   �� *ProductsCount+�� 5S   "   ��6(   �� *	Product+�� 5T   "   ��6(   �� *	Created+�� 5U   "   ��6(   �� *Status+5W      5X      5Y      5[      �� 5\      $��         Отменить��5]       #  MaterialDesignFlatLightBgButton#��[  5_   
   
���  ��$��16(�5a      
�������$��624,554,596,182q�5c   
   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5d      
���  ��$��2q�5f      ��5^      �� *Gancel+5h      '  !MaterialDesignThemes.Wpf.PackIcon  5j         Kind$ Cancel=�5k      
�������$��24��5m      $��34��5n      $��644,558,0,0q�6   5o      �� 5p   
   -   5         ��Name$ BackCommand��5q   ^   $��64��6   $	��Top=�6   #��[  6%   $��522,205,0,0q�6s   $��38��6�   $
��Left=�6�   ���#f27a1a$ 8��6�   
�������
���������6�   �� *Back+.��5r        $��63��5s      $ ArrowBackCircle=�6   $��31��6$   $��Center=�60   5t      5u      5v      