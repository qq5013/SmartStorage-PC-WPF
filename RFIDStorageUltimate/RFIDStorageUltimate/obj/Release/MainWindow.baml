   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=0.11.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  N JRFIDStorageUltimate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:RFIDStorageUltimateRFIDStorageUltimate $   RFIDStorageUltimate.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    1Local!clr-namespace:RFIDStorageUltimate    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   (   "MahApps.Metro.Controls.MetroWindow   Name$  MetroMainWindow�� � Title$ 登录界面��$	��350��$	��400�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .    AccentColorBrush   	GlowBrush# �    � Icon$ Images/MainTitle.png��   WindowCommands +   %MahApps.Metro.Controls.WindowCommands  .@��� -    ��Name$ 
SkinButton����.  .���� 	 �� Orientation$	 
Horizontal=�.+��� $��Images/Skin.png���� $��色调��
�������$��0,6,0,0q��� -   $ ThemeButton����.  .���� $	 
Horizontal=�.+��� -   
 ��Name$
 
ThemeImage��$��Images/Dark.png���� $��主题��
�������$��0,6,0,0q�.��8   2MahApps.Metro.Controls.TransitioningContentControl  -     Name$ MainControl��   
Transition$
 Left=�.���� -    ��Name$ 	MainPanel��$	 Vertical=�.+��� -   $ TopPanel��$	 Vertical=�.+��� -   $ LinearPanel��$��70������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���   AccentColor � Color# �   � Offset$ 0Q��   AccentColor2# �  $ 1Q��� -	   $ OperatePanel��$	��220��.+��� $	 
Horizontal=�$	��150������ $ 0.5,1&�$ 0.5,0&�.��� # �  $ 0Q�� $ 	#CCDEDEDE��$	 0.2Q�.+��� -
   $ 
ImagePanel��$	��150��.+��� -   $ 	LogoPanel��$	��120��$	��120��$��
30,15,0,15q�#���    J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   
BlurRadius$ 0Q�   Color# �  .+��� $��Images/Logo.png���� -   $ 	TextPanel��$	��250��$	 Vertical=�.+��� -    ��Name$ UsernameTextBox�� �� TextWrapping$
 Wrap=�$��30��$	��200�� �� MaxLines$ 1�� �� 	MaxLength$ 10��$��16(�$��0,30,0,0q�*   $MahApps.Metro.Controls.TextboxHelper   ClearTextButton .    	Watermark$ 	用户名��   SelectAllOnFocus .  �� IsInputMethodEnabled .  .������  �� Path$ Username� �� Mode$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=�! �� ValidationRules! /  )RFIDStorageUltimate.NotNullValidationRule  -   UsernameValidationRule��.���� -   $ PasswordTextBox��$
 Wrap=�$��30��$	��200��$ 1��$ 20��$��16(�$��0,30,0,0q� . $ 密  码�� .  .  .������ $ Password�$ TwoWay=�$  PropertyChanged=�!   -   PasswordValidationRule��.��� -   " �Name$" loginBar��# � IsIndeterminate# .  �� $��60������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#CCDEDEDE��$ 0Q�� # �  $	 0.1Q�� # �  $ 1Q�.+��� -   $ LoginButton��$ �� 	IsDefault$ . $��
进    入��$��23(�$	��200��$��40��$
��0,10q�  HighlightBrush#���  �� $��30��#���   .@��� -   % ��Name$% StatusTextBlock��$
��Wrap=�$&�� Copyright@RFID智能仓储小组��$��	110,0,0,0q�
�������& � 	Resources&   LoginStoryBoard' g� Duration	( t� To) �� 
TargetName* �� TargetProperty	+ W� To  CancelStoryBoard  CloseStoryBoard�� %,  &	       &	 �     &	 �    �� .��t� $' 0:0:0.3D�$( 	110,0,0,0X�$) 
ImagePanel��$* Margin�W� $' 0:0:0.3D�$+ 0X�$) 	TextPanel��$* Opacity�W� $' 0:0:0.1D�$+ 15X�$) 	LogoPanel��$6* 0(UIElement.Effect).(DropShadowEffect.BlurRadius)��� .��t� $' 0:0:0.1D�$( 0,0,0,0X�$) 
ImagePanel��$* Margin�W� $' 0:0:0.1D�$+ 1X�$) 	TextPanel��$* Opacity�W� $' 0:0:0.1D�$+ 0X�$) 	LogoPanel��$6* 0(UIElement.Effect).(DropShadowEffect.BlurRadius)��� .��W� $' 0:0:0.3D�$+ 0X�$) MetroMainWindow��$* Opacity�