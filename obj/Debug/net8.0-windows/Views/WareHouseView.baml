   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      "    Trendyol.Views.WareHouseView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      8
viewModels!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�6(     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   �� 5   
   $	��650��5      $��	2,0,-14,0q�5      ���#fff$��Center=�5       �� Padding$ 30q�5       $	��150��5!       �� CornerRadius$ 50��5"      $	��704��6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5$      V� 5%      .~�5&      ��  �� ScaleY$ 1Q�6%   �� 5'       �� AngleX$ -0.004Q�6$   �� 5(      T� 5)      	 T� X$	 -0.25Q�6)   5*       5,      3  -System.Windows.Media.Effects.DropShadowEffect  5-      
   
BlurRadius$	
 100Q�5.      ._�50      �� .+�51      �� $��Купить товар��52   
    �� TextAlignment$ Center=�53      $��20(�54   
   $
��Bold"�55   
   $��0,0,0,20q�56   
   $	��135��6   � 57      5:      5<      �� 5=   
   -   5         ��Name$ BackCommand��5>      ���#f27a1a #  MaterialDesignFlatLightBgButton#��[  5A      
�������
�������$
��Left=�5D      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5E      $	��Top=�5F      $��38��6   $��64��6*   $��
548,58,0,0q�65   ��5?      �� *Back+.��5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5H   
   $��31��6!   $��63��6-   $��Center=�68   5I      �� 5J   
   $��428,114,-23,73q�6   .��5K      �� $��1��6   0  *MaterialDesignThemes.Wpf.ListBoxItemAssist   CornerRadius$ 30��5L       �� SelectionMode$ Single=�5O      $��17(�5P      $
��Bold"�5Q      $��	0,0,390,0q�5R      $	��563��5S      $	��552��6   ��5M      �� *ProductsForOrders+ �� SelectedItem 5N      �� *SelectedProductsForOrders+��5T      �� 5U      .R�5V      ]� .+�5W      �� $��1��5X      .+�5Y   "   �� $��ID товара: ��6(   �� 5Z   "   $��Имя товара: ��6(   �� 5[   "   $%��Описание товара: ��6(   �� 5\   "   $'��!Категория товара: ��6(   �� 5]   "   $)��#Количество товара: ��6(   �� 5^   "   $��Цена товара: ��6(   �� 5_   "   $��Фото товара: ��6(   5a      �� 5b      $��1��5c   !   .+�5d   "   �� ��6(   �� *Id+�� 5e   "   ��6(   �� *Name+�� 5f   "   ��6(   �� *Description+�� 5g   "   ��6(   �� *
Category+�� 5h   "   ��6(   �� *Count+�� 5i   "   .��5j   &   �� �� 5k   &   �6*   �� *Price+ �� 5l   &   $	�AZN��6*   5m   '   5n   #   �� 5p   "   $	��100��5q   %   $	��100��5r   %   ��5s   %   �� *Image+5u      5v      5w      5y      5z      �� 5{   
   $��Купить��5|      $��Right=�5}      ���#f27a1a���#f27a1a
�������$ 10��5�      #��[  5�      $��620,695,620,41q�6F   ��5~      �� *Buy+5�        5�   
   $ MarketplaceOutline=�5�   	   
�������$��28��5�      $��32��6   $��648,697,0,0q�6$   5�      5�      