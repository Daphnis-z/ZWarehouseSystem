   M S B A M L   `   `   `  ����  ZWarehouseSystem3    -ZWarehouseSystem.ChildWindow.UserManageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  UserManageWindow��5   	   $	��300��6"   $	��485��6/    � 
ResizeMode$ NoResize=�6;    � WindowStyle$
 None=�6Q    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�   ��6~   Z� .��5      �� ���	#FF37B208$��1q�6%    �� CornerRadius$ 2��69   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5	      �  � Color$ 	#FF37B208��6   	 � Offset$	 0Q�61   � 5
      $ White��6   $	 1Q�6-   � 5      $ 	#FF63C33E��6   $	 0.108Q�61   � 5      $ White��6   $
	 0.12Q�6-   5      ._�5   
   � .+�5      �� $��账户管理��6   $��Center=�6#   $��211,3,204,0q�6@   $	��Top=�6U   
�������$��14(�6�   $��68��6�   �� 5      -   5        
 ��Name$
 LabExit��5      $��X��6%   $��Center=�61   $��	460,3,5,0q�6N   $	��Top=�6a   
�������$��14(�6�   6�   �� 5      -   5         ��Name$ ListBoxAccounts��5      $
��Left=�6/   $	��218��6J   $��4,70,0,0q�6W   $	��Top=�6i   $	��134��6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��删除��5   #   6/   5      5      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5      -   5          Name$ 
WTUsername��5   $      	Watermark$ 	用户名��68   $��225,95,87,177q�6H   $��Center=�6_   ��6�   Z�   5      -   5        $ 
WTPassword��5   $   $ 密码��68   $��225,120,87,152q�6G   $��Center=�6_   ��6�   Z� �� 5      -   5         ��Name$ BtnAdd��5      $��添加��6%   $
��Left=�62   $��274,203,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5      $��系统当前账户列表��6   $
��Left=�6'   $��	10,40,0,0q�6B   $	��Top=�6U   $��14(�6m   �� 5      -   5         ��Name$ ComboBoxGroup��5      $
��Left=�6.   $��225,146,0,0q�6I   $	��Top=�6^   $	��171��6v   $��26��6�    �� 
IsReadOnly .  �� SelectedIndex$ 1��6�    � ToolTip$ 	用户组��6�   .@�5      �� $��admin��6   �� 5      $
��user��6   5       5!      5"      5#      