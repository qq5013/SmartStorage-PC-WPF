   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   RFIDStorageUltimate'   !RFIDStorageUltimate.OperateWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     -   (   "MahApps.Metro.Controls.MetroWindow   Name$  MetroOperateWindow�� � Title$ 操作界面��$	��610��$	��800�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .    AccentColorBrush   	GlowBrush# �    � Icon$ Images/OperateTitle.png��   WindowCommands +   %MahApps.Metro.Controls.WindowCommands  .@��� -    ��Name$ 	SetButton����.  .���� 	 �� Orientation$	 
Horizontal=�.+��� $��Images/Set.png���� $��设置��
�������$��0,7,0,0q�
   Flyouts
 +   %MahApps.Metro.Controls.FlyoutsControl  .@�#   MahApps.Metro.Controls.Flyout  -     Name$ 	SetFlyout��$	��270��   Header$ 操作设置��   Position$ Right=�.��� $��0,20,0,0q� � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� $��50 � � ColumnDefinitions �� $��85 ��� $	��185 �.+��� $��0��$��0��$��Center=�$��Center=�$��串  口��$��16(�$��20,0,0,0q��� -    ��Name$ SerialComboBox��$��0��$��1��$��Center=�$	��140��$��25��$��Center=��� $��1��$��0��$��Center=�$��Center=�$
��IntQ��$��16(�$��20,0,0,0q��� -   $ IntQComboBox��$��1��$��1��$��Center=�$	��140��$��25��$��Center=��� $��2��$��0��$��Center=�$��Center=�$��功  率��$��16(�$��20,0,0,0q��� -   $ PowerComboBox��$��2��$��1��$��Center=�$	��140��$��25��$��Center=��� $��3��$��0��$��Center=�$��Center=�$��操  作��$��16(�$��20,0,0,0q��� -   $ OperateComboBox��$��3��$��1��$��Center=�$	��140��$��25��$��Center=�.��8   2MahApps.Metro.Controls.TransitioningContentControl  -     Name$ MainControl��   
Transition$
 Left=�.���� -	    ��Name$ 	MainPanel��$	 Vertical=�.+��� -
   $ TopPanel��$	��550��$	 
Horizontal=�.+��� -   $ 	MenuPanel��$	��250������  �� EndPoint$	 1,0&� �� 
StartPoint$	 0,1&�.���   AccentColor2 � Color# �   � Offset$ 0Q��   AccentColor4# �  $	 0.5Q�� # �  $ 1Q�.+�!   MahApps.Metro.Controls.Tile  -     Name$ SwitchButton��$	��150��$	��150��$��
50,30,50,0q�  ShadowStyle#���   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  -   SwitchDropShadowEffect��   ShadowDepth$ 0Q�   
BlurRadius$ 0Q�  AccentColor   Color# �  .���� $	��150��$��Images/Switch.png���� $��操作信息��$��
15,45,15,0q�.���  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��$��0��$
��Wrap=�$��
操作员:��$��Center=�#���   $��20(�$��	0,10,0,10q�$
��Bold"��� $��1��$��0��$
��Wrap=�$��	操  作:��$��Center=�#���   $��20(�$��	0,10,0,10q�$
��Bold"��� $��2��$��0��$
��Wrap=�$��
已扫描:��$��Center=�#���   $��20(�$��	0,10,0,10q�$
��Bold"��� $��3��$��0��$
��Wrap=�$��
已成功:��$��Center=�#���   $��20(�$��	0,10,0,10q�$
��Bold"��� $��4��$��0��$
��Wrap=�$��
未知签:��$��Center=�#���   $��20(�$��	0,10,0,10q�$
��Bold"�  -   $ ShowUserControl��$
 Down=�$��0��$��1��.���� -    ��Name$ ShowUserTextBlock��$��0��$��1��$
��Wrap=�$��Center=�#���   $��20(�$��	0,10,0,10q�  -   $ ShowOperateControl��$
 Down=�$��1��$��1��.���� -   $ ShowOperateTextBlock��$��0��$��1��$
��Wrap=�$��Center=�#���   $��20(�$��	0,10,0,10q�  -   $ ShowScanCountControl��$
 Down=�$��2��$��1��.���� -   $ ShowScanCountTextBlock��$��0��$��1��$
��Wrap=�$��0��$��Center=�#���   $��20(�$��	0,10,0,10q�  -   $ ShowScanKnowCountControl��$
 Down=�$��3��$��1��.���� -   $  ShowScanKnowCountTextBlock��$��0��$��1��$
��Wrap=�$��0��$��Center=�#���   $��20(�$��	0,10,0,10q�  -   $  ShowScanUnknowCountControl��$
 Down=�$��4��$��1��.���� -   $" ShowScanUnknowCountTextBlock��$��0��$��1��$
��Wrap=�$��0��$��Center=�#���   $��20(�$��	0,10,0,10q��� -   $ 	ViewPanel��$	 Vertical=����	#CCE5E5E5.+��� $��35��$
��Wrap=�$��操作预览��$��24(�$��45,5,0,5q�#���   &   System.Windows.Controls.DataGrid  -     Name$ OperateDataGrid��$	��505��   AutoGenerateColumns .      
IsReadOnly  . !   CanUserAddRows! .  "   CanUserDeleteRows" .  #   CanUserResizeRows# .  $   	RowHeight$$ 20Q�%   MinColumnWidth$	% 100Q�&   CanUserResizeColumns& .  '   CanUserReorderColumns' .    AzureDataGrid#��[ ��Z� (   Columns( 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn) 
  Header$) 编号��* 
  Width5  /System.Windows.Controls.DataGridLengthConverter$	* 183 1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ �� *GoodsNumber+	  $) 名称��$	* 183 + �� *	GoodsName+	  $) 数量��$	* 184 + �� *
GoodsCount+�� -   , ��Name$, IndicateStatusBar��$��30��#���   .@�)   #MahApps.Metro.Controls.ProgressRing  -   -  Name$- 
StatusRing��.   IsActive. .  /   IsLarge/ .  
�������$��20��$��20��$��Right=��� -   $ StatusTextBlock��$
��Wrap=�$��就绪��
�������$��15(�$��0,0,0,0q�0 � 	Resources0   CloseStoryBoard1 g� Duration	2 W� To3 �� 
TargetName4 �� TargetProperty�� %T   &	       �� .��W� $1 0:0:0.3D�$2 0X�$3 MetroOperateWindow��$4 Opacity�