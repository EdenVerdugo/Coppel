   M S B A M L   `   `   `  ����C  ?P03Hanoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:P03HanoiP03Hanoi  5   	       P03Hanoi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:P03Hanoi     5   	   -   5        $��Window��5   	     � Title$  
MainWindow��5   	   $	��580��5	   	   $	��720��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��60 �6   .+�5   
   �� $��0��6   $��20q�5      
���   �$��2q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      � $	��210��6   .+�5      �� 
���   �$��5��5      $
��0,05q�5       K� ZIndex$ 0��5       �� 5#      -   5        $��Torre1��5$   !   $��Bottom=�5#   !   5(      5*      � 5,      $	��210��6   .+�5-      �� 
���   �$��5��5/      $
��0,05q�50      $ 0��51      �� 54      -   5        $��Torre2��55   !   $��Bottom=�54   !   58      5:      � 5=      $	��210��6   .+�5>      �� 
���   �$��5��5@      $
��0,05q�5A      $ 0��5B      �� 5E      -   5        $��Torre3��5F   !   $��Bottom=�5E   !   5I      5K      5L      5O      �� 5Q   
   $��1��6   $ Vertical=�5R      $��Center=�5S      .+�5U      �� $ 
Horizontal=�6   .+�5V      �� $��Discos :��6   $��90��5W       �� TextAlignment$ Right=�5X      $��5q�5Y      $��Center=�5Z      �� 5\      -   5        $��
DiscosText��5\      $��80��5]      $��Center=�5^      $��5q�5_      �� 5b      -   5        $��InicializarButton��5b      $��Inicializar��5c      $��Center=�5e      $	��100��5f      5h      �� 5j      $ 
Horizontal=�6   .+�5k      �� $��Movimientos :��6   $��90��5l      $ Right=�5m      $��5q�5n      $��Center=�5o      �� 5q      -   5        $��MovimientosText��5q      $��80��5r      $��Center=�5s      $��5q�5t       �� 
IsReadOnly . 5u      �� 5x      -   5        $��ResolverButton��5x      $��Resolver��5y      $��Center=�5{      $	��100��5|      5~      5�      �� 5�   
   -	   5        $��NumMovimientoText��5�      $��1��5�      $��Right=�5�      $��Center=�5�      $
��20,0q�5�      $��30(�5�      $
��Bold"�5�      $��0��5�      5�      5�      