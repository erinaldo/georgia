<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarInspeccion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvSectores = New System.Windows.Forms.DataGridView
        Me.col1Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Puesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Nro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Luz = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col1Cartel = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col1Cinta = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col1Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Agente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Capacidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Cilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Vto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Vencido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Ausente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Obstruido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Carro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Usado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Despintado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Despresurizado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Altura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1SenalAltura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1SenalBaliza = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Tarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Precinto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Soporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Ruptura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Manguera = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Otro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Valvula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Pico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Lanza = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Llave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col1Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvExtintores = New System.Windows.Forms.DataGridView
        Me.col2Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Puesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Nro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Luz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cartel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Cinta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Agente = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Capacidad = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Cilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vencido = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Ausente = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Obstruido = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Carro = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Usado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Despintado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Despresurizado = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Altura = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2SenalAltura = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2SenalBaliza = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Tarjeta = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Precinto = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Soporte = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Ruptura = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Manguera = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Otro = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col2Valvula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Pico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Lanza = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Llave = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvHidrantes = New System.Windows.Forms.DataGridView
        Me.col3Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Intervencion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Puesto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Sector = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Nro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Luz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Cartel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Cinta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Agente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Capacidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Cilindro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Vto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Vencido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Ausente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Obstruido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Carro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Usado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Despintado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Despresurizado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Altura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3SenalAltura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3SenalBaliza = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Tarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Precinto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Soporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Ruptura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Manguera = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Otro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3Valvula = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3Pico = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3Lanza = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3Vidrio = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3Llave = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col3Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnConfirmar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnRegistrar = New System.Windows.Forms.Button
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvExtintores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHidrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(3, 9)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(79, 13)
        Label1.TabIndex = 1
        Label1.Text = "Puestos Sector"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(3, 9)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(109, 13)
        Label2.TabIndex = 2
        Label2.Text = "Puestos de Extintores"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(3, 5)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(108, 13)
        Label3.TabIndex = 3
        Label3.Text = "Puestos de Hidrantes"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvSectores)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(940, 436)
        Me.SplitContainer1.SplitterDistance = 147
        Me.SplitContainer1.TabIndex = 0
        '
        'dgvSectores
        '
        Me.dgvSectores.AllowUserToAddRows = False
        Me.dgvSectores.AllowUserToDeleteRows = False
        Me.dgvSectores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1Id, Me.col1Intervencion, Me.col1Puesto, Me.col1Sector, Me.col1Tipo, Me.col1Nro, Me.col1Ubicacion, Me.col1Nombre, Me.col1Luz, Me.col1Cartel, Me.col1Cinta, Me.col1Equipo, Me.col1Agente, Me.col1Capacidad, Me.col1Cilindro, Me.col1Vto, Me.col1Vencido, Me.col1Ausente, Me.col1Obstruido, Me.col1Carro, Me.col1Usado, Me.col1Despintado, Me.col1Despresurizado, Me.col1Altura, Me.col1SenalAltura, Me.col1SenalBaliza, Me.col1Tarjeta, Me.col1Precinto, Me.col1Soporte, Me.col1Ruptura, Me.col1Manguera, Me.col1Otro, Me.col1Valvula, Me.col1Pico, Me.col1Lanza, Me.col1Vidrio, Me.col1Llave, Me.col1Obs})
        Me.dgvSectores.Location = New System.Drawing.Point(3, 25)
        Me.dgvSectores.Name = "dgvSectores"
        Me.dgvSectores.Size = New System.Drawing.Size(934, 119)
        Me.dgvSectores.TabIndex = 0
        '
        'col1Id
        '
        Me.col1Id.HeaderText = "Id"
        Me.col1Id.Name = "col1Id"
        Me.col1Id.Visible = False
        '
        'col1Intervencion
        '
        Me.col1Intervencion.HeaderText = "Intervención"
        Me.col1Intervencion.Name = "col1Intervencion"
        Me.col1Intervencion.Visible = False
        '
        'col1Puesto
        '
        Me.col1Puesto.HeaderText = "Puesto"
        Me.col1Puesto.Name = "col1Puesto"
        Me.col1Puesto.Visible = False
        '
        'col1Sector
        '
        Me.col1Sector.HeaderText = "Sector"
        Me.col1Sector.Name = "col1Sector"
        Me.col1Sector.Visible = False
        '
        'col1Tipo
        '
        Me.col1Tipo.HeaderText = "Tipo"
        Me.col1Tipo.Name = "col1Tipo"
        Me.col1Tipo.Visible = False
        '
        'col1Nro
        '
        Me.col1Nro.HeaderText = "Nro"
        Me.col1Nro.Name = "col1Nro"
        '
        'col1Ubicacion
        '
        Me.col1Ubicacion.HeaderText = "Ubicación"
        Me.col1Ubicacion.Name = "col1Ubicacion"
        '
        'col1Nombre
        '
        Me.col1Nombre.HeaderText = "Nombre"
        Me.col1Nombre.Name = "col1Nombre"
        Me.col1Nombre.Visible = False
        '
        'col1Luz
        '
        Me.col1Luz.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col1Luz.HeaderText = "Luz"
        Me.col1Luz.Name = "col1Luz"
        Me.col1Luz.Visible = False
        '
        'col1Cartel
        '
        Me.col1Cartel.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col1Cartel.HeaderText = "Cartel"
        Me.col1Cartel.Name = "col1Cartel"
        '
        'col1Cinta
        '
        Me.col1Cinta.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col1Cinta.HeaderText = "Cinta"
        Me.col1Cinta.Name = "col1Cinta"
        '
        'col1Equipo
        '
        Me.col1Equipo.HeaderText = "Equipo"
        Me.col1Equipo.Name = "col1Equipo"
        Me.col1Equipo.Visible = False
        '
        'col1Agente
        '
        Me.col1Agente.HeaderText = "Agente"
        Me.col1Agente.Name = "col1Agente"
        Me.col1Agente.Visible = False
        '
        'col1Capacidad
        '
        Me.col1Capacidad.HeaderText = "Capacidad"
        Me.col1Capacidad.Name = "col1Capacidad"
        Me.col1Capacidad.Visible = False
        '
        'col1Cilindro
        '
        Me.col1Cilindro.HeaderText = "Cilindro"
        Me.col1Cilindro.Name = "col1Cilindro"
        Me.col1Cilindro.Visible = False
        '
        'col1Vto
        '
        Me.col1Vto.HeaderText = "Vto"
        Me.col1Vto.Name = "col1Vto"
        Me.col1Vto.Visible = False
        '
        'col1Vencido
        '
        Me.col1Vencido.HeaderText = "Vencido"
        Me.col1Vencido.Name = "col1Vencido"
        Me.col1Vencido.ReadOnly = True
        Me.col1Vencido.Visible = False
        '
        'col1Ausente
        '
        Me.col1Ausente.HeaderText = "Ausente"
        Me.col1Ausente.Name = "col1Ausente"
        Me.col1Ausente.Visible = False
        '
        'col1Obstruido
        '
        Me.col1Obstruido.HeaderText = "Obstruido"
        Me.col1Obstruido.Name = "col1Obstruido"
        Me.col1Obstruido.Visible = False
        '
        'col1Carro
        '
        Me.col1Carro.HeaderText = "Carro"
        Me.col1Carro.Name = "col1Carro"
        Me.col1Carro.Visible = False
        '
        'col1Usado
        '
        Me.col1Usado.HeaderText = "Usado"
        Me.col1Usado.Name = "col1Usado"
        Me.col1Usado.Visible = False
        '
        'col1Despintado
        '
        Me.col1Despintado.HeaderText = "Despintado"
        Me.col1Despintado.Name = "col1Despintado"
        Me.col1Despintado.Visible = False
        '
        'col1Despresurizado
        '
        Me.col1Despresurizado.HeaderText = "Despresurizado"
        Me.col1Despresurizado.Name = "col1Despresurizado"
        Me.col1Despresurizado.Visible = False
        '
        'col1Altura
        '
        Me.col1Altura.HeaderText = "Altura"
        Me.col1Altura.Name = "col1Altura"
        Me.col1Altura.Visible = False
        '
        'col1SenalAltura
        '
        Me.col1SenalAltura.HeaderText = "Señal Altura"
        Me.col1SenalAltura.Name = "col1SenalAltura"
        Me.col1SenalAltura.Visible = False
        '
        'col1SenalBaliza
        '
        Me.col1SenalBaliza.HeaderText = "Sañal Baliza"
        Me.col1SenalBaliza.Name = "col1SenalBaliza"
        Me.col1SenalBaliza.Visible = False
        '
        'col1Tarjeta
        '
        Me.col1Tarjeta.HeaderText = "Tarjeta"
        Me.col1Tarjeta.Name = "col1Tarjeta"
        Me.col1Tarjeta.Visible = False
        '
        'col1Precinto
        '
        Me.col1Precinto.HeaderText = "Precinto"
        Me.col1Precinto.Name = "col1Precinto"
        Me.col1Precinto.Visible = False
        '
        'col1Soporte
        '
        Me.col1Soporte.HeaderText = "Soporte"
        Me.col1Soporte.Name = "col1Soporte"
        Me.col1Soporte.Visible = False
        '
        'col1Ruptura
        '
        Me.col1Ruptura.HeaderText = "Ruptura"
        Me.col1Ruptura.Name = "col1Ruptura"
        Me.col1Ruptura.Visible = False
        '
        'col1Manguera
        '
        Me.col1Manguera.HeaderText = "Manguera"
        Me.col1Manguera.Name = "col1Manguera"
        Me.col1Manguera.Visible = False
        '
        'col1Otro
        '
        Me.col1Otro.HeaderText = "Otro"
        Me.col1Otro.Name = "col1Otro"
        Me.col1Otro.Visible = False
        '
        'col1Valvula
        '
        Me.col1Valvula.HeaderText = "Valvula"
        Me.col1Valvula.Name = "col1Valvula"
        Me.col1Valvula.Visible = False
        '
        'col1Pico
        '
        Me.col1Pico.HeaderText = "Pico"
        Me.col1Pico.Name = "col1Pico"
        Me.col1Pico.Visible = False
        '
        'col1Lanza
        '
        Me.col1Lanza.HeaderText = "Lanza"
        Me.col1Lanza.Name = "col1Lanza"
        Me.col1Lanza.Visible = False
        '
        'col1Vidrio
        '
        Me.col1Vidrio.HeaderText = "Vidrio"
        Me.col1Vidrio.Name = "col1Vidrio"
        Me.col1Vidrio.Visible = False
        '
        'col1Llave
        '
        Me.col1Llave.HeaderText = "Llave"
        Me.col1Llave.Name = "col1Llave"
        Me.col1Llave.Visible = False
        '
        'col1Obs
        '
        Me.col1Obs.HeaderText = "Obs"
        Me.col1Obs.Name = "col1Obs"
        Me.col1Obs.Visible = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvExtintores)
        Me.SplitContainer2.Panel1.Controls.Add(Label2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvHidrantes)
        Me.SplitContainer2.Panel2.Controls.Add(Label3)
        Me.SplitContainer2.Size = New System.Drawing.Size(940, 285)
        Me.SplitContainer2.SplitterDistance = 135
        Me.SplitContainer2.TabIndex = 0
        '
        'dgvExtintores
        '
        Me.dgvExtintores.AllowUserToAddRows = False
        Me.dgvExtintores.AllowUserToDeleteRows = False
        Me.dgvExtintores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExtintores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtintores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col2Id, Me.col2Intervencion, Me.col2Puesto, Me.col2Sector, Me.col2Tipo, Me.col2Nro, Me.col2Ubicacion, Me.col2Nombre, Me.col2Luz, Me.col2Cartel, Me.col2Cinta, Me.col2Equipo, Me.col2Agente, Me.col2Capacidad, Me.col2Cilindro, Me.col2Vto, Me.col2Vencido, Me.col2Ausente, Me.col2Obstruido, Me.col2Carro, Me.col2Usado, Me.col2Despintado, Me.col2Despresurizado, Me.col2Altura, Me.col2SenalAltura, Me.col2SenalBaliza, Me.col2Tarjeta, Me.col2Precinto, Me.col2Soporte, Me.col2Ruptura, Me.col2Manguera, Me.col2Otro, Me.col2Valvula, Me.col2Pico, Me.col2Lanza, Me.col2Vidrio, Me.col2Llave, Me.col2Obs})
        Me.dgvExtintores.Location = New System.Drawing.Point(3, 25)
        Me.dgvExtintores.Name = "dgvExtintores"
        Me.dgvExtintores.Size = New System.Drawing.Size(934, 107)
        Me.dgvExtintores.TabIndex = 2
        '
        'col2Id
        '
        Me.col2Id.HeaderText = "Id"
        Me.col2Id.Name = "col2Id"
        Me.col2Id.Visible = False
        '
        'col2Intervencion
        '
        Me.col2Intervencion.HeaderText = "Intervención"
        Me.col2Intervencion.Name = "col2Intervencion"
        Me.col2Intervencion.Visible = False
        '
        'col2Puesto
        '
        Me.col2Puesto.HeaderText = "Puesto"
        Me.col2Puesto.Name = "col2Puesto"
        Me.col2Puesto.ReadOnly = True
        Me.col2Puesto.Visible = False
        '
        'col2Sector
        '
        Me.col2Sector.HeaderText = "Sector"
        Me.col2Sector.Name = "col2Sector"
        Me.col2Sector.Visible = False
        '
        'col2Tipo
        '
        Me.col2Tipo.HeaderText = "Tipo"
        Me.col2Tipo.Name = "col2Tipo"
        Me.col2Tipo.Visible = False
        '
        'col2Nro
        '
        Me.col2Nro.HeaderText = "Nro"
        Me.col2Nro.Name = "col2Nro"
        '
        'col2Ubicacion
        '
        Me.col2Ubicacion.HeaderText = "Ubicación"
        Me.col2Ubicacion.Name = "col2Ubicacion"
        '
        'col2Nombre
        '
        Me.col2Nombre.HeaderText = "Nombre"
        Me.col2Nombre.Name = "col2Nombre"
        Me.col2Nombre.Visible = False
        '
        'col2Luz
        '
        Me.col2Luz.HeaderText = "Luz"
        Me.col2Luz.Name = "col2Luz"
        Me.col2Luz.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Luz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col2Luz.Visible = False
        '
        'col2Cartel
        '
        Me.col2Cartel.HeaderText = "Cartel"
        Me.col2Cartel.Name = "col2Cartel"
        Me.col2Cartel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Cartel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col2Cartel.Visible = False
        '
        'col2Cinta
        '
        Me.col2Cinta.HeaderText = "Cinta"
        Me.col2Cinta.Name = "col2Cinta"
        Me.col2Cinta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Cinta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col2Cinta.Visible = False
        '
        'col2Equipo
        '
        Me.col2Equipo.HeaderText = "Equipo"
        Me.col2Equipo.Name = "col2Equipo"
        Me.col2Equipo.Visible = False
        '
        'col2Agente
        '
        Me.col2Agente.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Agente.HeaderText = "Agente"
        Me.col2Agente.Name = "col2Agente"
        Me.col2Agente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Agente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Capacidad
        '
        Me.col2Capacidad.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Capacidad.HeaderText = "Capacidad"
        Me.col2Capacidad.Name = "col2Capacidad"
        Me.col2Capacidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Capacidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Cilindro
        '
        Me.col2Cilindro.HeaderText = "Cilindro"
        Me.col2Cilindro.Name = "col2Cilindro"
        '
        'col2Vto
        '
        Me.col2Vto.HeaderText = "Vto"
        Me.col2Vto.Name = "col2Vto"
        '
        'col2Vencido
        '
        Me.col2Vencido.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Vencido.HeaderText = "Vencido"
        Me.col2Vencido.Name = "col2Vencido"
        Me.col2Vencido.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Vencido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Ausente
        '
        Me.col2Ausente.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Ausente.HeaderText = "Ausente"
        Me.col2Ausente.Name = "col2Ausente"
        Me.col2Ausente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Ausente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Obstruido
        '
        Me.col2Obstruido.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Obstruido.HeaderText = "Obstruido"
        Me.col2Obstruido.Name = "col2Obstruido"
        Me.col2Obstruido.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Obstruido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Carro
        '
        Me.col2Carro.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Carro.HeaderText = "Carro"
        Me.col2Carro.Name = "col2Carro"
        Me.col2Carro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Carro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Usado
        '
        Me.col2Usado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Usado.HeaderText = "Usado"
        Me.col2Usado.Name = "col2Usado"
        Me.col2Usado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Usado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Despintado
        '
        Me.col2Despintado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Despintado.HeaderText = "Despintado"
        Me.col2Despintado.Name = "col2Despintado"
        Me.col2Despintado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Despintado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Despresurizado
        '
        Me.col2Despresurizado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Despresurizado.HeaderText = "Despresurizado"
        Me.col2Despresurizado.Name = "col2Despresurizado"
        Me.col2Despresurizado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Despresurizado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Altura
        '
        Me.col2Altura.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Altura.HeaderText = "Altura"
        Me.col2Altura.Name = "col2Altura"
        Me.col2Altura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Altura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2SenalAltura
        '
        Me.col2SenalAltura.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2SenalAltura.HeaderText = "Señal Altura"
        Me.col2SenalAltura.Name = "col2SenalAltura"
        Me.col2SenalAltura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2SenalAltura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2SenalBaliza
        '
        Me.col2SenalBaliza.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2SenalBaliza.HeaderText = "Sañal Baliza"
        Me.col2SenalBaliza.Name = "col2SenalBaliza"
        Me.col2SenalBaliza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2SenalBaliza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Tarjeta
        '
        Me.col2Tarjeta.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Tarjeta.HeaderText = "Tarjeta"
        Me.col2Tarjeta.Name = "col2Tarjeta"
        Me.col2Tarjeta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Tarjeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Precinto
        '
        Me.col2Precinto.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Precinto.HeaderText = "Precinto"
        Me.col2Precinto.Name = "col2Precinto"
        Me.col2Precinto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Precinto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Soporte
        '
        Me.col2Soporte.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Soporte.HeaderText = "Soporte"
        Me.col2Soporte.Name = "col2Soporte"
        Me.col2Soporte.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Soporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Ruptura
        '
        Me.col2Ruptura.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Ruptura.HeaderText = "Ruptura"
        Me.col2Ruptura.Name = "col2Ruptura"
        Me.col2Ruptura.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Ruptura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Manguera
        '
        Me.col2Manguera.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Manguera.HeaderText = "Manguera"
        Me.col2Manguera.Name = "col2Manguera"
        Me.col2Manguera.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Manguera.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Otro
        '
        Me.col2Otro.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col2Otro.HeaderText = "Otro"
        Me.col2Otro.Name = "col2Otro"
        Me.col2Otro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col2Otro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col2Valvula
        '
        Me.col2Valvula.HeaderText = "Valvula"
        Me.col2Valvula.Name = "col2Valvula"
        Me.col2Valvula.Visible = False
        '
        'col2Pico
        '
        Me.col2Pico.HeaderText = "Pico"
        Me.col2Pico.Name = "col2Pico"
        Me.col2Pico.Visible = False
        '
        'col2Lanza
        '
        Me.col2Lanza.HeaderText = "Lanza"
        Me.col2Lanza.Name = "col2Lanza"
        Me.col2Lanza.Visible = False
        '
        'col2Vidrio
        '
        Me.col2Vidrio.HeaderText = "Vidrio"
        Me.col2Vidrio.Name = "col2Vidrio"
        Me.col2Vidrio.Visible = False
        '
        'col2Llave
        '
        Me.col2Llave.HeaderText = "Llave"
        Me.col2Llave.Name = "col2Llave"
        Me.col2Llave.Visible = False
        '
        'col2Obs
        '
        Me.col2Obs.HeaderText = "Obs"
        Me.col2Obs.Name = "col2Obs"
        Me.col2Obs.Visible = False
        '
        'dgvHidrantes
        '
        Me.dgvHidrantes.AllowUserToAddRows = False
        Me.dgvHidrantes.AllowUserToDeleteRows = False
        Me.dgvHidrantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHidrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHidrantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col3Id, Me.col3Intervencion, Me.col3Puesto, Me.col3Sector, Me.col3Tipo, Me.col3Nro, Me.col3Ubicacion, Me.col3Nombre, Me.col3Luz, Me.col3Cartel, Me.col3Cinta, Me.col3Equipo, Me.col3Agente, Me.col3Capacidad, Me.col3Cilindro, Me.col3Vto, Me.col3Vencido, Me.col3Ausente, Me.col3Obstruido, Me.col3Carro, Me.col3Usado, Me.col3Despintado, Me.col3Despresurizado, Me.col3Altura, Me.col3SenalAltura, Me.col3SenalBaliza, Me.col3Tarjeta, Me.col3Precinto, Me.col3Soporte, Me.col3Ruptura, Me.col3Manguera, Me.col3Otro, Me.col3Valvula, Me.col3Pico, Me.col3Lanza, Me.col3Vidrio, Me.col3Llave, Me.col3Obs})
        Me.dgvHidrantes.Location = New System.Drawing.Point(3, 21)
        Me.dgvHidrantes.Name = "dgvHidrantes"
        Me.dgvHidrantes.Size = New System.Drawing.Size(934, 122)
        Me.dgvHidrantes.TabIndex = 3
        '
        'col3Id
        '
        Me.col3Id.HeaderText = "Id"
        Me.col3Id.Name = "col3Id"
        Me.col3Id.Visible = False
        '
        'col3Intervencion
        '
        Me.col3Intervencion.HeaderText = "Intervención"
        Me.col3Intervencion.Name = "col3Intervencion"
        Me.col3Intervencion.Visible = False
        '
        'col3Puesto
        '
        Me.col3Puesto.HeaderText = "Puesto"
        Me.col3Puesto.Name = "col3Puesto"
        Me.col3Puesto.Visible = False
        '
        'col3Sector
        '
        Me.col3Sector.HeaderText = "Sector"
        Me.col3Sector.Name = "col3Sector"
        Me.col3Sector.Visible = False
        '
        'col3Tipo
        '
        Me.col3Tipo.HeaderText = "Tipo"
        Me.col3Tipo.Name = "col3Tipo"
        Me.col3Tipo.Visible = False
        '
        'col3Nro
        '
        Me.col3Nro.HeaderText = "Nro"
        Me.col3Nro.Name = "col3Nro"
        '
        'col3Ubicacion
        '
        Me.col3Ubicacion.HeaderText = "Ubicación"
        Me.col3Ubicacion.Name = "col3Ubicacion"
        '
        'col3Nombre
        '
        Me.col3Nombre.HeaderText = "Nombre"
        Me.col3Nombre.Name = "col3Nombre"
        Me.col3Nombre.Visible = False
        '
        'col3Luz
        '
        Me.col3Luz.HeaderText = "Luz"
        Me.col3Luz.Name = "col3Luz"
        Me.col3Luz.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Luz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col3Luz.Visible = False
        '
        'col3Cartel
        '
        Me.col3Cartel.HeaderText = "Cartel"
        Me.col3Cartel.Name = "col3Cartel"
        Me.col3Cartel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Cartel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col3Cartel.Visible = False
        '
        'col3Cinta
        '
        Me.col3Cinta.HeaderText = "Cinta"
        Me.col3Cinta.Name = "col3Cinta"
        Me.col3Cinta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Cinta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col3Cinta.Visible = False
        '
        'col3Equipo
        '
        Me.col3Equipo.HeaderText = "Equipo"
        Me.col3Equipo.Name = "col3Equipo"
        Me.col3Equipo.Visible = False
        '
        'col3Agente
        '
        Me.col3Agente.HeaderText = "Agente"
        Me.col3Agente.Name = "col3Agente"
        Me.col3Agente.Visible = False
        '
        'col3Capacidad
        '
        Me.col3Capacidad.HeaderText = "Capacidad"
        Me.col3Capacidad.Name = "col3Capacidad"
        Me.col3Capacidad.Visible = False
        '
        'col3Cilindro
        '
        Me.col3Cilindro.HeaderText = "Cilindro"
        Me.col3Cilindro.Name = "col3Cilindro"
        Me.col3Cilindro.Visible = False
        '
        'col3Vto
        '
        Me.col3Vto.HeaderText = "Vto"
        Me.col3Vto.Name = "col3Vto"
        Me.col3Vto.Visible = False
        '
        'col3Vencido
        '
        Me.col3Vencido.HeaderText = "Vencido"
        Me.col3Vencido.Name = "col3Vencido"
        Me.col3Vencido.Visible = False
        '
        'col3Ausente
        '
        Me.col3Ausente.HeaderText = "Ausente"
        Me.col3Ausente.Name = "col3Ausente"
        Me.col3Ausente.Visible = False
        '
        'col3Obstruido
        '
        Me.col3Obstruido.HeaderText = "Obstruido"
        Me.col3Obstruido.Name = "col3Obstruido"
        Me.col3Obstruido.Visible = False
        '
        'col3Carro
        '
        Me.col3Carro.HeaderText = "Carro"
        Me.col3Carro.Name = "col3Carro"
        Me.col3Carro.Visible = False
        '
        'col3Usado
        '
        Me.col3Usado.HeaderText = "Usado"
        Me.col3Usado.Name = "col3Usado"
        Me.col3Usado.Visible = False
        '
        'col3Despintado
        '
        Me.col3Despintado.HeaderText = "Despintado"
        Me.col3Despintado.Name = "col3Despintado"
        Me.col3Despintado.Visible = False
        '
        'col3Despresurizado
        '
        Me.col3Despresurizado.HeaderText = "Despresurizado"
        Me.col3Despresurizado.Name = "col3Despresurizado"
        Me.col3Despresurizado.Visible = False
        '
        'col3Altura
        '
        Me.col3Altura.HeaderText = "Altura"
        Me.col3Altura.Name = "col3Altura"
        Me.col3Altura.Visible = False
        '
        'col3SenalAltura
        '
        Me.col3SenalAltura.HeaderText = "Señal Altura"
        Me.col3SenalAltura.Name = "col3SenalAltura"
        Me.col3SenalAltura.Visible = False
        '
        'col3SenalBaliza
        '
        Me.col3SenalBaliza.HeaderText = "Sañal Baliza"
        Me.col3SenalBaliza.Name = "col3SenalBaliza"
        Me.col3SenalBaliza.Visible = False
        '
        'col3Tarjeta
        '
        Me.col3Tarjeta.HeaderText = "Tarjeta"
        Me.col3Tarjeta.Name = "col3Tarjeta"
        Me.col3Tarjeta.Visible = False
        '
        'col3Precinto
        '
        Me.col3Precinto.HeaderText = "Precinto"
        Me.col3Precinto.Name = "col3Precinto"
        Me.col3Precinto.Visible = False
        '
        'col3Soporte
        '
        Me.col3Soporte.HeaderText = "Soporte"
        Me.col3Soporte.Name = "col3Soporte"
        Me.col3Soporte.Visible = False
        '
        'col3Ruptura
        '
        Me.col3Ruptura.HeaderText = "Ruptura"
        Me.col3Ruptura.Name = "col3Ruptura"
        Me.col3Ruptura.Visible = False
        '
        'col3Manguera
        '
        Me.col3Manguera.HeaderText = "Manguera"
        Me.col3Manguera.Name = "col3Manguera"
        Me.col3Manguera.Visible = False
        '
        'col3Otro
        '
        Me.col3Otro.HeaderText = "Otro"
        Me.col3Otro.Name = "col3Otro"
        Me.col3Otro.Visible = False
        '
        'col3Valvula
        '
        Me.col3Valvula.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3Valvula.HeaderText = "Valvula"
        Me.col3Valvula.Name = "col3Valvula"
        Me.col3Valvula.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Valvula.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3Pico
        '
        Me.col3Pico.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3Pico.HeaderText = "Pico"
        Me.col3Pico.Name = "col3Pico"
        Me.col3Pico.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Pico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3Lanza
        '
        Me.col3Lanza.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3Lanza.HeaderText = "Lanza"
        Me.col3Lanza.Name = "col3Lanza"
        Me.col3Lanza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Lanza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3Vidrio
        '
        Me.col3Vidrio.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3Vidrio.HeaderText = "Vidrio"
        Me.col3Vidrio.Name = "col3Vidrio"
        Me.col3Vidrio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Vidrio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3Llave
        '
        Me.col3Llave.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.col3Llave.HeaderText = "Llave"
        Me.col3Llave.Name = "col3Llave"
        Me.col3Llave.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col3Llave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'col3Obs
        '
        Me.col3Obs.HeaderText = "Obs"
        Me.col3Obs.Name = "col3Obs"
        Me.col3Obs.Visible = False
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmar.Location = New System.Drawing.Point(772, 447)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 1
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        Me.btnConfirmar.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(853, 447)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistrar.Location = New System.Drawing.Point(691, 447)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 3
        Me.btnRegistrar.Text = "&Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'frmEditarInspeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(940, 482)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmEditarInspeccion"
        Me.Text = "Confirmación de Inspección"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvExtintores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHidrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvSectores As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnRegistrar As System.Windows.Forms.Button
    Friend WithEvents dgvExtintores As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHidrantes As System.Windows.Forms.DataGridView
    Friend WithEvents col1Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Luz As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col1Cartel As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col1Cinta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col1Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Agente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Capacidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Cilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Vto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Vencido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Ausente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Obstruido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Carro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Usado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Despintado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Despresurizado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Altura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1SenalAltura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1SenalBaliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Tarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Precinto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Soporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Ruptura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Manguera As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Otro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Valvula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Pico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Lanza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Vidrio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Llave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col1Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Luz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cartel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Cinta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Agente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Capacidad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Cilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vencido As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Ausente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Obstruido As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Carro As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Usado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Despintado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Despresurizado As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Altura As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2SenalAltura As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2SenalBaliza As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Tarjeta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Precinto As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Soporte As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Ruptura As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Manguera As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Otro As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col2Valvula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Pico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Lanza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Vidrio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Llave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Intervencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Sector As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Ubicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Luz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Cartel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Cinta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Agente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Capacidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Cilindro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Vto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Vencido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Ausente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Obstruido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Carro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Usado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Despintado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Despresurizado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Altura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3SenalAltura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3SenalBaliza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Tarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Precinto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Soporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Ruptura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Manguera As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Otro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3Valvula As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3Pico As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3Lanza As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3Vidrio As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3Llave As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col3Obs As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
