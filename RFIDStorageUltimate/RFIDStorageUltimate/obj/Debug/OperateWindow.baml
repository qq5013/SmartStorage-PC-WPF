   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    RFIDStorageUltimate'   !RFIDStorageUltimate.OperateWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$  MetroOperateWindow��5   	    � Title$ 操作界面��6%   $	��610��63   $	��800��6@    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�6"    � AllowsTransparency .    AccentColorBrush   	GlowBrush# �   5   	    � Icon$ Images/OperateTitle.png��68      WindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5	   
   .@�5
      �� -   5         ��Name$ 	SetButton��5
      ��.  .��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� $��Images/Set.png��6   �� 5      $��设置��6    
�������$��0,7,0,0q�6=   5      5      5      
   Flyouts
 5      +   %MahApps.Metro.Controls.FlyoutsControl  5   
   .@�5      #   MahApps.Metro.Controls.Flyout  -   5          Name$ 	SetFlyout��5      $	��270��61      Header$ 操作设置��6=      Position$ Right=�6K   .��5      � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $��50 �6(   �� 5      $��50 �6(   �� 5      $��50 �6(   �� 5      $��50 �6(    � ColumnDefinitions 5      �� 5      $��85 �6+   �� 5      $	��185 �6+   .+�5       �� $��0��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $��串  口��6u   $��16(�6�   $��20,0,0,0q�6�   �� 5!      -   5         ��Name$ SerialComboBox��5!      $��0��67   $��1��6D   $��Center=�6T   $	��140��6q   $��25��6}   $��Center=�6�   �� 5"      $��1��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $
��IntQ��6u   $��16(�6�   $��20,0,0,0q�6�   �� 5#      -   5        $ IntQComboBox��5#      $��1��65   $��1��6B   $��Center=�6R   $	��140��6o   $��25��6{   $��Center=�6�   �� 5$      $��2��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $��功  率��6u   $��16(�6�   $��20,0,0,0q�6�   �� 5%      -   5        $ PowerComboBox��5%      $��2��66   $��1��6C   $��Center=�6S   $	��140��6p   $��25��6|   $��Center=�6�   �� 5&      $��3��6    $��0��6-   $��Center=�6=   $��Center=�6Z   $��操  作��6u   $��16(�6�   $��20,0,0,0q�6�   �� 5'      -   5        $ OperateComboBox��5'      $��3��68   $��1��6E   $��Center=�6U   $	��140��6r   $��25��6~   $��Center=�6�   6�   5(      5)      5*      .��5,      8   2MahApps.Metro.Controls.TransitioningContentControl  -   5          Name$ MainControl��5,   +      
Transition$
 Left=�6@   .��5-   
   �� -	   5         ��Name$ 	MainPanel��5-      $	 Vertical=�6(   .+�5.      �� -
   5        $ TopPanel��5.      $	��550��6+   $	 
Horizontal=�68   .+�5/      �� -   5        $ 	MenuPanel��5/      $	��250��60   ��50      �� 51       �� EndPoint$	 1,0&�6.    �� 
StartPoint$	 0,1&�6=   .��52      �   AccentColor2 � Color# �  6+    � Offset$ 0Q�6R   � 53        AccentColor4# �  6+   $	 0.5Q�6R   � 54      # �  6+   $ 1Q�6R   55      .+�57      !   MahApps.Metro.Controls.Tile  -   5          Name$ SwitchButton��57   $   $	��150��6:   $	��150��6G   $��
50,30,50,0q�6S     ShadowStyle#���  6g    J� Effect 58      3  -System.Windows.Media.Effects.DropShadowEffect  59      -   5        SwitchDropShadowEffect��   ShadowDepth$ 0Q�59   O      
BlurRadius$ 0Q�6_     AccentColor   Color# �  6n   .��5;      �� $	��150��6    $��Images/Switch.png��6-   5<      �� 5=      $��操作信息��6   $��
15,45,15,0q�6-   .��5>      �  5?      �� 5@   "   $��* �60   �� 5A   "   $��* �60   �� 5B   "   $��* �60   �� 5C   "   $��* �60   �� 5D   "   $��* �60    5F      �� 5G   "   $��* �63   �� 5H   "   $��* �63   .+�5J      �� $��0��6(   $��0��65   $
��Wrap=�6E   $��
操作员:��6Y   $��Center=�6e   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   $
��Bold"�6�   �� 5K      $��1��6(   $��0��65   $
��Wrap=�6E   $��	操  作:��6Y   $��Center=�6f   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   $
��Bold"�6�   �� 5L      $��2��6(   $��0��65   $
��Wrap=�6E   $��
已扫描:��6Y   $��Center=�6e   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   $
��Bold"�6�   �� 5M      $��3��6(   $��0��65   $
��Wrap=�6E   $��
已成功:��6Y   $��Center=�6e   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   $
��Bold"�6�   �� 5N      $��4��6(   $��0��65   $
��Wrap=�6E   $��
未知签:��6Y   $��Center=�6e   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   $
��Bold"�6�     5O      -   5        $ ShowUserControl��5O   C   $
 Down=�6\   $��0��6o   $��1��6|   .��5P   "   �� -   5         ��Name$ ShowUserTextBlock��5P   ,   $��0��6G   $��1��6T   $
��Wrap=�6d   $��Center=�6x   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   5Q        5R      -   5        $ ShowOperateControl��5R   C   $
 Down=�6_   $��1��6q   $��1��6~   .��5S   "   �� -   5        $ ShowOperateTextBlock��5S   ,   $��0��6J   $��1��6W   $
��Wrap=�6g   $��Center=�6{   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   5T        5U      -   5        $ ShowScanCountControl��5U   C   $
 Down=�6a   $��2��6s   $��1��6�   .��5V   "   �� -   5        $ ShowScanCountTextBlock��5V   ,   $��0��6L   $��1��6Y   $
��Wrap=�6i   $��0��6}   $��Center=�6�   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   5W        5X      -   5        $ ShowScanKnowCountControl��5X   C   $
 Down=�6e   $��3��6w   $��1��6�   .��5Y   "   �� -   5        $  ShowScanKnowCountTextBlock��5Y   ,   $��0��6P   $��1��6]   $
��Wrap=�6m   $��0��6�   $��Center=�6�   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   5Z        5[      -   5        $  ShowScanUnknowCountControl��5[   C   $
 Down=�6g   $��4��6y   $��1��6�   .��5\   "   �� -   5        $" ShowScanUnknowCountTextBlock��5\   ,   $��0��6R   $��1��6_   $
��Wrap=�6o   $��0��6�   $��Center=�6�   #���   6�   $��20(�6�   $��	0,10,0,10q�6�   5]      5^      5_      5`      �� 5a      -   5        $ 	ViewPanel��5a      $	 Vertical=�60   ���	#CCE5E5E5.+�5b      �� $��35��6    $
��Wrap=�6,   $��操作预览��6@   $��24(�6L   $��45,5,0,5q�6Z   #���   6l   &   System.Windows.Controls.DataGrid  5c      -   5          Name$ OperateDataGrid��5c      $	��505��68      AutoGenerateColumns .      
IsReadOnly  . !   CanUserAddRows! .  "   CanUserDeleteRows" .  #   CanUserResizeRows# .  $   	RowHeight$$ 20Q�6�   %   MinColumnWidth$	% 100Q�6�   &   CanUserResizeColumns& .  '   CanUserReorderColumns' .    AzureDataGrid#��[ 63  ��6  Z� (   Columns( 5d      0	  *System.Windows.Controls.DataGridTextColumn	  5e      ,
  &System.Windows.Controls.DataGridColumn) 
  Header$) 编号��6Q   * 
  Width5  /System.Windows.Controls.DataGridLengthConverter$	* 183 6]   1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ 61   �� *GoodsNumber+6]   	  5f      $) 名称��6O   $	* 183 6[   + 61   �� *	GoodsName+6[   	  5g      $) 数量��6P   $	* 184 6\   + 61   �� *
GoodsCount+6\   5i      5j      5k      �� 5l      -   5        , ��Name$, IndicateStatusBar��5l      $��30��63   #���   6?   .@�5m      )   #MahApps.Metro.Controls.ProgressRing  -   5        -  Name$- 
StatusRing��5m   (   .   IsActive. .  /   IsLarge/ .  
�������$��20��6p   $��20��6|   $��Right=�6�   �� 5n      -   5        $ StatusTextBlock��5n      $
��Wrap=�65   $��就绪��6I   
�������$��15(�6f   $��0,0,0,0q�6t   5o      5p      5q      0 � 	Resources0 5s        CloseStoryBoard1 g� Duration	2 W� To3 �� 
TargetName4 �� TargetProperty�� 5t   
   %�   &	       �� 5u      .��5v      W� $1 0:0:0.3D�6"   $2 0X�65   $3 MetroOperateWindow��6<   $4 Opacity�6g   5w      5x      5{      