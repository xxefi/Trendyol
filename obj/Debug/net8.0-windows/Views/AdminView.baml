   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5           Trendyol.Views.AdminWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      8
viewModels!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ���#fff.��5      � .+�5   
   �� $��/ty-web.png��5      $��10,-1,1099,661q�6"   �� 5   
   $��0��5      $��40,124,950,605q�5      $��18(�5      ��5      �� *Search+5      �� 5   
   $��
Найти��5      $��80��5      $��15(�5      $��434,131,852,605q�6   +  %MaterialDesignThemes.Wpf.ButtonAssist    CornerRadius$  12��5      ��5      �� *SearchCommand+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $/��)Добавить товар в склад��5      $	��210��5      $��15(�5       $  12��5!      $��Right=�5"      $	��Top=�5#      $��0,131,225,0q�6%   ��5      �� *
AddOrder+5#   %   �� 5$   
    �� SelectionMode$ Single=�5'      $��17(�5(      $	��455��5)      $	��489��6#   $��40,211,837,102q�6/   ��5%      �� *Order+$ PropertyChanged=� �� SelectedItem 5&      �� *SelectedOrder+$ PropertyChanged=���5*      �� 5+      .R�5,      ]� .+�5-      �� $��1��5.   !   .+�5/      �� $��Имя: ��6$   �� 50      $��Фамилия: ��6$   �� 51      $��FIN: ��6$   �� 52      $)��#Электронная почта: ��6$   �� 53      $��ID продукта: ��6$   �� 54      $��Имя продукта: ��6$   �� 55      $��Дата заказа: ��6$   �� 56      $��Статус: ��6$   57      �� 58      $��1��59   !   .+�5:      �� ��6$   �� *
Users.Name+�� 5;      ��6$   �� *Users.Surname+�� 5<      ��6$   �� *	Users.FIN+�� 5=      ��6$   �� *Users.Email+�� 5>      ��6$   �� *Id+�� 5?      ��6$   �� *	Product+�� 5@      ��6$   �� *	Created+�� 5A      ��6$   �� *Status+$ PropertyChanged=�5C      5D      5E      5G      �� 5I   
   
���  ��
���  ��$��1234,722,29,14q�5N      $  12��5O      ��5K      �� *Exit+.��5P      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�5Q      $��30��6"   $��73��6.   $��Center=�69   5R      	� 5T   
   -   5         	�Name$ OrderPlaced��5U      $��Заказ сделан��5X      $��18(�5Y      $��40,722,1174,10q�5[      ��5V      �� *Check+$ PropertyChanged=� d� 	IsChecked 5W      �� *RadioButton.OrderPlaced+$ PropertyChanged=�5[      	� 5]   
   -   5        $ ArrivedAtTheWarehouse��5^      $'��!Поступил на склад ��5a      $��18(�5c   	   $��197,722,987,10q�5d   	   ��5_      �� *Check+$ PropertyChanged=� 5`      �� *#!RadioButton.ArrivedAtTheWarehouse+$ PropertyChanged=�5d   	   	� 5f   
   -   5        $
 Sent��5g      $��Отправлен��5k   	   $��18(�5l   	   $��394,722,852,10q�5m   	   ��5h      �� *Check+$ PropertyChanged=� 5i      �� *RadioButton.Sent+$ PropertyChanged=�5m   	   	� 5o   
   -   5        $ SmartCustomsCheck��5p      $0��*На таможенной проверке��5t   	   $��18(�5u   	   $��519,722,602,10q�5v   	   ��5q      �� *Check+$ PropertyChanged=� 5r      �� *RadioButton.SmartCustomsCheck+$ PropertyChanged=�5v   	   	� 5x   
   -   5        $ InFilial��5y      $��На почте��5}   
   $��18(�5~   
   $��769,722,494,10q�5   
   ��5z      �� *Check+$ PropertyChanged=� 5{      �� *RadioButton.InFilial+$ PropertyChanged=�5   
   �� 5�   
   $��Admin Panel��5�      $
��Bold"�5�      $��80(�5�      $��434,0,434,667q�6   
���   �5�      �� 5�   
   $1��+Удалить товар из склада��5�      $	��210��5�      $��15(�5�      $  12��5�      $��Right=�5�      $	��Top=�5�      $��	0,131,0,0q�6%   ��5�      �� *RemoveOrder+5�   %   5�      5�      