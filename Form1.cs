#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using System.Drawing;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using System;

namespace SfFormDemo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : SfForm
    {
        OrderInfoCollection data;
        TextBoxExt searchBox;
        Label titleLabel;
        Label titleLabel1;
        Label titleLabel2;
        FlowLayoutPanel panel;
        SfButton button;
        SfButton button1;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        TabbedMDIManager tabbedMDIManager = new TabbedMDIManager();

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            try
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(GetIconFile(@"common\Images\Grid\Icon\sficon.ico"));
                this.Icon = ico;
            }
            catch { }

            data = new OrderInfoCollection();
            sfDataGrid1.DataSource = data.OrdersListDetails;
            GridSettings();
            this.Padding = new Padding(0, this.Style.TitleBar.Height, 0, 0);
            this.IsMdiContainer = true;

            // Use the [AttachToMdiContainer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Tools.Windows~Syncfusion.Windows.Forms.Tools.TabbedMDIManager~AttachToMdiContainer.html) function only when the `AttachedTo` property of TabbedMDIManager is not set to Form1. 

            this.tabbedMDIManager.AttachToMdiContainer(this);
            this.tabbedMDIManager.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererOffice2016Colorful);

            Form form = new Form();
            form.MdiParent = this;
            form.Text = "Tab1";
            form.Show();

            Form form1 = new Form();
            form1.Text = "Tab2";
            form1.MdiParent = this;
            form1.Show();

            #region TitleBarControl Customizations
            this.Style.TitleBar.Height = 38;
            this.CenterToScreen();
            this.MinimumSize = this.Size;
            panel = new FlowLayoutPanel();
            panel.Size = new System.Drawing.Size(1061, 24);

            titleLabel = new Label();
            titleLabel.Location = new Point(3, 3);
            titleLabel.Font = new Font("Segeo UI", 13, FontStyle.Regular);
            titleLabel.Text = "Label1";

            titleLabel1 = new Label();
            titleLabel1.Location = new Point(3, 3);
            titleLabel1.Font = new Font("Segeo UI", 13, FontStyle.Regular);
            titleLabel1.Text = "label2";

            titleLabel2 = new Label();
            titleLabel2.Location = new Point(3, 3);
            titleLabel2.Font = new Font("Segeo UI", 13, FontStyle.Regular);
            titleLabel2.Text = "Label3";

            searchBox = new TextBoxExt();
            searchBox.Text = "Quick Search";
            searchBox.ForeColor = SystemColors.GrayText;
            searchBox.Leave += SearchBox_Leave;
            searchBox.Enter += SearchBox_Enter;
            searchBox.Size = new System.Drawing.Size(276, 26);
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.BorderColor = ColorTranslator.FromHtml("#0AA2E6");
            searchBox.KeyUp += SearchBox_KeyUp;
            searchBox.Anchor = AnchorStyles.Right;
            this.Style.TitleBar.BackColor = Color.White;

            // added the Image via button control
            button = new SfButton();
            button.Size = new System.Drawing.Size(30, 21);
#if NETCORE
            button.Image = Image.FromFile("../../../Images/search.png");
#else
            button.Image = Image.FromFile("../../Images/search.png");
#endif
            button.BackColor = Color.White;
            button.Style.FocusedBackColor = Color.White;
            button.Style.HoverBackColor = Color.White;
            button.Style.PressedBackColor = Color.White;
            button.Style.FocusedBorder = Pens.White;
            button.Style.Border = Pens.White;
            button.Style.PressedBorder = Pens.White;
            button.Style.HoverBorder = Pens.White;
            button.Width = 29;
            button1 = new SfButton();
            button1.Size = new System.Drawing.Size(30, 21);
            button1.Width = 50;
            button1.Text = "Button";

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(titleLabel1);
            panel.Controls.Add(titleLabel2);
            panel.Controls.Add(button);
            panel.Controls.Add(searchBox);
            panel.Controls.Add(button1);

            this.TitleBarTextControl = panel;

            titleLabel.MouseDown += TitleLabel_MouseDown;
            #endregion
        }

        /// <summary>
        /// Occurs when a mouse button in pressed ovre the label
        /// </summary>
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //To provide the Dragging behavior of the Form when clicking and draging over the title bar control.
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Search settings

        /// <summary>
        /// Occurs when enter key is pressed in the search box.
        /// </summary>
        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.sfDataGrid1.SearchController.Search(searchBox.Text);
        }

        /// <summary>
        /// Occurs when search box got focus
        /// </summary>
        private void SearchBox_Enter(object sender, System.EventArgs e)
        {
            if (searchBox.Text == "Quick Search")
            {
                searchBox.Text = "";
                searchBox.ForeColor = SystemColors.WindowText;
            }
        }

        /// <summary>
        /// Occurs when search box lost focus
        /// </summary>
        private void SearchBox_Leave(object sender, System.EventArgs e)
        {
            if (searchBox.Text.Length == 0)
            {
                searchBox.Text = "Quick Search";
                searchBox.ForeColor = SystemColors.GrayText;
            }
        }

        #endregion

        #region GridSettings
        /// <summary>
        /// Grid Settings for better Look and Feel.
        /// </summary>
        private void GridSettings()
        {
            sfDataGrid1.Columns["Quantity"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
            sfDataGrid1.Columns["UnitPrice"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
            sfDataGrid1.Columns["ContactNumber"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
        }

        #endregion

        #region Icon Handlers
        private string GetIconFile(string bitmapName)
        {
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(bitmapName))
                    return bitmapName;

                bitmapName = @"..\" + bitmapName;
            }

            return bitmapName;
        }

        #endregion

    }
}
