   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      %    Trendyol.Views.HistoryOrderView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�6(     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   �� 5   
   $	��600��5      $��	2,0,-14,0q�5      
�������$��Center=�5       �� Padding$ 30q�5       $	��150��5!       �� CornerRadius$ 50��5"      $	��458��6    J� RenderTransformOrigin$ 0.5,0.5&�6$   z�5$      V� 5%      .~�5&      ��  �� ScaleY$ 1Q�6%   �� 5'       �� AngleX$ -0.004Q�6$   �� 5(      T� 5)      	 T� X$	 -0.25Q�6)   5*       5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-      
   
BlurRadius$	
 100Q�5.   	   ._�50      �� .+�51      �� 
���   �$#��История заказов��53       �� TextAlignment$ Center=�54      $��20(�55      $
��Bold"�56      $��0,0,0,20q�57      $	��236��6   � 58      5;      5=      �� 5>   
   -   5         ��Name$ BackCommand��5?   	   ���#f27a1a #  MaterialDesignFlatLightBgButton#��[  5B   	   
�������
�������$
��Left=�5E   	   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5F   	   $	��Top=�5G   	   $��38��6!   $��64��6-   $��526,180,0,0q�68   ��5@   	   �� *Back+.��5H      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5I      $��31��6$   $��63��60   $��Center=�6;   5J      �� 5L   
   $,��&           Посмотреть чек��5N      $��592,571,592,165q�5O      $ 15��5P      ��5M      �� *
Document+5P        5R   
   $
 File=�5S   	   
�������$��32��5U      $��56��6   $��601,571,0,0q�6$   �� 5W   
    �� SelectionMode$ Single=�5Z      $��17(�5[      $
��Bold"�5\      
���   �$	��336��5^      $	��489��6   $��457,223,420,209q�6$   ��5X      �� *Order+ �� SelectedItem 5Y      �� *SelectedOrder+��5_      �� 5`      .R�5a      ]� .+�5b      �� $��1��5c      .+�5d      �� $��ID заказа: ��6$   �� 5e      $��TrackingID: ��6$   �� 5f      $��Количество: ��6$   �� 5g      $��Имя товара: ��6$   �� 5h      $��Дата заказа: ��6$   �� 5i      $!��Статус заказа: ��6$   5j      �� 5k      $��1��5l      .+�5m      �� ��6$   �� *Id+�� 5n      ��6$   �� *
TrackingId+�� 5o      ��6$   �� *ProductsCount+�� 5p      ��6$   �� *	Product+�� 5q      ��6$   �� *	Created+�� 5r      ��6$   �� *Status+5t      5u      5v      5x      5y      5z      