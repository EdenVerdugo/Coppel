   M S B A M L   `   `   `  ����A  =P05ABC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:P05ABCP05ABC  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	       P05ABC.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:P05ABC     5   	   H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=null8metro,http://metro.mahapps.com/winfx/xaml/controls  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-af$http://schemas.fontawesome.io/icons/  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	   	     � Title$  
MainWindow��5   	   $	��600��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    J� InputBindings 5      �� 5   
   
 �� Key$ F5��6    �� Command 5      �� *BuscarCommand+.��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��80��6   $��5q�5      ��5      �� *NuevoItemCommand+.��5      �� .+�5       "  FontAwesome.WPF.ImageAwesome     Icon$
 File=�6&   $��14��5!   &   $��14��5"   &      
Foreground
 � � �5#   &   �� 5%      $��Nuevo��6    $
��Bold"�5&       5(      5*      �� 5-      $��80��6   $��5q�5.      ��5/      �� *ModificarItemCommand+.��51      �� .+�52        $
 Edit=�6&   $��14��53   &   $��14��54   &   
 ��  �55   &   �� 57      $��	Modificar��6    $
��Bold"�58       5:      5<      �� 5>      $��80��6   $��5q�5?      ��5@      �� *BorrarItemCommand+.��5B      �� .+�5C        $ Trash=�6&   $��14��5D   &   $��14��5E   &   
 �  ��5F   &   �� 5H      $��Borrar��6    $
��Bold"�5I       5K      5M      5N      &   System.Windows.Controls.DataGrid  5P   
   $��1��6   	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserResizeRows .     AutoGenerateColumns .    
IsReadOnly .    SelectionMode$ Single=�5W         SelectionUnit$ FullRow=�5Y      ��5Q      �� *Lista+ �� SelectedItem 5X      �� *ItemSeleccionado+ �� UpdateSourceTrigger$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5[      /  )System.Windows.Interactivity.EventTrigger  5\         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5]      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *ModificarItemCommand+5_       5a      �� 5b      $ Delete��6    5c      �� *BorrarItemCommand+5f      5g      5h      