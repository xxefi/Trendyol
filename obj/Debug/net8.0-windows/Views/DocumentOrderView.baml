   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      &     Trendyol.Views.DocumentOrderView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   �� $��/Trendyol2.jpg��6   $��-44,-250,-14,-248q�6(     J� Opacity$  1Q�5       J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   $��/signup_img.png��6   $��-64,110,978,124q�6)   �� 5   
   $��/signup_img.png��6   $��1434,114,-574,128q�6)   z�5      �� 5       �� ScaleX$ -1Q�6!   5      �� 5   
   �� 5   
   $	��375��5      $��	2,0,-14,0q�5      ���#fff$��Center=�5!       �� Padding$ 30q�5"      $	��150��5#       �� CornerRadius$ 50��5$      $	��458��6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5&      V� 5'      .~�5(      ��  �� ScaleY$ 1Q�6%   �� 5)       �� AngleX$ -0.004Q�6$   �� 5*      T� 5+      	 T� X$	 -0.25Q�6)   5,       5.      3  -System.Windows.Media.Effects.DropShadowEffect  5/      
   
BlurRadius$	
 100Q�50      ._�52      �� .+�53      �� $��Чек��54   
    �� TextAlignment$ Center=�55      $��20(�56   
   $
��Bold"�57   
   $��0,0,0,20q�58   
   $��56��6   � 59      5<      5>      �� 5@   
   -   5         ��Name$ BackCommand��5A      ���#f27a1a #  MaterialDesignFlatLightBgButton#��[  5D      
�������
�������$
��Left=�5G      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5H      $	��Top=�5I      $��38��6   $��64��6*   $��604,180,0,0q�65   ��5B      �� *Back+.��5J      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5K   
   $��31��6!   $��63��6-   $��Center=�68   5L        5N   
   $
 File=�5O      
�������$��32��5Q   
   $��56��6   $��601,571,0,0q�6!   �� 5R   
   $��/M10.jpg��5S      $��337,218,328,165q�6   �� 5U   
   $��24(�5V      $ Center=�5W      $
��Bold"�5X      
�������$��566,249,566,490q�5Z      �� 5[      �6
   �� *SelectedProduct.Price+ �� 5\      $	�₼��6
   5]      �� 5^   
   $
��Bold"�5`      $ Center=�5a      $��18(�5b      
�������$��590,286,580,460q�5d      ��5_      �� *Orders.Created+5d      �� 5f   
   $��Магазин��5g      $ Right=�5h      $
��Bold"�5i      $��18(�5j      
�������$��692,311,543,428q�5l      �� 5n   
   $��NURLU KARGO MMC��5o   	   $ Right=�5p   	   $
��Bold"�5q   	   $��17(�5r   	   
�������$��683,341,500,385q�5t   	   �� 5v   
   $ Center=�5x   	   $
��Bold"�5y   	   $��17(�5z   	   
�������$��662,388,518,354q�5|   	   ��5w   	   �� *SelectedOrder.UserId+5|   	   �� 5~   
   $ Right=�5�   	   $
��Bold"�5�   	   $��17(�5�   	   
�������$��708,414,518,328q�5�   	   ��5   	   �� *SelectedProducts.Category+5�   	   �� 5�   
   $ Right=�5�   	   $
��Bold"�5�   	   $��17(�5�   	   
�������$��668,445,535,282q�5�   	   ��5�   	   �� *SelectedOrder.TrackingId+5�   	   5�      5�      