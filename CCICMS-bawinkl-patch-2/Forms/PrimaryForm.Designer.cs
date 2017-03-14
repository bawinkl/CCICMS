namespace ColorMatchingSystemAPP
{
    partial class primaryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(primaryForm));
            this.logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorTypeDropDown = new System.Windows.Forms.ComboBox();
            this.colorCodeDropDown = new System.Windows.Forms.ComboBox();
            this.UOMDropDown = new System.Windows.Forms.ComboBox();
            this.batchAmountInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.formulaDataGrid = new System.Windows.Forms.DataGridView();
            this.mixingHeaderLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddCustomColor = new System.Windows.Forms.Button();
            this.txtCustomColorCode = new System.Windows.Forms.TextBox();
            this.lblCustomColorCode = new System.Windows.Forms.Label();
            this.saveColorCodeError = new System.Windows.Forms.Label();
            this.btnCancelCustomColor = new System.Windows.Forms.Button();
            this.panelColorSelectors = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCustomColorsWarning = new System.Windows.Forms.Label();
            this.gridViewPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.customColorCodeDropDown = new System.Windows.Forms.ComboBox();
            this.dischargeDataGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteCustomColor = new System.Windows.Forms.Button();
            this.lblPigmentNote = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulaDataGrid)).BeginInit();
            this.panelColorSelectors.SuspendLayout();
            this.gridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dischargeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(374, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(422, 127);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "C. M. S.";
            // 
            // colorTypeDropDown
            // 
            this.colorTypeDropDown.AccessibleName = "colorTypeDropDown";
            this.colorTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorTypeDropDown.FormattingEnabled = true;
            this.colorTypeDropDown.Location = new System.Drawing.Point(11, 29);
            this.colorTypeDropDown.Name = "colorTypeDropDown";
            this.colorTypeDropDown.Size = new System.Drawing.Size(144, 21);
            this.colorTypeDropDown.TabIndex = 2;
            this.colorTypeDropDown.SelectionChangeCommitted += new System.EventHandler(this.colorTypeDropDown_SelectionChangeCommitted);
            // 
            // colorCodeDropDown
            // 
            this.colorCodeDropDown.AccessibleName = "colorCodeDropDown";
            this.colorCodeDropDown.FormattingEnabled = true;
            this.colorCodeDropDown.Location = new System.Drawing.Point(167, 29);
            this.colorCodeDropDown.Name = "colorCodeDropDown";
            this.colorCodeDropDown.Size = new System.Drawing.Size(108, 21);
            this.colorCodeDropDown.TabIndex = 3;
            this.colorCodeDropDown.SelectionChangeCommitted += new System.EventHandler(this.colorCodeDropDown_SelectionChangeCommitted);
            // 
            // UOMDropDown
            // 
            this.UOMDropDown.AccessibleName = "batchAmountDropDown";
            this.UOMDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UOMDropDown.FormattingEnabled = true;
            this.UOMDropDown.Location = new System.Drawing.Point(345, 28);
            this.UOMDropDown.Name = "UOMDropDown";
            this.UOMDropDown.Size = new System.Drawing.Size(115, 21);
            this.UOMDropDown.TabIndex = 5;
            this.UOMDropDown.SelectionChangeCommitted += new System.EventHandler(this.UOMDropDown_SelectionChangeCommitted);
            // 
            // batchAmountInput
            // 
            this.batchAmountInput.AccessibleName = "batchAmountInput";
            this.batchAmountInput.Location = new System.Drawing.Point(288, 29);
            this.batchAmountInput.Name = "batchAmountInput";
            this.batchAmountInput.Size = new System.Drawing.Size(51, 20);
            this.batchAmountInput.TabIndex = 7;
            this.batchAmountInput.Text = "1";
            this.batchAmountInput.TextChanged += new System.EventHandler(this.batchAmountInput_TextChanged);
            this.batchAmountInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batchAmountInput_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ink System:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Color Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Batch Amount:";
            // 
            // formulaDataGrid
            // 
            this.formulaDataGrid.AccessibleName = "colorFormulaDataGrid";
            this.formulaDataGrid.AllowUserToOrderColumns = true;
            this.formulaDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formulaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.formulaDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.formulaDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.formulaDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.formulaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.formulaDataGrid.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.formulaDataGrid.DefaultCellStyle = dataGridViewCellStyle16;
            this.formulaDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.formulaDataGrid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.formulaDataGrid.Location = new System.Drawing.Point(11, 42);
            this.formulaDataGrid.Name = "formulaDataGrid";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.formulaDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.formulaDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.formulaDataGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.formulaDataGrid.ShowEditingIcon = false;
            this.formulaDataGrid.Size = new System.Drawing.Size(783, 178);
            this.formulaDataGrid.TabIndex = 11;
            this.formulaDataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.formulaDataGrid_CellBeginEdit);
            this.formulaDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.formulaDataGrid_CellContentClick);
            this.formulaDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.formulaDataGrid_CellEndEdit);
            this.formulaDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.formulaDataGrid_CellFormatting);
            this.formulaDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.formulaDataGrid_CellValidating);
            this.formulaDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.formulaDataGrid_CellValueChanged);
            this.formulaDataGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.formulaDataGrid_EditingControlShowing);
            // 
            // mixingHeaderLabel
            // 
            this.mixingHeaderLabel.AutoSize = true;
            this.mixingHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mixingHeaderLabel.Location = new System.Drawing.Point(6, 10);
            this.mixingHeaderLabel.Name = "mixingHeaderLabel";
            this.mixingHeaderLabel.Size = new System.Drawing.Size(70, 25);
            this.mixingHeaderLabel.TabIndex = 12;
            this.mixingHeaderLabel.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(318, 48);
            this.label5.TabIndex = 13;
            this.label5.Text = "Color Matching System \r\nWater Based and Discharge Inks ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAddCustomColor
            // 
            this.btnAddCustomColor.AutoSize = true;
            this.btnAddCustomColor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddCustomColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddCustomColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomColor.ForeColor = System.Drawing.Color.Black;
            this.btnAddCustomColor.Location = new System.Drawing.Point(13, 434);
            this.btnAddCustomColor.Name = "btnAddCustomColor";
            this.btnAddCustomColor.Size = new System.Drawing.Size(129, 23);
            this.btnAddCustomColor.TabIndex = 14;
            this.btnAddCustomColor.Tag = "";
            this.btnAddCustomColor.Text = "Customize Color";
            this.btnAddCustomColor.UseVisualStyleBackColor = false;
            this.btnAddCustomColor.Click += new System.EventHandler(this.btnAddCustomColor_Click);
            // 
            // txtCustomColorCode
            // 
            this.txtCustomColorCode.Location = new System.Drawing.Point(164, 302);
            this.txtCustomColorCode.Name = "txtCustomColorCode";
            this.txtCustomColorCode.Size = new System.Drawing.Size(214, 20);
            this.txtCustomColorCode.TabIndex = 15;
            this.txtCustomColorCode.Text = "[ Enter Color Code ]";
            this.txtCustomColorCode.Visible = false;
            // 
            // lblCustomColorCode
            // 
            this.lblCustomColorCode.AutoSize = true;
            this.lblCustomColorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomColorCode.Location = new System.Drawing.Point(10, 460);
            this.lblCustomColorCode.Name = "lblCustomColorCode";
            this.lblCustomColorCode.Size = new System.Drawing.Size(123, 17);
            this.lblCustomColorCode.TabIndex = 16;
            this.lblCustomColorCode.Text = "New Color Code";
            this.lblCustomColorCode.Visible = false;
            // 
            // saveColorCodeError
            // 
            this.saveColorCodeError.AutoSize = true;
            this.saveColorCodeError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveColorCodeError.Location = new System.Drawing.Point(389, 305);
            this.saveColorCodeError.Name = "saveColorCodeError";
            this.saveColorCodeError.Size = new System.Drawing.Size(35, 13);
            this.saveColorCodeError.TabIndex = 17;
            this.saveColorCodeError.Text = "label6";
            this.saveColorCodeError.Visible = false;
            // 
            // btnCancelCustomColor
            // 
            this.btnCancelCustomColor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelCustomColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCustomColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelCustomColor.Location = new System.Drawing.Point(148, 434);
            this.btnCancelCustomColor.Name = "btnCancelCustomColor";
            this.btnCancelCustomColor.Size = new System.Drawing.Size(93, 23);
            this.btnCancelCustomColor.TabIndex = 18;
            this.btnCancelCustomColor.Text = "Cancel";
            this.btnCancelCustomColor.UseVisualStyleBackColor = false;
            this.btnCancelCustomColor.Visible = false;
            this.btnCancelCustomColor.Click += new System.EventHandler(this.btnCancelCustomColor_Click);
            // 
            // panelColorSelectors
            // 
            this.panelColorSelectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColorSelectors.Controls.Add(this.btnSave);
            this.panelColorSelectors.Controls.Add(this.label2);
            this.panelColorSelectors.Controls.Add(this.colorTypeDropDown);
            this.panelColorSelectors.Controls.Add(this.btnPrint);
            this.panelColorSelectors.Controls.Add(this.label3);
            this.panelColorSelectors.Controls.Add(this.colorCodeDropDown);
            this.panelColorSelectors.Controls.Add(this.batchAmountInput);
            this.panelColorSelectors.Controls.Add(this.UOMDropDown);
            this.panelColorSelectors.Controls.Add(this.label4);
            this.panelColorSelectors.Location = new System.Drawing.Point(2, 139);
            this.panelColorSelectors.Name = "panelColorSelectors";
            this.panelColorSelectors.Size = new System.Drawing.Size(805, 67);
            this.panelColorSelectors.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(578, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save Label";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(689, 26);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 23);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "Print Label";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(10, 593);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Need Help?";
            this.label6.Click += new System.EventHandler(this.label6_Click_2);
            // 
            // lblCustomColorsWarning
            // 
            this.lblCustomColorsWarning.AutoSize = true;
            this.lblCustomColorsWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomColorsWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCustomColorsWarning.Location = new System.Drawing.Point(69, 115);
            this.lblCustomColorsWarning.Name = "lblCustomColorsWarning";
            this.lblCustomColorsWarning.Size = new System.Drawing.Size(258, 24);
            this.lblCustomColorsWarning.TabIndex = 20;
            this.lblCustomColorsWarning.Text = "Custom Color Mode Active";
            this.lblCustomColorsWarning.Visible = false;
            // 
            // gridViewPanel
            // 
            this.gridViewPanel.Controls.Add(this.label7);
            this.gridViewPanel.Controls.Add(this.customColorCodeDropDown);
            this.gridViewPanel.Controls.Add(this.dischargeDataGrid);
            this.gridViewPanel.Controls.Add(this.txtCustomColorCode);
            this.gridViewPanel.Controls.Add(this.saveColorCodeError);
            this.gridViewPanel.Controls.Add(this.btnDeleteCustomColor);
            this.gridViewPanel.Controls.Add(this.lblPigmentNote);
            this.gridViewPanel.Controls.Add(this.formulaDataGrid);
            this.gridViewPanel.Controls.Add(this.mixingHeaderLabel);
            this.gridViewPanel.Location = new System.Drawing.Point(2, 199);
            this.gridViewPanel.Name = "gridViewPanel";
            this.gridViewPanel.Size = new System.Drawing.Size(805, 391);
            this.gridViewPanel.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(350, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Choose an existing color code name or enter a new one below:";
            this.label7.Visible = false;
            // 
            // customColorCodeDropDown
            // 
            this.customColorCodeDropDown.AccessibleName = "customColorCodeDropDown";
            this.customColorCodeDropDown.FormattingEnabled = true;
            this.customColorCodeDropDown.Location = new System.Drawing.Point(10, 302);
            this.customColorCodeDropDown.Name = "customColorCodeDropDown";
            this.customColorCodeDropDown.Size = new System.Drawing.Size(145, 21);
            this.customColorCodeDropDown.TabIndex = 25;
            this.customColorCodeDropDown.Visible = false;
            this.customColorCodeDropDown.SelectedIndexChanged += new System.EventHandler(this.customColorCodeDropDown_SelectedIndexChanged);
            // 
            // dischargeDataGrid
            // 
            this.dischargeDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dischargeDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.dischargeDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dischargeDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dischargeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dischargeDataGrid.GridColor = System.Drawing.Color.Black;
            this.dischargeDataGrid.Location = new System.Drawing.Point(430, 226);
            this.dischargeDataGrid.Name = "dischargeDataGrid";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dischargeDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            this.dischargeDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dischargeDataGrid.Size = new System.Drawing.Size(364, 124);
            this.dischargeDataGrid.TabIndex = 24;
            this.dischargeDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dischargeDataGrid_CellContentClick);
            // 
            // btnDeleteCustomColor
            // 
            this.btnDeleteCustomColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteCustomColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomColor.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCustomColor.Location = new System.Drawing.Point(10, 330);
            this.btnDeleteCustomColor.Name = "btnDeleteCustomColor";
            this.btnDeleteCustomColor.Size = new System.Drawing.Size(186, 23);
            this.btnDeleteCustomColor.TabIndex = 18;
            this.btnDeleteCustomColor.Text = "Delete Custom Color";
            this.btnDeleteCustomColor.UseVisualStyleBackColor = false;
            this.btnDeleteCustomColor.Visible = false;
            this.btnDeleteCustomColor.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblPigmentNote
            // 
            this.lblPigmentNote.AutoSize = true;
            this.lblPigmentNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPigmentNote.Location = new System.Drawing.Point(10, 218);
            this.lblPigmentNote.Name = "lblPigmentNote";
            this.lblPigmentNote.Size = new System.Drawing.Size(266, 13);
            this.lblPigmentNote.TabIndex = 22;
            this.lblPigmentNote.Text = "* DO NOT use more then a 30% pigment load.";
            this.lblPigmentNote.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(676, 591);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(128, 18);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.ccidom.com";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // primaryForm
            // 
            this.AccessibleName = "CMS";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(808, 618);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCustomColorsWarning);
            this.Controls.Add(this.lblCustomColorCode);
            this.Controls.Add(this.panelColorSelectors);
            this.Controls.Add(this.btnCancelCustomColor);
            this.Controls.Add(this.btnAddCustomColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.gridViewPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "primaryForm";
            this.Text = "CMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formulaDataGrid)).EndInit();
            this.panelColorSelectors.ResumeLayout(false);
            this.panelColorSelectors.PerformLayout();
            this.gridViewPanel.ResumeLayout(false);
            this.gridViewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dischargeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorTypeDropDown;
        private System.Windows.Forms.ComboBox colorCodeDropDown;
        private System.Windows.Forms.ComboBox UOMDropDown;
        private System.Windows.Forms.TextBox batchAmountInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView formulaDataGrid;
        private System.Windows.Forms.Label mixingHeaderLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddCustomColor;
        private System.Windows.Forms.TextBox txtCustomColorCode;
        private System.Windows.Forms.Label lblCustomColorCode;
        private System.Windows.Forms.Label saveColorCodeError;
        private System.Windows.Forms.Button btnCancelCustomColor;
        private System.Windows.Forms.Panel panelColorSelectors;
        private System.Windows.Forms.Label lblCustomColorsWarning;
        private System.Windows.Forms.Panel gridViewPanel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDeleteCustomColor;
        private System.Windows.Forms.Label lblPigmentNote;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dischargeDataGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox customColorCodeDropDown;
    }
}

