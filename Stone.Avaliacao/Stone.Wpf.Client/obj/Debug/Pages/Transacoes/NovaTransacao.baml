   M S B A M L   `   `   `  ����K  GStone.Wpf.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Stone.Wpf.Client.Pages.Transacoes!Stone.Wpf.Client.Pages.Transacoes  5   	   5    /Stone.Wpf.Client.Pages.Transacoes.NovaTransacao   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Stone.Wpf.Client.Pages.Transacoes     5   	   -   5          � Title$  Nova Transação��5   	   $	��455��6     � 
ResizeMode$ NoResize=�6-    � WindowStartupLocation$ CenterScreen=�6C   $	��400��6   .��5	      � .+�5
   
   �� -   5         ��Name$ 	btnVoltar��5
      $��Cancelar��6$   $
��Left=�67   $��216,376,0,0q�6R   $	��Top=�6g   $	��100��6   $��30��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ txtData��5      $
��Left=�6&   $��
143,20,0,0q�6A   $	��Top=�6U      IsDropDownOpen . $	��120��6�   {�.  6�   �� 5   
   -   5         ��Name$ cmbTipoTransacao��5      $
��Left=�6-   $��
143,56,0,0q�6H   $	��Top=�6\   $	��120��6t   �� 5   
   -   5         ��Name$ txtValor��5      $
��Left=�6$   $��23��6?   $��
143,92,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��120��6�   6�   �� 5   
   -   5        $ txtParcelas��5      $
��Left=�6'   $��23��6B   $��143,131,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   6�   �� 5   
   -   5        	 ��Name$	 label��5      $
��Data��6   $
��Left=�6.   $��	20,20,0,0q�6I   $	��Top=�6\   �� 5   
   -   5        $	 label1��5      $��Tipo da Transação��6    $
��Left=�6<   $��	20,52,0,0q�6W   $	��Top=�6j   
 J� RenderTransformOrigin$
 -0.106,-1.203&�6�   �� 5   
   -	   5        $	 label2��5      $��Valor��6    $
��Left=�60   $��	20,88,0,0q�6K   $	��Top=�6^   �� 5   
   -
   5         ��Name$ chkParcelado��5      $��	Parcelado��6)   $
��Left=�6=   $��
295,94,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $	 label3��5      $��Nº Parcelas��6    $
��Left=�66   $��
20,127,0,0q�6Q   $	��Top=�6e   �� 5   
   -   5        $ txtPortador��5      $
��Left=�6'   $��23��6B   $��143,175,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��224��6�    �� 	MaxLength$	 100��6�   �� 5   
   -   5        $	 label4��5      $��Nome do Portador��6    $
��Left=�6;   $��
20,171,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $	 label5��5      $��Nº do Cartão��6    $
��Left=�67   $��
20,211,0,0q�6R   $	��Top=�6f   �� 5   
   -   5        $ 	txtCartao��5      $
��Left=�6%   $��23��6@   $��143,215,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��224��6�   $ 19��6�   �� 5   
   -   5        $ cmbBandeira��5      $
��Left=�6(   $��143,254,0,0q�6C   $	��Top=�6X   $	��120��6p   �� 5   
   -   5        $	 label6��5      $��Bandeira��6    $
��Left=�63   $��
20,250,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ chkChip��5      $
��Chip��6$   $
��Left=�63   $��295,256,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $	 label7��5      $��Senha��6    $
��Left=�60   $��
20,331,0,0q�6K   $	��Top=�6_   �� 5   
   -   5        $ btnConfirmar��5      $��	Confirmar��6'   $
��Left=�6;   $��
87,376,0,0q�6V   $	��Top=�6j   $	��100��6�   $��30��6�   6�   �� 5   
   -   5        $	 label8��5      $�� Validade (mês/ano)��6    $
��Left=�6>   $��
14,296,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ txtMes��5      $
��Left=�6"   $��23��6=   $��143,296,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $��53��6�   $ 2��6�   6�   �� 5   
   -   5        $ txtAno��5      $
��Left=�6"   $��23��6=   $��201,296,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $��62��6�   $ 4��6�   6�   G� 5    
   -   5         G�Name$ txtSenha��5       $
��Left=�6(   $��143,331,0,0q�6C   $	��Top=�6X   $	��224��6p   $��23��6|   5"      5#      