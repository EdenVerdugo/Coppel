   M S B A M L   `   `   `  ����K  GP01ConexionBD.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:P01ConexionBD.UIP01ConexionBD.UI  5   	   %    P01ConexionBD.UI.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:P01ConexionBD.UI     5   	     � Title$-  'Interfaz para componente de acceso a bd��5   	   $	��600��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    J� InputBindings 5      �� 5   
   
 �� Key$ F1��6    �� Command 5      �� *NuevaConexionCommand+.��5      �  +� FocusedElement 6   ��  �� ElementName$ ConsultaText�� � RowDefinitions 5   
   �� 5      $	��180 �6   �� 5      �� 5      $��30 �6   .+�5   
   � .+�5      �  5      �� 5      $��25 �6$   �� 5      .+�5       �� $��0��6   $��
Consulta :��5!      $��14(�5"      $
��10,3q�5#      �� 5%      -   5        $��ConsultaText��5'      $��1��5&      $
��10,3q�5(       �� TextWrapping$ WrapWithOverflow=�5)      $��12(�5*      $��Courier New)�5+      	 �� AcceptsReturn	 . 
 �� 
AcceptsTab
 . ��5.      �� *ConsultaText+ �� UpdateSourceTrigger$ PropertyChanged=�.��5/       50      �� 51      $ F5��6%    52   !   �� *EjecutarConsultaCommand+.��54   -   55      56      58      &   System.Windows.Controls.DataGrid  5:   
   $��1��6      AutoGenerateColumns .    CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .  $	��5,3q�5?         AlternatingRowBackground �#c9c9c9   GridLinesVisibility$
 None=�5B      ��5@      �� *
DataSource+��5D      �� 5E       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5F      ��  �� Property � �� �� Value$ 3q�60   5G      5I      � 5J   
   $��2��6   .+�5K      ��  �� Orientation$ 
Horizontal=�6   .+�5L      �� $��(F1) Nueva conexion��6   $��5q�5M      $��Center=�5N      �� 5Q      $��(F5) Ejecutar��6   $��5q�5R      $��Center=�5S      5U      5V      5W      5X      