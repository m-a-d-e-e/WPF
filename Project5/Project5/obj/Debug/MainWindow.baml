   M S B A M L   `   `   `  ����C  ?Project5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Project5Project5  5   	   9!clr-namespace:Project5.ConvertersProject5.Converters  5   	       Project5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Project5     5   	   8
converters!clr-namespace:Project5.Converters     5   	     � Title$  
MainWindow��5	   	   $
��1000��6   $	��520��6*    � 	Resources 5
      3   -Project5.Converters.BoolToVisibilityConverter   BoolToVisibilityConverter  StyleHeader �� 
TargetType �� BasedOn �� Property �� Value  DockPanelMargin  ListViewTemplate �� Orientation F�Name �� 	Converter	 @� Center
 ��Name �� FallbackValue �� TargetNullValue �� StringFormat�� 5   
   %�  &	        &	      &	 �     &	     7   7  7  7  7  7  7  7  7  7  7    5      63   �� 5      " ��6(    6H   Z� .�5      ��  � ��$ 12(�6-   �� 5       � ��$
 Bold"�6/   �� 5       � ��$
 Left=�63   5      �� 5      " ]�6,   .�5      ��  � ��$ 10,2,0,0q�6+   5      �� 5      .R�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6!   $	��100��6:   .+�5      �� $��Images\EmployeeIcon.png��6    $��60��6A   $��10q�6M   F� 5      $ PathIsResigned��6   
���  ��$��12��5"      y�5       �� *
IsResigned+8   ��5#      � 5$   "   .��5%   &   @� $
	 0,45&�66   6F   5&   #   5(      �� 5*      $ Vertical=�6%   $	��400��6<   .+�5+      ]� 8�� .+�5,   "   �� $
 TextBlockName��6,   8�� $��Name:��5.   ,   �� 5/   "   $ 
 TextBlockEmployeeFirstName��6,   $��44,0,0,0q�51   ,   ��50   ,   �� *	FirstName+$ -��51   ,   �� 52   "   $�� ��6,   �� 53   "   $!
 TextBlockEmployeeMiddleName��6,   ��54   ,   �� *
MiddleName+$  ��$ -���� 55   "   $�� ��6,   �� 56   "   $
 TextBlockEmployeeLastName��6,   ��57   ,   �� *
LastName+$ -��58      ]� 59      8�� .+�5:   "   �� $
 TextBlockBirthDate��6,   8�� $��Birth Date:��5<   ,   �� 5=   "   $
 TextBlockEmployeeBithDate��6,   $��20,0,0,0q�5?   ,   ��5>   ,   �� *	BirthDate+$ -��$ dd MMM yyyy��5?   ,   5@      ]� 5B      8�� .+�5C   "   �� $
 TextBlockGenderLabel��6,   8�� $��Gender:��5E   ,   �� 5F   "   $
 TextBlockGender��6,   $��36,0,0,0q�5H   ,   ��5G   ,   �� *Gender+$ -��5H   ,   5I      ]� 5K      8�� .+�5L   "   �� $!
 TextBlockContactNumberLabel��6,   8�� $��Contact:��5N   ,   �� 5O   "   $
 TextBlockContact��6,   $��34,0,0,0q�5Q   ,   ��5P   ,   �� *ContactNumber+$ -��5Q   ,   5R      ]� 5T      8��	 .+�5U   "   �� $
 TextBlockDepartmentLabel��6,   8��
 $��Department:��5W   ,   �� 5X   "   $
 TextBlockDepartment��6,   $��10,0,0,0q�5Z   ,   ��5Y   ,   �� *DepartmentName+$ -��5Z   ,   5[      5\      5]      �� 5^      
���   �$	��0.5q�5_      5`      5a      5c      .��5f      �� -   5         ��Name$ ListViewEmployees��5f      #��[ 5g      5h      5i      