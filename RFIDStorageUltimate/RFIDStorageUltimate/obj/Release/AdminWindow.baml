   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   RFIDStorageUltimate%   RFIDStorageUltimate.AdminWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     -   (   "MahApps.Metro.Controls.MetroWindow   Name$  MetroAdminWindow�� � Title$ 管理界面��$	��610��$	��800�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .    AccentColorBrush   	GlowBrush# �    � Icon$ Images/AdminTitle.png�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Search��	   WindowCommands	 +   %MahApps.Metro.Controls.WindowCommands  .@��� -   
 ��Name$
 	SetButton����.  .����  �� Orientation$ 
Horizontal=�.+��� $��Images/Set.png���� $��设置��
�������$��0,7,0,0q�   Flyouts +   %MahApps.Metro.Controls.FlyoutsControl  .@�#   MahApps.Metro.Controls.Flyout  -     Name$ 	SetFlyout��$	��270��   Header$ 操作设置��   Position$ Right=�.��� $��0,20,0,0q� � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 � � ColumnDefinitions �� $��85 ��� $	��185 �.+��� $��0��$��0��$��Center=�$��Center=�$��串  口��$��16(�$��20,0,0,0q��� -    ��Name$ SerialComboBox��$��0��$��1��$��Center=�$	��140��$��25��$��Center=��� $��1��$��0��$��Center=�$��Center=�$
��IntQ��$��16(�$��20,0,0,0q��� -   $ IntQComboBox��$��1��$��1��$��Center=�$	��140��$��25��$��Center=��� $��2��$��0��$��Center=�$��Center=�$��功  率��$��16(�$��20,0,0,0q��� -   $ PowerComboBox��$��2��$��1��$��Center=�$	��140��$��25��$��Center=��� $��3��$��0��$��Center=�$��Center=�$��商品类型��$��16(�$��20,0,0,0q��� -   $ GoodsNameComboBox��$��2��$��4��$��0��$��Center=�$	��230��$��25��$��Center=� �� DisplayMemberPath$ 	GoodsName������ *
GoodsTable+�� $��5��$��0��$��Center=�$��Center=�$��清空��$��16(�$��20,0,0,0q�)   #MahApps.Metro.Controls.ToggleSwitch  -	     Name$ ClearSwitch��$��5��$��1��$	��140��   OnLabel$	 是��   OffLabel$	 否��$��0,8,0,0q�.��8   2MahApps.Metro.Controls.TransitioningContentControl  -
     Name$ MainControl��   
Transition$
 Left=�.���� -    ��Name$ 	MainPanel��$ Vertical=�.+��� -   $ TopPanel��$	��550��$ 
Horizontal=�.+��� -   $ 	MenuPanel��$	��250������  �� EndPoint$	 1,0&� �� 
StartPoint$	 0,1&�.���   AccentColor2 � Color# �   � Offset$ 0Q��   AccentColor4# �  $	 0.5Q�� # �  $ 1Q�.+��� -    ��Name$ SearchTextBox��$��10, 30, 10, 0q�*   $MahApps.Metro.Controls.TextboxHelper   	Watermark$ UID单品查询��    ButtonCommand$  Search��  SearchMetroTextBox#���  !   SelectAllOnFocus! . " �� IsInputMethodEnabled" .  .��# J� Effect# 3	  -System.Windows.Media.Effects.DropShadowEffect	  $ 	  ShadowDepth$$ 0Q�% 	  
BlurRadius$% 0Q�  AccentColor& 	  Color#& �  .���� ' J� RenderTransformOrigin$' 1,0.5&�$��25��$��10, 0, 10, 0q���!� ( !� Visual( �� ) �� ElementName$) SearchTextBox��* J� OpacityMask* �� $	 0,0&�$	 0,1&�.��� $ 0Q�$ Transparent��� $ 1Q�$ 	#44000000��z��� + �� ScaleY$+ -1Q�!
   MahApps.Metro.Controls.Tile
  -   , 
 Name$, BrowseInfoButton��$��50��$	��200��$��0,50,0,0q�- 
  Count$- 信息浏览��  ShadowStyle#���  # 	  $$ 0Q�$% 0Q�#& �  .���� $��50��$��Images/BrowseInfo.png��$��0,0,10,0q��� $' 1,0.5&�$��50��$	��200����!� ( �� $) BrowseInfoButton��* �� $	 0,0&�$	 0,1&�.��� $ 0Q�$ Transparent��� $ 1Q�$ 	#44000000��z��� $+ -1Q�
  -   $, RegisterLabelButton��$��50��$	��200��$��0,0,0,0q�$- 贴标登记��#���  # 	  $$ 0Q�$% 0Q�#& �  .���� $��50��$��Images/RegisterLabel.png��$��0,0,10,0q��� $' 1,0.5&�$��50��$	��200����!� ( �� $) RegisterLabelButton��* �� $	 0,0&�$	 0,1&�.��� $ 0Q�$ Transparent��� $ 1Q�$ 	#44000000��z��� $+ -1Q�
  -   $, GoodsManageButton��$��50��$	��200��$��0,0,0,0q�$- 商品管理��#���  # 	  $$ 0Q�$% 0Q�#& �  .���� $��50��$��Images/GoodsManage.png��$��0,0,10,0q��� $' 1,0.5&�$��50��$	��200����!� ( �� $) GoodsManageButton��* �� $	 0,0&�$	 0,1&�.��� $ 0Q�$ Transparent��� $ 1Q�$ 	#44000000��z��� $+ -1Q�
  -   $, UserManageButton��$��50��$	��200��$��0,0,0,0q�$- 人员管理��#���  # 	  $$ 0Q�$% 0Q�#& �  .���� $��50��$��Images/UserManage.png��$��0,0,10,0q��� $' 1,0.5&�$��50��$	��200����!� ( �� $) UserManageButton��* �� $	 0,0&�$	 0,1&�.��� $ 0Q�$ Transparent��� $ 1Q�$ 	#44000000��z��� $+ -1Q��� -   $ 	ViewPanel��.+�  -   $ OperateControl��$ LeftReplace=�$	��550��$	��550�����	#CCDEDEDE.��0   *MahApps.Metro.Controls.MetroContentControl  -   .  Name$. BrowsePanel��.���� $	��550��$	��550��.+��� $	��550��$��0q�.@��� $��商品信息��.��&   System.Windows.Controls.DataGrid  -   /  Name$/ GoodsDataGrid��$	��505��$	��550��0   AutoGenerateColumns0 .  1   
IsReadOnly1 . 2   CanUserAddRows2 .  3   CanUserDeleteRows3 .  4   CanUserResizeRows4 .  5   	RowHeight$5 25Q�6   MinColumnWidth$	6 100Q�7   CanUserResizeColumns7 .  8   CanUserReorderColumns8 .  $��15(�  AzureDataGrid#��[ ���� *
GoodsTable+��Z� 9   RowDetailsTemplate9 �� .R��� : �� Padding$: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�; �� TextAlignment$
; Left=�
���   ����� *GoodsDescription+<   Columns< 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn=   Header$= 商品编号��>   Width5  /System.Windows.Controls.DataGridLengthConverter$	> 150 1  +System.Windows.Controls.DataGridBoundColumn?   Binding? �� *GoodsNumber+  $= 商品名称��$	> 300 ? �� *	GoodsName+  $= 商品数量��$> 87 ? �� *
GoodsCount+�� $��注册信息��.��  -   $/ RegisterDataGrid��$	��505��$	��550��0 .  1 . 2 .  3 .  4 .  $5 25Q�$6 50Q�7 .  8 .  $��15(�#��[ ���� *DetailedRegisterTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *GoodsDescription+<   $	= UID��$	> 275 ? �� *UID+  $= 商品名称��$	> 275 ? �� *	GoodsName+�� $��人员信息��.��  -   $/ UserDataGrid��$	��505��$	��550��0 .  1 . 2 .  3 .  4 .  $5 25Q�7 .  8 .  $��15(�#��[ ���� *	UserTable+��Z� <   $= 	用户名��$	> 225 ? �� *
UserName+  $= 密码��$	> 225 ? �� *UserPassword+4  .System.Windows.Controls.DataGridCheckBoxColumn  $= 权限��$	> 100 ? �� *UserPermission+�� $��入库信息��.��  -   $/ 
InDataGrid��$	��505��$	��550��0 .  1 . 2 .  3 .  4 .  $5 25Q�$6 50Q�7 . 8 .  $��15(�#��[ ���� *	InTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $ Vertical=�.+��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *In_GoodsDescription+<   $	= UID��$	> 200 ? �� *In_UID+  $= 入库时间��$	> 130 ? �� *In_Datetime+  $= 商品名称��$	> 130 ? �� *In_GoodsName+  $= 	操作人��$> 77 ? �� *In_UserName+�� $��出库信息��.��  -   $/ OutDataGrid��$	��505��$	��550��0 .  1 . 2 .  3 .  4 .  $5 25Q�$6 50Q�7 . 8 .  $��15(�#��[ ���� *
OutTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *Out_GoodsDescription+<   $	= UID��$	> 200 ? �� *	Out_UID+  $= 出库时间��$	> 130 ? �� *Out_Datetime+  $= 商品名称��$	> 130 ? �� *Out_GoodsName+  $= 	操作人��$> 77 ? �� *Out_UserName+�� -   @ ��Name$@ IndicateStatusBar��$��30��#���   .@�)   #MahApps.Metro.Controls.ProgressRing  -   A  Name$A 
StatusRing��B   IsActiveB .  C   IsLargeC .  
�������$��20��$��20��$��Right=��� -   D ��Name$D StatusTextBlock��$
��Wrap=�$��就绪��
�������$��15(�$��0,0,0,0q��� -   $ 
ExtraPanel��.+�  -   $. RegisterPanel��.���� $	��510��$	��510��$ Vertical=�.+��� $ 
Horizontal=�.+��� $	��250��$	��250��$ Vertical=�$��0,0,5,5q�.+�
  -    $, RegisterScanningButton��$	��120��$	��250��$��0,0,0,5q�$- 打开扫描�����	#FF1BA1E2$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FF1BA1E2��.���� -!   E ��Name$E ScanningImage��$	��120��$��Images/Scanning.png��$' 0.5,0.5&�z�V� .~��� F �� Angle$F 0Q�
  -"   $, RegisterCleanButton��$	��120��$	��250��$��0,5,0,0q�$- 关闭清理�����	#FF00ABA9$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FF00ABA9��.���� $	��120��$��Images/Clean.png���� $	��250��$	��250��$��5,0,0,5q�.+��� -#   G ��Name$G 	LabelList��$	��250��$	��250��$��1q�#���   #���  # 	  $$ 0Q�$% 0Q�#& �  �� $ 
Horizontal=�.+��� $	��250��$	��250��$��0,5,5,0q�.+��� $	��250��$	��250��$��1q�#���   
�������#���  # 	  $$ 0Q�$% 0Q�#& �  ._��� -$   $D ReadInfo��$	��234��$��15(�$
��Wrap=�$��7q��� $	��250��$	��250��$��5,5,0,0q�.+�
  -%   $, RegisterReadButton��$	��120��$	��250��$��0,0,0,5q�$- 读取标签�����	#FF339933$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FF339933��.���� $	��120��$��Images/Read.png��
  -&   $, RegisterWriteButton��$	��120��$	��250��$��0,5,0,0q�$- 注册标签�����	#FFF09609$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FFF09609��.���� -'   $E RegisterImage��$	��120��$��Images/Write.png��$' 0.5,0.5&�z�V� .~��� $F 0Q�  -(   $. UserManagePanel��.���� $	��510��$	��500��$ 
Horizontal=�.+��� -)   $G UserList��$ UserName��$	��240��#���   $��1q����� *	UserTable+�� $ Vertical=�$��20,0,0,0q�H � DataContextH �� $) UserList��I �� Path$I SelectedItem�.+��� -*   $ UsernameTextBox��J �� TextWrapping$
J Wrap=�$��30��$	��250��K �� MaxLines$K 1��L �� 	MaxLength$L 10��$��16(�M   ClearTextButtonM . $ 	用户名��! . " .  ���� *
UserName+�� -+   $ PasswordTextBox��$
J Wrap=�$��30��$	��250��$K 1��$L 20��$��16(�$��0,20,0,0q�M . $ 密  码��! . " .  ���� *UserPassword+
  -,   $, UserManageAddButton��$	��120��$	��250��$��0,20,0,0q�$- 添加人员�����	#FF8CBF26$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FF8CBF26��.���� $	��120��$��Images/AddUser.png��
  --   $, UserManageDeleteButton��$	��120��$	��250��$��0,20,0,0q�$- 删除人员�����	#FFE51400$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FFE51400��.���� $	��120��$��Images/DeleteUser.png��
  -.   $, UserManageUpdateButton��N �� 	IsDefaultN . $	��120��$	��250��$��0,20,0,0q�$- 更新数据�����	#FFFF6309$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FFFF6309��.���� $	��120��$��Images/UpdateUser.png��  -/   $. GoodsManagePanel��.���� $ Vertical=�.+��� $��35��$
��Wrap=�$��商品管理��$��24(�$��45,5,0,5q�#���     -0   $/ GoodsListDataGrid��$	��235��$	��550��0 .  1 . 2 .  3 .  4 .  $5 25Q�$	6 100Q�7 .  8 .  $��15(����	#FFE5E5E5#��[ ���� *
GoodsTable+<   $= 商品编号��$	> 230 ? �� *GoodsNumber+  $= 商品名称��$	> 307 ? �� *	GoodsName+�� $ 
Horizontal=�.+��� $ Vertical=�$	��280��H �� $) GoodsListDataGrid��$I SelectedItem�.+��� $��15(�$��10q�M . $ 商品编号������ $I GoodsNumber��� $��15(�$��10q�M . $ 商品名称������ $I 	GoodsName��� $��15(�$
J Wrap=�$��10q�"O �� VerticalScrollBarVisibility$O Visible=�$	��155��$ 商品描述������ $I GoodsDescription��� -1   $ OperatePanel��$ Vertical=�$	��270��$	��270��.+��� $ 
Horizontal=�.+�
  -2   $, GoodsManageAddButton��$	��120��$	��120��$��	10,10,5,5q�P 
  Title$P 添加商品�����	#FF5FB30F#���  # 	  $$ 0Q�$% 0Q�$& 	#FF5FB30F��.���� $	��120��$��Images/AddGoods.png��
  -3   $, GoodsManageDeleteButton��$	��120��$	��120��$��	5,10,10,5q�$P 删除商品�����	#FFDF0024#���  # 	  $$ 0Q�$% 0Q�$& 	#FFDF0024��.���� $	��120��$��Images/DeleteGoods.png��
  -4   $, GoodsManageUpdateButton��N . $	��120��$	��250��$- 更新数据��$��
10,5,10,10q����	#FFFF6309$
��Left=�#���  # 	  $$ 0Q�$% 0Q�$& 	#FFFF6309��.���� $	��120��$��Images/UpdateGoods.png��$��0q�  -5   $. SearchPanel��.���� $ Vertical=�$	��550��$	��550��.+��� $��35��$
��Wrap=�$��注册信息��$��24(�$��45,5,0,5q�#���     -6   $/ SearchRegisterDataGrid��$	��115��0 .  1 . 2 .  3 .  4 .  $5 25Q�$	6 100Q�7 .  8 .  $��15(�#��[ ���� *SearchRegisterTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *GoodsDescription+<   $= 商品编号��$	> 275 ? �� *GoodsNumber+  $= 商品名称��$	> 275 ? �� *	GoodsName+�� $��35��$
��Wrap=�$��入库信息��$��24(�$��45,5,0,5q�#���     -7   $/ SearchInDataGrid��$	��150��0 .  1 . 2 .  3 .  4 .  $5 25Q�$	6 100Q�7 .  8 .  $��15(�#��[ ���� *SearchInTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *GoodsDescription+<   $= 商品名称��$	> 240 ? �� *	GoodsName+  $= 入库时间��$	> 240 ? �� *
Datetime+  $= 	操作人��$> 80 ? �� *
UserName+�� $��35��$
��Wrap=�$��出库信息��$��24(�$��45,5,0,5q�#���     -8   $/ SearchOutDataGrid��$	��150��0 .  1 . 2 .  3 .  4 .  $5 25Q�$	6 100Q�7 .  8 .  $��15(�#��[ ���� *SearchOutTable+��Z� 9 �� .R��� $: 20,10q����	#CCDEDEDE._��� $
��Wrap=�$	��495��$��15(�$
; Left=�
���   ����� *GoodsDescription+<   $= 商品名称��$	> 240 ? �� *	GoodsName+  $= 出库时间��$	> 240 ? �� *
Datetime+  $= 	操作人��$> 80 ? �� *
UserName+Q � 	ResourcesQ   ScaningStoryBoardR g� RepeatBehaviorS g� FillBehaviorT g� Duration	U W� ToV �� 
TargetNameW �� TargetProperty  RegisterStoryBoard 	 CloseStoryBoard�� %V  &	       &	 x     &		 �     �� $R 1:0:0��$
S Stop=�.��W� $T 0:0:0.5D�$	U 360X�$V ScanningImage��$'W !RenderTransform.Children[0].Angle��� $R 1:0:0��$
S Stop=�.��W� $T 0:0:0.5D�$	U 360X�$V RegisterImage��$'W !RenderTransform.Children[0].Angle��� .��W� $T 0:0:0.3D�$U 0X�$V MetroAdminWindow��$W Opacity�