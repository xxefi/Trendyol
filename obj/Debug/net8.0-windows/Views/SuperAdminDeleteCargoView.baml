   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      .    (Trendyol.Views.SuperAdminDeleteCargoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � .+�5      �� $��/signup_img.png��6   $��-64,110,978,124q�6-   �� 5      $��/signup_img.png��6   $��1434,114,-574,128q�6-   z�5      �� 5        �� ScaleX$  -1Q�6%   5      �� 5      $��14,-23,-14,23q�6   �� 5      $	��600��5      $��	38,0,22,0q�5      
�������$��Center=�5       �� Padding$ 30q�5      $	��150��5       �� CornerRadius$ 55��5      $	��593��6    J� RenderTransformOrigin$ 0.5,0.5&�6!   z�5      V� 5       .~�5!      ��  �� ScaleY$ 1Q�6)   �� 5"       �� AngleX$ -0.004Q�6(   �� 5#      T� 5$       T� X$ -0.25Q�6-   5%       J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$	 100Q�5)      ._�5+      �� .+�5,      �� $��Удалить заказ��5-   
   	 �� TextAlignment$	 Center=�5.   
   $��20(�5/   
   $
��Bold"�50   
   $��0,0,0,20q�51   
   $	��429��6   � 52      53      54      �� 55      
 �� SelectionMode$
 Single=�58      $��17(�59      $
��Bold"�5:      $	��534��6    $��430,219,402,138q�6,   ��56      �� *Order+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 57      �� *SelectedOrder+$ PropertyChanged=���5;      �� 5<      .R�5=      ]� .+�5>      �� $��1��5?      .+�5@   "   �� $��Имя: ��6(   �� 5A   "   $��Фамилия: ��6(   �� 5B   "   $��FIN: ��6(   �� 5C   "   $)��#Электронная почта: ��6(   �� 5D   "   $��Имя продукта: ��6(   �� 5E   "   $��Дата заказа: ��6(   �� 5F   "   $��Статус: ��6(   5G      �� 5H      $��1��5I      .+�5J   "   �� ��6(   �� *
Users.Name+�� 5K   "   ��6(   �� *Users.Surname+�� 5L   "   ��6(   �� *	Users.FIN+�� 5M   "   ��6(   �� *Users.Email+�� 5N   "   ��6(   �� *	Product+�� 5O   "   ��6(   �� *	Created+�� 5P   "   ��6(   �� *Status+5R      5S      5T      5V      �� 5W      $��0��5X   
   $
��Bold"�5Y   
   .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �   �$��452,167,478,562q�5[   
   $��18(�5\   
   ��5W      �� *Search+$ PropertyChanged=�.��5\      )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5^      �� 5_      $1��+ 🔍 Введите имя товара...��5`      $
��Bold"�5a      $��0,0,0,-5q�5b      .��5c   &   5d      '  !MaterialDesignThemes.Wpf.PackIcon  5e         Kind$ Search=�5f      
�������$��854,178,0,0q�5h      $��28��6&   $��68��62   �� 5i       #  MaterialDesignFlatLightBgButton#��[  5k   
   
���  ��$��16(�5m      
�������$��624,644,596,92q�5o   
   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5p      
���  ��$��2q�5r      ��5j      �� *Delete+.��5s        $ BookmarkRemoveOutline=�5t      $��33��6:   $��42��6F   $��Center=�6Q   $��Center=�6n   5u      5w      �� 5x   
   -   5         ��Name$ BackCommand��5y   ^   $��64��6   $	��Top=�6   #��[  6%   $��522,113,0,0q�6s   $��38��6�   $
��Left=�6�   ���#f27a1a$ 8��6�   
�������
���������6�   �� *Back+.��5z        $��63��5|      $ ArrowBackCircle=�6   $��31��6$   $��Center=�60   5}      5~      5      