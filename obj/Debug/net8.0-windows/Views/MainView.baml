   M S B A M L   `   `   `  ����C  ?Trendyol, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trendyol.ViewsTrendyol.Views  5   	   9!clr-namespace:Trendyol.ViewModelsTrendyol.ViewModels  5   	       Trendyol.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Trendyol.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   2
viewmodels!clr-namespace:Trendyol.ViewModels  5   	   Kshell9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5	      -   5          � WindowStyle$
  None=�5   	    � 
ResizeMode$ CanMinimize=�5   	    � AllowsTransparency$
 True��5   	    � Title$ Trendyol��5      $	��768��6   $
��1366��6#   .��5      ��  �� CornerRadius$ 40��5      ._�5   
   � .+�5      �� $��1��6   ��6-   �� *CurrentView+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      -   5        $
��Quit��5      
������� #  MaterialDesignFlatLightBgButton#��[  5   	   $
��Left=�5      
������ 
������ +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5"      $	��Top=�5#      $��28��6   $��52��6*   $��
1316,0,0,0q�65   ��5      �� *Quit+.��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�5%   	   $��25��6   $��34��6"   $��Center=�6-   $��Center=�6H   5&      �� 5(      -   5        $��Minimize��5)      
�������#��[  5+      $
��Left=�5,      
������ 
������ $ 10��5/      $	��Top=�50      $��28��6   $��47��6%   $��
1290,0,0,0q�60   .��51        $ Minimize=�52      $��25��6   $��34��6    $��Center=�6+   $��Center=�6F   53      54      55      56      