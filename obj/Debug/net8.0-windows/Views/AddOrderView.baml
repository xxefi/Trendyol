   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5      9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5      !    Trendyol.Views.AddOrderView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Trendyol.Views     5      7	viewModel!clr-namespace:Trendyol.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � .+�5      �� $��/signup_img.png��6   $��-64,110,978,124q�6-   �� 5      $��/signup_img.png��6   $��1434,114,-574,128q�6-   z�5      �� 5        �� ScaleX$  -1Q�6%   5      �� 5      �� 5      $	��570��5      $��	2,0,-14,0q�5      ���#fff$��Center=�5       �� Padding$ 30q�5      $	��150��5       �� CornerRadius$ 50��5      $	��516��6    J� RenderTransformOrigin$ 0.5,0.5&�6$   z�5!      V� 5"      .~�5#      ��  �� ScaleY$ 1Q�6)   �� 5$       �� AngleX$ -0.004Q�6(   �� 5%      T� 5&       T� X$ -0.25Q�6-   5'       J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$	 100Q�5+   	   ._�5-      �� .+�5.      �� $5��/Добавление товара в склад��5/      	 �� TextAlignment$	 Center=�50      $��20(�51      $
��Bold"�52      $��0,0,0,20q�53      $	��316��6   � 54      �� 55      -   5        
 ��Name$
 nameProduct��5:      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush �#f27a1a �� TextAlignment$ Center=�58      
���   �$��16(�5<      ���#f27a1a �� SelectionBrush �#f27a1a �� SelectionTextBrush �#f27a1a !  MaterialDesignOutlinedTextBox#��[  5@      $	��286��69   $��55��6E   ��59      �� *Name+.��5@   Q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5A      �� 5B      
���   � ! MaterialDesignButtonTextBlock#��[ 5D      $��16(�5E      $=��7✍ Введите название продукта...��5F      $	 Center=�5G      .��5H   .   5I      �� 5J      -   5        $
 lastNameBoxLogin��5O      $��0,5,0,0q�5K       �#f27a1a$ Center=�5M      
���   �$��16(�5Q      ���#f27a1a �#f27a1a �#f27a1a#��[  5U      $	��286��69   $��56��6E   ��5N      �� *Description+.��5U   Q    5V      �� 5W      #��[ 5X      $	��250��6M   
���   �$��16(�5Z      $,��&✍ Введите описания...��5[      $	 Center=�5\      .��5]   .   5_      �� 5`      -   5        $
 Count��5e   
   $��0,5,0,0q�5a       �#f27a1a$ Center=�5c   
   
���   �$��16(�5g   
   ���#f27a1a �#f27a1a �#f27a1a#��[  5k   
   $	��286��6A   $��56��6M   ��5d   
   �� *Count+.��5k   Y    5l      �� 5m      #��[ 5n      $	��250��6M   
���   �$��16(�5p      $0��*✍ Введите количество...��5q      $	 Center=�5r      .��5s   .   5u      �� 5v      -   5        $
 textBoxLogin��5z      $��0,5,0,0q�5w       �#f27a1a���#f27a1a �#f27a1a �#f27a1a$ Center=�5~      
���   �$��16(�5�      #��[  5�      $	��286��69   $��56��6E   ��5y      �� *Price+.��5�   Q    5�      �� 5�      #��[ 5�      $	��250��6M   
���   �$��16(�5�      $$��✍ Введите цену...��5�      $	 Center=�5�      .��5�   .   5�      �� 5�      $��0,5,0,0q�5�      $0��*✍ Выберите категорию...��5�      $��16(�5�      $	 Center=�5�      �� 5�      $��0,5,0,0q�5�       �#f27a1a
���   �$��16(�5�      ���#f27a1a$	��284��5�      $��37��6   ��5�      �� *
Category+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5�      �� *SelectedCategory+$ PropertyChanged=���5�      �� 5�      .R�5�   "   �� ��6,   �� 5�      5�      �� 5�      $��Выбрать фото��5�       # MaterialDesignFlatLightBgButton#��[ 5�      ���#f27a1a$��16(�5�      
�������$��
0,10,-10,0q�5�      $��39��5�      $	��401��5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5�      ���#f27a1a$��2q�5�      {�5�      �� *EnabledImage+��5�      �� *Image+5�      �� 5�      -   5        $��selectedImage��5�      $��98��5�      $	��205��5�      $��0,-300,-410,0q�5�      ��5�      �� *
ImageBox+5�      �� 5�      $!��Добавить товар��5�      #��[ 5�      ���#f27a1a$��16(�5�      
�������$��0, 10,-10,10q�5�      $��39��6#   $	��401��6/   $ 10��5�      ���#f27a1a$��2q�5�      {�5�      �� *
EnabledAdd+��5�      �� *Add+5�      5�      5�      5�      �� 5�   
   -   5        $��BackCommand��5�      ���#f27a1a#��[ 5�      
�������
�������$
��Left=�5�      $ 8��5�      $	��Top=�5�      $��38��6   $��64��6%   $��490,150,0,0q�60   ��5�      �� *Back+.��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowBackCircle=�5�      $��31��6   $��63��6'   $��Center=�62   5�      5�      5�      