   M S B A M L   `   `   `  ����K  GWpfProjectCinema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfProjectCinema.ViewsWpfProjectCinema.Views  5      )    #WpfProjectCinema.Views.ThirdProfile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:WpfProjectCinema.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ���	#FF333334.��5      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5        
 J� Uid$ 0��5      $��0��5      $��5q�5      ���	#FF403B3B
���   �$#��Таблица фильмов��5      
�������5       �� 5!      -   5        $ 1��5"      $��1��5#      $��5q�5$      ���	#FF403B3B
���   �$+��%Таблица кинотеатров��5(      
�������5)      �� 5*      -   5        $ 2��5+      $��2��5,      $��5q�5-      ���	#FF403B3B
���   �$��Таблица залов��51      
�������52      �� 53      -   5        $ 3��54      $��3��55      $��5q�56      ���	#FF403B3B
���   �$#��Таблица сеансов��5:      
�������5;      5<      &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dataGrid��5>      $��1��5?      $��Center=�5@         AutoGenerateColumns . 
���   �
���   ���5B      Z� 5E      5F      5G      