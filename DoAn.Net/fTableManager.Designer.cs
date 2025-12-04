namespace DoAn.Net
{
    partial class fTableManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGiamgia = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvBill = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbSwitchTableTo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.nmFoodCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmFoodCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmFoodCount.Location = new System.Drawing.Point(395, 23);
            this.nmFoodCount.Margin = new System.Windows.Forms.Padding(4);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(52, 30);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.btnAddFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFood.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnAddFood.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(50)))), ((int)(((byte)(35)))));
            this.btnAddFood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.Location = new System.Drawing.Point(284, 8);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(100, 57);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(4, 4);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(272, 31);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.nmFoodCount);
            this.panel4.Controls.Add(this.btnAddFood);
            this.panel4.Controls.Add(this.cbFood);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(596, 100);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(522, 75);
            this.panel4.TabIndex = 9;
            // 
            // cbFood
            // 
            this.cbFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.cbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFood.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(4, 34);
            this.cbFood.Margin = new System.Windows.Forms.Padding(4);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(272, 31);
            this.cbFood.TabIndex = 1;
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.txbTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbTotalPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.ForeColor = System.Drawing.Color.OrangeRed;
            this.txbTotalPrice.Location = new System.Drawing.Point(318, 18);
            this.txbTotalPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(119, 34);
            this.txbTotalPrice.TabIndex = 7;
            this.txbTotalPrice.Text = "0";
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.cbSwitchTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitchTable.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(5, 44);
            this.cbSwitchTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(178, 31);
            this.cbSwitchTable.TabIndex = 6;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.btnSwitchTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchTable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnSwitchTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(50)))), ((int)(((byte)(35)))));
            this.btnSwitchTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnSwitchTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchTable.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.ForeColor = System.Drawing.Color.White;
            this.btnSwitchTable.Location = new System.Drawing.Point(5, 4);
            this.btnSwitchTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(178, 32);
            this.btnSwitchTable.TabIndex = 5;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = false;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nmDisCount
            // 
            this.nmDisCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.nmDisCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmDisCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDisCount.Location = new System.Drawing.Point(318, 69);
            this.nmDisCount.Margin = new System.Windows.Forms.Padding(4);
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(120, 30);
            this.nmDisCount.TabIndex = 4;
            this.nmDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnCheckOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(50)))), ((int)(((byte)(35)))));
            this.btnCheckOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(87)))), ((int)(((byte)(42)))));
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(445, 23);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(100, 71);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.cbSwitchTableTo);
            this.panel3.Controls.Add(this.lblGiamgia);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.nmDisCount);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Location = new System.Drawing.Point(596, 495);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 122);
            this.panel3.TabIndex = 8;
            // 
            // lblGiamgia
            // 
            this.lblGiamgia.AutoSize = true;
            this.lblGiamgia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamgia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.lblGiamgia.Location = new System.Drawing.Point(218, 69);
            this.lblGiamgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiamgia.Name = "lblGiamgia";
            this.lblGiamgia.Size = new System.Drawing.Size(87, 25);
            this.lblGiamgia.TabIndex = 9;
            this.lblGiamgia.Text = "Giảm giá";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.lblTotal.Location = new System.Drawing.Point(213, 23);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(92, 25);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng tiền";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 200;
            // 
            // lsvBill
            // 
            this.lsvBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.lsvBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.lsvBill.FullRowSelect = true;
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(4, 4);
            this.lsvBill.Margin = new System.Windows.Forms.Padding(4);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(551, 379);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(596, 172);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 388);
            this.panel2.TabIndex = 7;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.đăngXuấtToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinCáNhânToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thongTinCaNhanToolStripMenuItem_Click);
            // 
            // thongTinTKToolStripMenuItem
            // 
            this.thongTinTKToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thongTinTKToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinTKToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.thongTinTKToolStripMenuItem.Name = "thongTinTKToolStripMenuItem";
            this.thongTinTKToolStripMenuItem.Size = new System.Drawing.Size(174, 27);
            this.thongTinTKToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(74, 27);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thongTinTKToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1171, 31);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.Color.Transparent;
            this.flpTable.Location = new System.Drawing.Point(16, 100);
            this.flpTable.Margin = new System.Windows.Forms.Padding(4);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(572, 527);
            this.flpTable.TabIndex = 10;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(65)))), ((int)(((byte)(41)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 31);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1171, 60);
            this.panelHeader.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.lblTitle.Location = new System.Drawing.Point(122, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "QUẢN LÝ BÀN VÀ ĐẶT MÓN";
            // 
            // cbSwitchTableTo
            // 
            this.cbSwitchTableTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.cbSwitchTableTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSwitchTableTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwitchTableTo.FormattingEnabled = true;
            this.cbSwitchTableTo.Location = new System.Drawing.Point(5, 83);
            this.cbSwitchTableTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbSwitchTableTo.Name = "cbSwitchTableTo";
            this.cbSwitchTableTo.Size = new System.Drawing.Size(178, 31);
            this.cbSwitchTableTo.TabIndex = 10;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1171, 630);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flpTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán - Cafe & Bakery";
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongTinTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Label lblGiamgia;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbSwitchTableTo;
    }
}