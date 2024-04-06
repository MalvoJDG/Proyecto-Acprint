namespace Prototipo_Ana.Forms
{
    partial class Facturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuVScrollBar2 = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.dtaFactura = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.txtFiltro = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnborrar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.cbmEstado = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btnConfirmar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtaFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Poppins", 16.2F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(48, 26);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(123, 48);
            this.bunifuLabel3.TabIndex = 69;
            this.bunifuLabel3.Text = "Facturas";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuVScrollBar2
            // 
            this.bunifuVScrollBar2.AllowCursorChanges = true;
            this.bunifuVScrollBar2.AllowHomeEndKeysDetection = false;
            this.bunifuVScrollBar2.AllowIncrementalClickMoves = true;
            this.bunifuVScrollBar2.AllowMouseDownEffects = true;
            this.bunifuVScrollBar2.AllowMouseHoverEffects = true;
            this.bunifuVScrollBar2.AllowScrollingAnimations = true;
            this.bunifuVScrollBar2.AllowScrollKeysDetection = true;
            this.bunifuVScrollBar2.AllowScrollOptionsMenu = true;
            this.bunifuVScrollBar2.AllowShrinkingOnFocusLost = false;
            this.bunifuVScrollBar2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.bunifuVScrollBar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuVScrollBar2.BackgroundImage")));
            this.bunifuVScrollBar2.BindingContainer = null;
            this.bunifuVScrollBar2.BorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.BorderRadius = 6;
            this.bunifuVScrollBar2.BorderThickness = 2;
            this.bunifuVScrollBar2.DurationBeforeShrink = 2000;
            this.bunifuVScrollBar2.LargeChange = 5;
            this.bunifuVScrollBar2.Location = new System.Drawing.Point(1152, 192);
            this.bunifuVScrollBar2.Maximum = 100;
            this.bunifuVScrollBar2.Minimum = 0;
            this.bunifuVScrollBar2.MinimumThumbLength = 18;
            this.bunifuVScrollBar2.Name = "bunifuVScrollBar2";
            this.bunifuVScrollBar2.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuVScrollBar2.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar2.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.bunifuVScrollBar2.ShrinkSizeLimit = 3;
            this.bunifuVScrollBar2.Size = new System.Drawing.Size(30, 413);
            this.bunifuVScrollBar2.SmallChange = 1;
            this.bunifuVScrollBar2.TabIndex = 99;
            this.bunifuVScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.bunifuVScrollBar2.ThumbLength = 20;
            this.bunifuVScrollBar2.ThumbMargin = 1;
            this.bunifuVScrollBar2.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar2.Value = 0;
            this.bunifuVScrollBar2.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bunifuVScrollBar2_Scroll);
            // 
            // dtaFactura
            // 
            this.dtaFactura.AllowCustomTheming = false;
            this.dtaFactura.AllowUserToAddRows = false;
            this.dtaFactura.AllowUserToDeleteRows = false;
            this.dtaFactura.AllowUserToResizeColumns = false;
            this.dtaFactura.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dtaFactura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtaFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtaFactura.BackgroundColor = System.Drawing.Color.White;
            this.dtaFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtaFactura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtaFactura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtaFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtaFactura.ColumnHeadersHeight = 40;
            this.dtaFactura.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dtaFactura.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtaFactura.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtaFactura.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtaFactura.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtaFactura.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dtaFactura.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dtaFactura.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dtaFactura.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dtaFactura.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtaFactura.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dtaFactura.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtaFactura.CurrentTheme.Name = null;
            this.dtaFactura.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtaFactura.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtaFactura.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dtaFactura.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dtaFactura.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtaFactura.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtaFactura.EnableHeadersVisualStyles = false;
            this.dtaFactura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dtaFactura.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dtaFactura.HeaderBgColor = System.Drawing.Color.Empty;
            this.dtaFactura.HeaderForeColor = System.Drawing.Color.White;
            this.dtaFactura.Location = new System.Drawing.Point(48, 160);
            this.dtaFactura.Name = "dtaFactura";
            this.dtaFactura.ReadOnly = true;
            this.dtaFactura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtaFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtaFactura.RowHeadersVisible = false;
            this.dtaFactura.RowHeadersWidth = 51;
            this.dtaFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dtaFactura.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtaFactura.RowTemplate.Height = 40;
            this.dtaFactura.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtaFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtaFactura.Size = new System.Drawing.Size(1101, 445);
            this.dtaFactura.TabIndex = 98;
            this.dtaFactura.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dtaFactura.DoubleClick += new System.EventHandler(this.dtaFactura_DoubleClick_1);
            // 
            // txtFiltro
            // 
            this.txtFiltro.AcceptsReturn = false;
            this.txtFiltro.AcceptsTab = false;
            this.txtFiltro.AnimationSpeed = 200;
            this.txtFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtFiltro.AutoSizeHeight = true;
            this.txtFiltro.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtFiltro.BackgroundImage")));
            this.txtFiltro.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtFiltro.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtFiltro.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtFiltro.BorderColorIdle = System.Drawing.Color.Transparent;
            this.txtFiltro.BorderRadius = 20;
            this.txtFiltro.BorderThickness = 1;
            this.txtFiltro.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.DefaultFont = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.DefaultText = "";
            this.txtFiltro.FillColor = System.Drawing.Color.White;
            this.txtFiltro.HideSelection = true;
            this.txtFiltro.IconLeft = null;
            this.txtFiltro.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.IconPadding = 10;
            this.txtFiltro.IconRight = null;
            this.txtFiltro.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiltro.Lines = new string[0];
            this.txtFiltro.Location = new System.Drawing.Point(48, 97);
            this.txtFiltro.MaxLength = 32767;
            this.txtFiltro.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFiltro.Modified = false;
            this.txtFiltro.Multiline = false;
            this.txtFiltro.Name = "txtFiltro";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFiltro.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Transparent;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFiltro.OnIdleState = stateProperties8;
            this.txtFiltro.Padding = new System.Windows.Forms.Padding(3);
            this.txtFiltro.PasswordChar = '\0';
            this.txtFiltro.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFiltro.PlaceholderText = "Buscar";
            this.txtFiltro.ReadOnly = false;
            this.txtFiltro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFiltro.SelectedText = "";
            this.txtFiltro.SelectionLength = 0;
            this.txtFiltro.SelectionStart = 0;
            this.txtFiltro.ShortcutsEnabled = true;
            this.txtFiltro.Size = new System.Drawing.Size(346, 38);
            this.txtFiltro.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtFiltro.TabIndex = 100;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFiltro.TextMarginBottom = 0;
            this.txtFiltro.TextMarginLeft = 3;
            this.txtFiltro.TextMarginTop = 1;
            this.txtFiltro.TextPlaceholder = "Buscar";
            this.txtFiltro.UseSystemPasswordChar = false;
            this.txtFiltro.WordWrap = true;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged_1);
            // 
            // btnborrar
            // 
            this.btnborrar.AllowAnimations = true;
            this.btnborrar.AllowMouseEffects = true;
            this.btnborrar.AllowToggling = false;
            this.btnborrar.AnimationSpeed = 200;
            this.btnborrar.AutoGenerateColors = false;
            this.btnborrar.AutoRoundBorders = false;
            this.btnborrar.AutoSizeLeftIcon = true;
            this.btnborrar.AutoSizeRightIcon = true;
            this.btnborrar.BackColor = System.Drawing.Color.Transparent;
            this.btnborrar.BackColor1 = System.Drawing.Color.Red;
            this.btnborrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnborrar.BackgroundImage")));
            this.btnborrar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnborrar.ButtonText = "volver";
            this.btnborrar.ButtonTextMarginLeft = 0;
            this.btnborrar.ColorContrastOnClick = 45;
            this.btnborrar.ColorContrastOnHover = 45;
            this.btnborrar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnborrar.CustomizableEdges = borderEdges3;
            this.btnborrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnborrar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnborrar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnborrar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnborrar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Disabled;
            this.btnborrar.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnborrar.ForeColor = System.Drawing.Color.White;
            this.btnborrar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnborrar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnborrar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnborrar.IconMarginLeft = 11;
            this.btnborrar.IconPadding = 10;
            this.btnborrar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnborrar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnborrar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnborrar.IconSize = 25;
            this.btnborrar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnborrar.IdleBorderRadius = 20;
            this.btnborrar.IdleBorderThickness = 1;
            this.btnborrar.IdleFillColor = System.Drawing.Color.Red;
            this.btnborrar.IdleIconLeftImage = null;
            this.btnborrar.IdleIconRightImage = null;
            this.btnborrar.IndicateFocus = false;
            this.btnborrar.Location = new System.Drawing.Point(411, 101);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnborrar.OnDisabledState.BorderRadius = 20;
            this.btnborrar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnborrar.OnDisabledState.BorderThickness = 1;
            this.btnborrar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnborrar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnborrar.OnDisabledState.IconLeftImage = null;
            this.btnborrar.OnDisabledState.IconRightImage = null;
            this.btnborrar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnborrar.onHoverState.BorderRadius = 20;
            this.btnborrar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnborrar.onHoverState.BorderThickness = 1;
            this.btnborrar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnborrar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnborrar.onHoverState.IconLeftImage = null;
            this.btnborrar.onHoverState.IconRightImage = null;
            this.btnborrar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnborrar.OnIdleState.BorderRadius = 20;
            this.btnborrar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnborrar.OnIdleState.BorderThickness = 1;
            this.btnborrar.OnIdleState.FillColor = System.Drawing.Color.Red;
            this.btnborrar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnborrar.OnIdleState.IconLeftImage = null;
            this.btnborrar.OnIdleState.IconRightImage = null;
            this.btnborrar.OnPressedState.BorderColor = System.Drawing.Color.Red;
            this.btnborrar.OnPressedState.BorderRadius = 20;
            this.btnborrar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnborrar.OnPressedState.BorderThickness = 1;
            this.btnborrar.OnPressedState.FillColor = System.Drawing.Color.Red;
            this.btnborrar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnborrar.OnPressedState.IconLeftImage = null;
            this.btnborrar.OnPressedState.IconRightImage = null;
            this.btnborrar.Size = new System.Drawing.Size(119, 29);
            this.btnborrar.TabIndex = 101;
            this.btnborrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnborrar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnborrar.TextMarginLeft = 0;
            this.btnborrar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnborrar.UseDefaultRadiusAndThickness = true;
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click_1);
            // 
            // cbmEstado
            // 
            this.cbmEstado.BackColor = System.Drawing.Color.Transparent;
            this.cbmEstado.BackgroundColor = System.Drawing.Color.White;
            this.cbmEstado.BorderColor = System.Drawing.Color.Silver;
            this.cbmEstado.BorderRadius = 10;
            this.cbmEstado.Color = System.Drawing.Color.Silver;
            this.cbmEstado.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cbmEstado.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbmEstado.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbmEstado.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbmEstado.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cbmEstado.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cbmEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbmEstado.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cbmEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmEstado.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbmEstado.FillDropDown = true;
            this.cbmEstado.FillIndicator = false;
            this.cbmEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbmEstado.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.cbmEstado.FormattingEnabled = true;
            this.cbmEstado.Icon = null;
            this.cbmEstado.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbmEstado.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cbmEstado.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbmEstado.IndicatorThickness = 2;
            this.cbmEstado.IsDropdownOpened = false;
            this.cbmEstado.ItemBackColor = System.Drawing.Color.White;
            this.cbmEstado.ItemBorderColor = System.Drawing.Color.White;
            this.cbmEstado.ItemForeColor = System.Drawing.Color.Black;
            this.cbmEstado.ItemHeight = 26;
            this.cbmEstado.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cbmEstado.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cbmEstado.Items.AddRange(new object[] {
            "Pagada",
            "Pendiente"});
            this.cbmEstado.ItemTopMargin = 3;
            this.cbmEstado.Location = new System.Drawing.Point(48, 620);
            this.cbmEstado.Name = "cbmEstado";
            this.cbmEstado.Size = new System.Drawing.Size(190, 32);
            this.cbmEstado.TabIndex = 102;
            this.cbmEstado.Text = null;
            this.cbmEstado.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbmEstado.TextLeftMargin = 5;
            this.cbmEstado.SelectedIndexChanged += new System.EventHandler(this.cbmEstado_SelectedIndexChanged_1);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AllowAnimations = true;
            this.btnConfirmar.AllowMouseEffects = true;
            this.btnConfirmar.AllowToggling = false;
            this.btnConfirmar.AnimationSpeed = 200;
            this.btnConfirmar.AutoGenerateColors = false;
            this.btnConfirmar.AutoRoundBorders = false;
            this.btnConfirmar.AutoSizeLeftIcon = true;
            this.btnConfirmar.AutoSizeRightIcon = true;
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnConfirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.BackgroundImage")));
            this.btnConfirmar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirmar.ButtonText = "Confimar";
            this.btnConfirmar.ButtonTextMarginLeft = 0;
            this.btnConfirmar.ColorContrastOnClick = 45;
            this.btnConfirmar.ColorContrastOnHover = 45;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnConfirmar.CustomizableEdges = borderEdges4;
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirmar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirmar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirmar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirmar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Disabled;
            this.btnConfirmar.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirmar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnConfirmar.IconMarginLeft = 11;
            this.btnConfirmar.IconPadding = 10;
            this.btnConfirmar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirmar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnConfirmar.IconSize = 25;
            this.btnConfirmar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.IdleBorderRadius = 20;
            this.btnConfirmar.IdleBorderThickness = 1;
            this.btnConfirmar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnConfirmar.IdleIconLeftImage = null;
            this.btnConfirmar.IdleIconRightImage = null;
            this.btnConfirmar.IndicateFocus = false;
            this.btnConfirmar.Location = new System.Drawing.Point(259, 622);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirmar.OnDisabledState.BorderRadius = 20;
            this.btnConfirmar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirmar.OnDisabledState.BorderThickness = 1;
            this.btnConfirmar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirmar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirmar.OnDisabledState.IconLeftImage = null;
            this.btnConfirmar.OnDisabledState.IconRightImage = null;
            this.btnConfirmar.onHoverState.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.onHoverState.BorderRadius = 20;
            this.btnConfirmar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirmar.onHoverState.BorderThickness = 1;
            this.btnConfirmar.onHoverState.FillColor = System.Drawing.Color.White;
            this.btnConfirmar.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.onHoverState.IconLeftImage = null;
            this.btnConfirmar.onHoverState.IconRightImage = null;
            this.btnConfirmar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.OnIdleState.BorderRadius = 20;
            this.btnConfirmar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirmar.OnIdleState.BorderThickness = 1;
            this.btnConfirmar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnConfirmar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.OnIdleState.IconLeftImage = null;
            this.btnConfirmar.OnIdleState.IconRightImage = null;
            this.btnConfirmar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnConfirmar.OnPressedState.BorderRadius = 20;
            this.btnConfirmar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirmar.OnPressedState.BorderThickness = 1;
            this.btnConfirmar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(51)))));
            this.btnConfirmar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.OnPressedState.IconLeftImage = null;
            this.btnConfirmar.OnPressedState.IconRightImage = null;
            this.btnConfirmar.Size = new System.Drawing.Size(161, 30);
            this.btnConfirmar.TabIndex = 103;
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirmar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnConfirmar.TextMarginLeft = 0;
            this.btnConfirmar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnConfirmar.UseDefaultRadiusAndThickness = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(359, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1214, 739);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbmEstado);
            this.Controls.Add(this.btnborrar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.bunifuVScrollBar2);
            this.Controls.Add(this.dtaFactura);
            this.Controls.Add(this.bunifuLabel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Facturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas";
            this.Load += new System.EventHandler(this.Facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtaFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar2;
        private Bunifu.UI.WinForms.BunifuDataGridView dtaFactura;
        private Bunifu.UI.WinForms.BunifuTextBox txtFiltro;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnborrar;
        private Bunifu.UI.WinForms.BunifuDropdown cbmEstado;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnConfirmar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}