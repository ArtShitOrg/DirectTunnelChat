   M S B A M L   `   `   `  ����J  FMessageIpSender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MessageIpSender.ConvertersMessageIpSender.Converters  5   	        MessageIpSender.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <convert(clr-namespace:MessageIpSender.Converters     5   	   -   5          � Title$  Chat IP-connecter��5   	   $	��525��6#   $	��400��60   $y�Visible=�5   	   
������  � 	Resources 5	      @   :MessageIpSender.Converters.IsConnectedValueConverterButton   ButtonConverter?   9MessageIpSender.Converters.IsConnectedValueConverterColor  ColorConverter;   5MessageIpSender.Converters.MessageValueConverterColor  MessageConverter8   2MessageIpSender.Converters.ListValueConverterWidth  WidthConverter5   /MessageIpSender.Converters.TimeSpanCutConverter  TimeSpanCutConverter  ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property	 P� Value
 �� 
TargetName��%�  &	        &	      &	 &     &	 9     &	 L     &	 _       5
   
   62     5   
   61     5   
   6-     5   
   6*     5   
   6'   �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ buttonBorder��6!   #��z��67   #��z��6c   $��1q�6�   ._�5      �� #��z��6/   #��z��6r   5       5      P� 5       �@J�IsMouseOver	 . . �5   "   ��  � ��
 �   �6?   �� 5   "    � �� �#4444446@   �� 5   "    � �� �#DDDDDD6?   5      P� 5       �@J�IsMouseOver	 .  . �5   "   ��  � ��
 �   �6?   �� 5   "    � ��
 �   �6@   �� 5   "    � ��
 �����6?   5       P� 5!       � ��	 . . �5"   "   �� $
 buttonBorder��6)    � ��
 �   �6Y   �� 5#   "    � ��
 �����6?   �� 5$   "   $
 buttonBorder��6)    � ��
 �����6Z   5%      5'      5)      5*      5+      .��5,      �� ._�5-   
   � ���#EEEEEE � RowDefinitions 5.      �� 5/      $
��auto �6    �� 50      $
��auto �6    �� 51      $
��auto �6    �� 52      $��* �6    .+�54      �� #���  6:   $	��100��6`   $��28��6l   $��
24,14,0,12q�6x   $
��Left=�6�   $��Calibri)�6�   $��12(�6�   ��6   �� *CommandConnected+��6�   �� *IsConnected+ �� 	Converter# [  56      �� 57      $��8��6   $��8��6    $
��Left=�6x   $��
27,24,0,22q�6�   ��6*   �� *IsConnected+# [ 6�   �� 58      $��Right=�6   $��0,8,0,2q�65   $��45��6F   .+�59      �� $��	140,0,6,2q�6    �� Orientation$ 
Horizontal=�60   $	��Top=�6I   .+�5:      �� 
���   �$	��To:��63   �� 5;      $��21��66   $	��150��6B   $��19,0,0,0q�6N   ��6   �� *IPSend+6N   �� 5<      
���   �$	�� : ��63   �� 5=      $��21��68   $��50��6D   ��6   �� *
PortSend+6D   5>      �� 5?      $��	140,0,6,0q�6   $ 
Horizontal=�60   $	��Top=�6I   .+�5@      �� 
���   �$��From:��63   �� 5A      $��21��66   $	��150��6B   $��6,0,0,0q�6N   ��6   �� *IPHost+6N   �� 5B      
���   �$	�� : ��63   �� 5C      $��21��68   $��50��6D   ��6   �� *
PortHost+6D   5D      5E      �� 5G      $%��   Ваше сообщение:��6   $��1��62   
���   �6?   �� 5H      -   5         ��Name$ 
MessageBox��5H   #   $��1��6    �� TextWrapping$ WrapWithOverflow=�6i   $	��100��6�   $��6,18,6,0q�6�   ��67   �� *	Message+6�   �� 5J      -   5         ��Name$ MessageList��5J   4   $��3��6   $��6,6,6,6q�6#   $��2��5K   ]   ��6   �� *
Messages+ �� SelectedItem 67   �� *SelectedItem+��5L      �� 5M      .R�5N      �� ��6!   ��  �� ElementName$ MessageList�� �� Path$ ActualWidth�# [ ��5O   !   �� *
IsFromMe+# [ ._�5P      �� $ 
Horizontal=�6)   .+�5Q   "   �� $
��Wrap=�6,   
���iii�$��12(�6�   $��0,0,12,0q�6�   ��6U   �� *Time+# [ 6�   �� 5R   "   $
��Wrap=�6,   $��12(�6Y   ��6@   �� *	Message+6Y   5S      5T      5U      5W      �� 5Y      -   5         ��Name$ 
buttonSend��5Y      $��2��6)   #���  66   $��Right=�6|   $��0,6,6,6q�6�   $��28��6�   $	��100��6�   $��Отправить!��6�   ��6\   �� *CommandSend+6�   5Z      5[      5\      