using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColorMatchingSystem.Models;
using System.Reflection;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using ColorMatchingSystemAPP.Managers;

namespace ColorMatchingSystemAPP
{
    public partial class primaryForm : Form
    {
        public List<Color> customColorList;
        bool customMode = false;
        PrintDocument pd = new PrintDocument();
        bool alreadyFocused;
        bool bindingList;
        bool allowValidate;
       
        #region Printing

        /* Printing */
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private System.Drawing.Bitmap memoryImage;

        private void CaptureScreen()
        {
            System.Drawing.Color formulaGridBackgroundColor = this.formulaDataGrid.BackgroundColor;
            System.Drawing.Color originalBackColor = this.gridViewPanel.BackColor;
            System.Drawing.Color originalForeColor = this.gridViewPanel.ForeColor;

            formulaDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            formulaDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            formulaDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");

            dischargeDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dischargeDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            dischargeDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            dischargeDataGrid.BackgroundColor = System.Drawing.Color.White;

            bool vlblPigmentNote = lblPigmentNote.Visible;
            bool vbtnAddCustomColor = btnAddCustomColor.Visible;
            bool vbtnCancelCustomColor = btnCancelCustomColor.Visible;
            bool vlblCustomColorCode = lblCustomColorCode.Visible;
            bool vtxtCustomColorCode = txtCustomColorCode.Visible;
            bool vsaveColorCodeError = saveColorCodeError.Visible;
            bool vbtnDeleteCustomColor = btnDeleteCustomColor.Visible;

            lblPigmentNote.Visible = false;
            btnAddCustomColor.Visible = false;
            btnCancelCustomColor.Visible = false;
            lblCustomColorCode.Visible = false;
            txtCustomColorCode.Visible = false;
            saveColorCodeError.Visible = false;
            btnDeleteCustomColor.Visible = false;

            foreach (DataGridViewCell c in this.formulaDataGrid.SelectedCells)
            {
                c.Selected = false;
            }

            foreach (DataGridViewCell c in this.dischargeDataGrid.SelectedCells)
            {
                c.Selected = false;
            }

            this.gridViewPanel.BackColor = System.Drawing.Color.White;
            this.gridViewPanel.ForeColor = System.Drawing.Color.Black;
            this.formulaDataGrid.BackgroundColor = System.Drawing.Color.White;

            this.gridViewPanel.Refresh();
            formulaDataGrid.Refresh();

            System.Drawing.Graphics mygraphics = this.gridViewPanel.CreateGraphics();
            System.Drawing.Size s = this.gridViewPanel.Size;
            memoryImage = new System.Drawing.Bitmap(s.Width, s.Height, mygraphics);
            System.Drawing.Graphics memoryGraphics = System.Drawing.Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.gridViewPanel.ClientRectangle.Width, this.gridViewPanel.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);

            formulaDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            formulaDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            formulaDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");

            dischargeDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dischargeDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            dischargeDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            dischargeDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(47,47,47);

            this.gridViewPanel.BackColor = originalBackColor;
            this.gridViewPanel.ForeColor = originalForeColor;
            this.formulaDataGrid.BackgroundColor = formulaGridBackgroundColor;

            lblPigmentNote.Visible = vlblPigmentNote;
            btnAddCustomColor.Visible = vbtnAddCustomColor;
            btnCancelCustomColor.Visible = vbtnCancelCustomColor;
            lblCustomColorCode.Visible = vlblCustomColorCode;
            txtCustomColorCode.Visible = vtxtCustomColorCode;
            saveColorCodeError.Visible = vsaveColorCodeError;
            btnDeleteCustomColor.Visible = vbtnDeleteCustomColor;

            this.gridViewPanel.Refresh();
            formulaDataGrid.Refresh();
        }

        private void pd_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            CaptureScreen();
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = pd;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            printDialog1.PrintToFile = false;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        #endregion

        public primaryForm()
        {
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            customColorList = new List<Color>();
            InitializeComponent();
            LoadColorList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly _assembly;
            Stream _imageStream;
            _assembly = Assembly.GetExecutingAssembly();
            _imageStream = _assembly.GetManifestResourceStream("ColorMatchingSystemAPP.Resources.Logos." + COMMON.Common.ConfigVariable("LogoFileName"));
            logo.Image = new System.Drawing.Bitmap(_imageStream);

            ColorManager colorManager = new ColorManager();
            Dictionary<string, string> colorTypes = colorManager.ListColorTypes();
            Dictionary<string, string> unitsOfMeasurement = colorManager.ListUnitsOfMeasurement();

            colorTypeDropDown.DataSource = new BindingSource(colorTypes, null);
            colorTypeDropDown.ValueMember = "Key";
            colorTypeDropDown.DisplayMember = "Value";

            UOMDropDown.DataSource = new BindingSource(unitsOfMeasurement, null);
            UOMDropDown.ValueMember = "Key";
            UOMDropDown.DisplayMember = "Value";

            BindColorList();
            LoadColorList();
            BindDataGrid();

            txtCustomColorCode.GotFocus += txtCustomColorCode_GotFocus;
            txtCustomColorCode.Leave += txtCustomColorCode_Leave;
            txtCustomColorCode.MouseUp += txtCustomColorCode_MouseUp;
        }

        void txtCustomColorCode_Leave(object sender, EventArgs e)
        {
            alreadyFocused = false;
        }

        void txtCustomColorCode_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons == MouseButtons.None)
            {
                this.txtCustomColorCode.SelectAll();
                alreadyFocused = true;
            }
        }

        void txtCustomColorCode_MouseUp(object sender, MouseEventArgs e)
        {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (!alreadyFocused && this.txtCustomColorCode.SelectionLength == 0)
            {
                alreadyFocused = true;
                this.txtCustomColorCode.SelectAll();
            }
        }

        private void BindDataGrid()
        {
            bindingList = true;
            ColorManager colorManager = new ColorManager();
            List<Color> colorList = new List<Color>();

            string mixingHeader = "Mixing formula for ";
            string colorType = colorTypeDropDown.SelectedValue.ToString();
            string colorCode = colorCodeDropDown.SelectedValue != null ? colorCodeDropDown.SelectedValue.ToString() : (!String.IsNullOrEmpty(colorCodeDropDown.Text) ? colorCodeDropDown.Text : string.Empty); //  !String.IsNullOrEmpty(colorCodeDropDown.SelectedValue.ToString()) ? colorCodeDropDown.SelectedValue.ToString() : string.Empty;
            decimal amount = Decimal.Parse(batchAmountInput.Text);
            string UOM = UOMDropDown.SelectedValue.ToString();

            if (colorType == "Ready For Use")
                btnAddCustomColor.Visible = false;
            else
                btnAddCustomColor.Visible = true;

            if (colorType == "Custom" && !customMode)
                btnDeleteCustomColor.Visible = true;
            else
                btnDeleteCustomColor.Visible = false;

            
                dischargeDataGrid.DefaultCellStyle.Format = "n2";
                dischargeDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dischargeDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
                dischargeDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
                dischargeDataGrid.EnableHeadersVisualStyles = false;
                dischargeDataGrid.AllowUserToAddRows = false;
                decimal requestAmountMultiplier = 1.0M;

                if (!String.IsNullOrEmpty(UOM))
                {
                    switch (UOM)
                    {
                        case "KILOGRAMS":
                            requestAmountMultiplier = 1000.0M;
                            break;
                        case "POUNDS":
                            requestAmountMultiplier = 453.59237M;
                            break;
                    }
                }

                decimal requestAmountInGrams = Math.Round(amount * requestAmountMultiplier, 4);

                List<DischargeCalcuation> calculationList = new List<DischargeCalcuation>();
                
                DischargeCalcuation calc04 = new DischargeCalcuation();
                DischargeCalcuation calc05 = new DischargeCalcuation();
                DischargeCalcuation calc06 = new DischargeCalcuation();

                calc04.rowName = "Discharge Activator @ 4%";
                calc05.rowName = "Discharge Activator @ 5%";
                calc06.rowName = "Discharge Activator @ 6%";

                calc04.calculatedGrams = Math.Round(.04M * requestAmountInGrams, 2);
                calc04.calculatedKilograms = Math.Round((.04M * requestAmountInGrams) / 1000.0M, 2);
                calc04.calculatedPounds = Math.Round((.04M * requestAmountInGrams) / 453.59237M, 2);

                calc05.calculatedGrams = Math.Round(.05M * requestAmountInGrams, 2);
                calc05.calculatedKilograms = Math.Round((.05M * requestAmountInGrams) / 1000.0M, 2);
                calc05.calculatedPounds = Math.Round((.05M * requestAmountInGrams) / 453.59237M, 2);

                calc06.calculatedGrams = Math.Round(.06M * requestAmountInGrams, 2);
                calc06.calculatedKilograms = Math.Round((.06M * requestAmountInGrams) / 1000.0M, 2);
                calc06.calculatedPounds = Math.Round((.06M * requestAmountInGrams) / 453.59237M, 2);

                calculationList.Add(calc04);
                calculationList.Add(calc05);
                calculationList.Add(calc06);

                dischargeDataGrid.DataSource = new BindingList<DischargeCalcuation>(calculationList);

                dischargeDataGrid.Columns[0].HeaderText = "Add 4-6% Discharge Activator";
                dischargeDataGrid.Columns[1].HeaderText = "Grams (g)";
                dischargeDataGrid.Columns[2].HeaderText = "Kilograms (kg)";
                dischargeDataGrid.Columns[3].HeaderText = "Pounds (lbs)";

                dischargeDataGrid.ReadOnly = true;

                if (UOM == "KILOGRAMS")
                {
                    dischargeDataGrid.Columns[1].Visible = false;
                    dischargeDataGrid.Columns[2].Visible = true;
                    dischargeDataGrid.Columns[3].Visible = false;
                }
                else if (UOM == "GRAMS")
                {
                    dischargeDataGrid.Columns[1].Visible = true;
                    dischargeDataGrid.Columns[2].Visible = false;
                    dischargeDataGrid.Columns[3].Visible = false;
                }
                else
                {
                    dischargeDataGrid.Columns[1].Visible = false;
                    dischargeDataGrid.Columns[2].Visible = false;
                    dischargeDataGrid.Columns[3].Visible = true;
                }

                dischargeDataGrid.Refresh();


            mixingHeader += amount.ToString() + " " + (amount <= 1 ? UOMDropDown.SelectedValue.ToString().Substring(0, UOMDropDown.SelectedValue.ToString().Length - 1) : UOMDropDown.SelectedValue.ToString()) + " of " + colorTypeDropDown.GetItemText(colorTypeDropDown.SelectedItem) + " Ink " + colorCode;
            mixingHeaderLabel.Text = mixingHeader;

            formulaDataGrid.DefaultCellStyle.Format = "n2";
            formulaDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            formulaDataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            formulaDataGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#707070");
            formulaDataGrid.EnableHeadersVisualStyles = false;
            formulaDataGrid.AllowUserToAddRows = false;

            if (customMode)
            {
                formulaDataGrid.ReadOnly = false;
                formulaDataGrid.EditMode = DataGridViewEditMode.EditOnEnter;

                customColorCodeDropDown.DataSource = null;
                string selectedColorType = colorTypeDropDown.SelectedValue != null ? colorTypeDropDown.SelectedValue.ToString() : "Water Base";
                List<string> colorCodes = colorManager.ListColorCodes();
                customColorCodeDropDown.DataSource = colorCodes;
                customColorCodeDropDown.Refresh();

                if (customColorList == null || customColorList.FirstOrDefault() == null)
                    customColorList = colorManager.ListColors(colorType, colorCode, amount, UOM);

                colorList = customColorList;
            }
            else
            {
                formulaDataGrid.ReadOnly = true;
                colorList = colorManager.ListColors(colorType, colorCode, amount, UOM);
            }

            List<Color> colorBindingList = new List<Color>(colorList);
            formulaDataGrid.DataSource = new BindingList<Color>(colorList);

            formulaDataGrid.Columns[0].Visible = false;
            formulaDataGrid.Columns[formulaDataGrid.Columns.Count - 1].Visible = false;
            formulaDataGrid.Columns[2].HeaderText = "Color Code";
            formulaDataGrid.Columns[5].HeaderText = "Grams (g)";
            formulaDataGrid.Columns[6].HeaderText = "Kilograms (kg)";
            formulaDataGrid.Columns[7].HeaderText = "Pounds (lbs)";
            formulaDataGrid.Columns[4].DefaultCellStyle.Format = "0.00\\%";
            formulaDataGrid.Columns[4].HeaderText = "Ink Ratio";

            if (customMode)
            {
                formulaDataGrid.Columns[4].DisplayIndex = 4;
                formulaDataGrid.AllowUserToAddRows = true;
                formulaDataGrid.Columns[1].Visible = false;
                formulaDataGrid.Columns[2].Visible = false;
                formulaDataGrid.Columns[5].Visible = false;
                formulaDataGrid.Columns[6].Visible = false;
                formulaDataGrid.Columns[7].Visible = false;
            }
            else
            {
                formulaDataGrid.Columns[4].DisplayIndex = 3;
                formulaDataGrid.AllowUserToAddRows = false;
                formulaDataGrid.Columns[1].Visible = true;
                formulaDataGrid.Columns[2].Visible = true;

                if (UOM == "KILOGRAMS")
                {
                    formulaDataGrid.Columns[5].Visible = false;
                    formulaDataGrid.Columns[6].Visible = true;
                    formulaDataGrid.Columns[7].Visible = false;
                }
                else if (UOM == "GRAMS")
                {
                    formulaDataGrid.Columns[5].Visible = true;
                    formulaDataGrid.Columns[6].Visible = false;
                    formulaDataGrid.Columns[7].Visible = false;
                }
                else
                {
                    formulaDataGrid.Columns[5].Visible = false;
                    formulaDataGrid.Columns[6].Visible = false;
                    formulaDataGrid.Columns[7].Visible = true;
                }

            }

            formulaDataGrid.Refresh();
            bindingList = false;
        }

        private void BindColorList()
        {
            ColorManager colorManager = new ColorManager();
            colorCodeDropDown.DataSource = null;
            string selectedColorType = colorTypeDropDown.SelectedValue != null ? colorTypeDropDown.SelectedValue.ToString() : "Water Base";
            List<string> colorCodes = colorManager.ListColorCodes(selectedColorType);
            colorCodeDropDown.DataSource = colorCodes;
            colorCodeDropDown.Refresh();
        }

        private void LoadColorList()
        {
            try
            {
                colorCodeDropDown.AutoCompleteCustomSource = null;
                string selectedColorType = colorTypeDropDown.SelectedValue != null ? colorTypeDropDown.SelectedValue.ToString() : "Water Base";
                ColorManager colorManager = new ColorManager();
                colorCodeDropDown.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                colorCodeDropDown.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection x = new AutoCompleteStringCollection();
                List<string> colorCodes = colorManager.ListColorCodes(selectedColorType);

                if (colorCodes != null && colorCodes.FirstOrDefault() != null)
                    foreach (string code in colorCodes)
                        x.Add(code);

                colorCodeDropDown.AutoCompleteCustomSource = x;
            }
            catch (Exception ex)
            {
            }
        }

        private void batchAmountInput_TextChanged(object sender, EventArgs e)
        {
            bool rebind = false;
            try
            {
                decimal amount = Decimal.Parse(batchAmountInput.Text);
                rebind = true;
            }
            catch
            {
                rebind = false;
            }

            if (rebind)
                BindDataGrid();
        }

        private void batchAmountInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar)) e.Handled = true;
            else
            {
                bool rebind = false;
                try
                {
                    decimal amount = Decimal.Parse(batchAmountInput.Text);
                    rebind = true;
                }
                catch
                {
                    rebind = false;
                }

                if (rebind)
                    BindDataGrid();
            }
        }

        private void formulaDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            formulaDataGrid[e.ColumnIndex, e.RowIndex].Value = formulaDataGrid[e.ColumnIndex, e.RowIndex].Value.ToString().Replace("%", "");
        }

        private void colorCodeDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void colorTypeDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindColorList();
            BindDataGrid();
        }

        private void UOMDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void formulaDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            e.CellStyle.ForeColor = System.Drawing.Color.Black;
        }

        private void btnAddCustomColor_Click(object sender, EventArgs e)
        {
            if (!customMode)
            {
                customMode = true;
                saveColorCodeError.Visible = false;
                mixingHeaderLabel.Visible = false;
                panelColorSelectors.Visible = false;
                lblCustomColorsWarning.Visible = true;
                btnAddCustomColor.Text = "Save Custom Color";
                btnCancelCustomColor.Visible = true;
                txtCustomColorCode.Visible = true;
                customColorCodeDropDown.Visible = true;
                lblCustomColorCode.Visible = true;
                lblPigmentNote.Visible = true;
                label7.Visible = true;
                //BindColorList();
                BindDataGrid();
            }
            else
            {
                ColorManager colorManager = new ColorManager();

                //try save
                bool saved = false;
                bool valid = true;

                if (String.IsNullOrEmpty(txtCustomColorCode.Text) || txtCustomColorCode.Text.StartsWith("["))
                {
                    saveColorCodeError.Visible = true;
                    saveColorCodeError.Text = "A custom color name is required.";
                    valid = false;
                }

                List<string> existingCodes = colorManager.ListColorCodes();

                if (valid && existingCodes != null && existingCodes.Contains(txtCustomColorCode.Text))
                {
                    saveColorCodeError.Visible = true;
                    saveColorCodeError.Text = "The color code already exists. Please use another.";
                    valid = false;
                }

                float ratio = 0.0f;

                foreach (DataGridViewRow row in formulaDataGrid.Rows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        string inkRatioString = row.Cells[4].Value.ToString();
                        ratio += float.Parse(inkRatioString);
                    }
                }

                if (valid && ratio != 100.0)
                {
                    saveColorCodeError.Visible = true;
                    saveColorCodeError.Text = "The ink ratio must add up to exactly 100%.";
                    valid = false;
                }

                if (valid)
                {
                    List<Color> newColorList = new List<Color>();
                    int currentID = colorManager.GetMaxColorID() + 1;

                    foreach (DataGridViewRow row in formulaDataGrid.Rows)
                    {
                        if (row.Cells[4].Value != null && row.Cells[3].Value != null)
                        {
                            string inkRatioString = row.Cells[4].Value.ToString();
                            string colorName = row.Cells[3].Value.ToString();
                            Color color = new Color();
                            color.type = "Custom";
                            color.id = currentID;
                            color.name = colorName;
                            color.inkRatio = decimal.Parse(inkRatioString);
                            color.colorCode = txtCustomColorCode.Text;
                            newColorList.Add(color);
                            currentID++;
                        }
                    }

                    if (newColorList.Count() > 0)
                    {
                        saved = colorManager.SaveCustomColor(newColorList);
                    }
                }

                if (saved)
                {
                    customMode = false;
                    mixingHeaderLabel.Visible = true;
                    saveColorCodeError.Visible = false;
                    panelColorSelectors.Visible = true;
                    lblCustomColorsWarning.Visible = false;
                    btnAddCustomColor.Text = "Customize Color";
                    btnCancelCustomColor.Visible = false;
                    txtCustomColorCode.Visible = false;
                    customColorCodeDropDown.Visible = false;
                    lblCustomColorCode.Visible = false;
                    lblPigmentNote.Visible = false;
                    label7.Visible = false;

                    Dictionary<string, string> colorTypes = colorManager.ListColorTypes();
                    colorTypeDropDown.DataSource = new BindingSource(colorTypes, null);
                    colorTypeDropDown.ValueMember = "Key";
                    colorTypeDropDown.DisplayMember = "Value";

                    customColorList = null;
                    BindColorList();
                    LoadColorList();
                    BindDataGrid();

                }
                else if (valid)
                {
                    saveColorCodeError.Visible = true;
                    saveColorCodeError.Text = "ERROR: Unable to save custom color.";
                }
            }
        }

        private void btnCancelCustomColor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit custom colors mode and discard unsaved changes?", "Exit Custom Colors", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                customMode = false;
                mixingHeaderLabel.Visible = true;
                saveColorCodeError.Visible = false;
                panelColorSelectors.Visible = true;
                lblCustomColorsWarning.Visible = false;
                btnAddCustomColor.Text = "Customize Color";
                btnCancelCustomColor.Visible = false;
                txtCustomColorCode.Visible = false;
                lblCustomColorCode.Visible = false;
                customColorCodeDropDown.Visible = false;
                lblPigmentNote.Visible = false;
                label7.Visible = false;
                BindDataGrid();
                customColorList = null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.ActiveControl == colorCodeDropDown) && (keyData == Keys.Return))
            {
                BindDataGrid();
                return true;
            }
            else
            {
                return false;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this custom color?", "Delete Custom Color", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string selectedCode = colorCodeDropDown.SelectedItem.ToString();
                ColorManager colorManager = new ColorManager();
                colorManager.DeleteCustomColor(selectedCode);

                List<string> colorList = colorManager.ListColorCodes("Custom");

                if (colorList == null || colorList.FirstOrDefault() == null)
                {
                    Dictionary<string, string> colorTypes = colorManager.ListColorTypes();
                    colorTypeDropDown.DataSource = new BindingSource(colorTypes, null);
                    colorTypeDropDown.ValueMember = "Key";
                    colorTypeDropDown.DisplayMember = "Value";
                }

                BindColorList();
                BindDataGrid();
            }
        }

        private void formulaDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && customMode && customColorList != null && !bindingList)
            {
                decimal total = customColorList.Sum(c => c.inkRatio);
                decimal newValue = (decimal)formulaDataGrid[e.ColumnIndex, e.RowIndex].Value;
                string changedValueName = formulaDataGrid[e.ColumnIndex - 1, e.RowIndex].Value != null ? formulaDataGrid[e.ColumnIndex - 1, e.RowIndex].Value.ToString() : "[NEW COLOR]";

                if (formulaDataGrid[e.ColumnIndex - 1, e.RowIndex].Value == null)
                    formulaDataGrid[e.ColumnIndex - 1, e.RowIndex].Value = "[NEW COLOR]";

                if (total > 100)
                {
                    Color mixingBase = customColorList.Where(c => c.name.Contains("mixing") && c.name.Contains("base")).FirstOrDefault();

                    if (mixingBase == null)
                        mixingBase = customColorList.OrderByDescending(c => c.inkRatio).FirstOrDefault();

                    if (changedValueName != mixingBase.name)
                    {
                        //Recalculate Ratios
                        foreach (Color color in customColorList)
                        {
                            if (color.inkRatio == mixingBase.inkRatio)
                                color.inkRatio = color.inkRatio - newValue;
                        }
                    }
                }

                if (allowValidate)
                    BindDataGrid();
                else
                    allowValidate = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ccidom.com");
        }

        private void label6_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Questions or Comments?\nEmail or call us at:\n\nE: sales@ccidom.com\nP: (951) 735-5511", "Help", MessageBoxButtons.OK);
        }

        private void formulaDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != formulaDataGrid.Rows.Count - 1 && customMode && !bindingList) //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                    e.Cancel = true;
                else
                {
                    string value = e.FormattedValue.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Contains("%"))
                            value = value.Replace("%", "");

                        decimal i;

                        if (!decimal.TryParse(Convert.ToString(value), out i))
                        {
                            e.Cancel = true;
                            MessageBox.Show("Ink Ratio must be a numeric value.");
                        }
                    }
                }
            }
        }

        private void formulaDataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            
            if (formulaDataGrid.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) &&
                 e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void formulaDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (formulaDataGrid.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                formulaDataGrid.Rows[e.RowIndex].DefaultCellStyle.Format = "0.00";
                allowValidate = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension 

            CaptureScreen();

            // Process save file dialog box results 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                memoryImage.Save(dlg.FileName, jgpEncoder, myEncoderParameters);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void formulaDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (formulaDataGrid.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                formulaDataGrid.Rows[e.RowIndex].DefaultCellStyle.Format = "0.00\\%";
                allowValidate = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dischargeDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customColorCodeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomColorCode.Text = customColorCodeDropDown.SelectedValue.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
