   M S B A M L   `   `   `  ����U  QProducts_NetStock_DataGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Products_NetStock_DataGridProducts_NetStock_DataGrid  5   	   +    %Products_NetStock_DataGrid.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Products_NetStock_DataGrid     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      2   ,Products_NetStock_DataGrid.CalculateNetStock   netStckConverterObj��%   &	          5
   
   6"   5      .��5      � -   5        $��MainGrid��5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ProductGrid��5         AutoGenerateColumns .     CanUserAddRows .  ��6&   ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value . . �5      �� 	 �� Property	 � ��
 �� Value

 �W�.�6;   �� 5      	 � ��

 �����6;   �� 5      	 � ��$
 	ExtraBold"�6;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product Id��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	ProductID+6W     5      $ Product Name��6!   $ 1* 6[    69   �� *ProductName+6[     5      $ 
Unit Price��6!   $ 1* 6W    67   �� *	UnitPrice+6W     5      $ Units In Stock��6%   $ 1* 6b    6?   �� *UnitsInStock+6b     5       $ NetStock��6%   $ 1* 6�    6:   ��  �� NotifyOnTargetUpdated .  �� 	Converter# [  6�   5"      5#      5$      