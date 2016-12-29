using System.ComponentModel;
namespace ODXConverter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Col_DTCNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_DTCShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_DTCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_DTCdisplayTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseItemNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InDataTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutDataTypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffSetCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultPrecisionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormulaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompareValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makezipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.DTCNumberStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.DTCNumberStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.DIDNumerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.DIDNumerStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 612);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1252, 612);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(347, 612);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_DTCNumber,
            this.Col_DTCShortName,
            this.Col_DTCName,
            this.Col_DTCdisplayTC,
            this.ResponseItemNameCol,
            this.InDataTypeCol,
            this.OutDataTypeCol,
            this.OffSetCol,
            this.SizeCol,
            this.ResultPrecisionCol,
            this.FormulaCol,
            this.UnitCol,
            this.CompareValueCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(901, 612);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Col_DTCNumber
            // 
            this.Col_DTCNumber.FillWeight = 15F;
            this.Col_DTCNumber.HeaderText = "Number";
            this.Col_DTCNumber.Name = "Col_DTCNumber";
            this.Col_DTCNumber.ReadOnly = true;
            // 
            // Col_DTCShortName
            // 
            this.Col_DTCShortName.FillWeight = 25F;
            this.Col_DTCShortName.HeaderText = "Short Name";
            this.Col_DTCShortName.Name = "Col_DTCShortName";
            this.Col_DTCShortName.ReadOnly = true;
            // 
            // Col_DTCName
            // 
            this.Col_DTCName.FillWeight = 70F;
            this.Col_DTCName.HeaderText = "Text";
            this.Col_DTCName.Name = "Col_DTCName";
            this.Col_DTCName.ReadOnly = true;
            // 
            // Col_DTCdisplayTC
            // 
            this.Col_DTCdisplayTC.FillWeight = 15F;
            this.Col_DTCdisplayTC.HeaderText = "Display Trouble Code";
            this.Col_DTCdisplayTC.Name = "Col_DTCdisplayTC";
            this.Col_DTCdisplayTC.ReadOnly = true;
            // 
            // ResponseItemNameCol
            // 
            this.ResponseItemNameCol.HeaderText = "Name";
            this.ResponseItemNameCol.Name = "ResponseItemNameCol";
            this.ResponseItemNameCol.ReadOnly = true;
            this.ResponseItemNameCol.Visible = false;
            // 
            // InDataTypeCol
            // 
            this.InDataTypeCol.HeaderText = "InDataType";
            this.InDataTypeCol.Name = "InDataTypeCol";
            this.InDataTypeCol.ReadOnly = true;
            this.InDataTypeCol.Visible = false;
            // 
            // OutDataTypeCol
            // 
            this.OutDataTypeCol.HeaderText = "OutDataType";
            this.OutDataTypeCol.Name = "OutDataTypeCol";
            this.OutDataTypeCol.ReadOnly = true;
            this.OutDataTypeCol.Visible = false;
            // 
            // OffSetCol
            // 
            this.OffSetCol.HeaderText = "OffSet";
            this.OffSetCol.Name = "OffSetCol";
            this.OffSetCol.ReadOnly = true;
            this.OffSetCol.Visible = false;
            // 
            // SizeCol
            // 
            this.SizeCol.HeaderText = "Size";
            this.SizeCol.Name = "SizeCol";
            this.SizeCol.ReadOnly = true;
            this.SizeCol.Visible = false;
            // 
            // ResultPrecisionCol
            // 
            this.ResultPrecisionCol.HeaderText = "ResultPrecision";
            this.ResultPrecisionCol.Name = "ResultPrecisionCol";
            this.ResultPrecisionCol.ReadOnly = true;
            this.ResultPrecisionCol.Visible = false;
            // 
            // FormulaCol
            // 
            this.FormulaCol.HeaderText = "Formula";
            this.FormulaCol.Name = "FormulaCol";
            this.FormulaCol.ReadOnly = true;
            this.FormulaCol.Visible = false;
            // 
            // UnitCol
            // 
            this.UnitCol.HeaderText = "Unit";
            this.UnitCol.Name = "UnitCol";
            this.UnitCol.ReadOnly = true;
            this.UnitCol.Visible = false;
            // 
            // CompareValueCol
            // 
            this.CompareValueCol.HeaderText = "CompareValue";
            this.CompareValueCol.Name = "CompareValueCol";
            this.CompareValueCol.ReadOnly = true;
            this.CompareValueCol.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dTCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.makezipToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // makezipToolStripMenuItem
            // 
            this.makezipToolStripMenuItem.Enabled = false;
            this.makezipToolStripMenuItem.Name = "makezipToolStripMenuItem";
            this.makezipToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.makezipToolStripMenuItem.Text = "Save to .pdx file";
            this.makezipToolStripMenuItem.Click += new System.EventHandler(this.makezipToolStripMenuItem_Click);
            // 
            // dTCToolStripMenuItem
            // 
            this.dTCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.dTCToolStripMenuItem.Name = "dTCToolStripMenuItem";
            this.dTCToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dTCToolStripMenuItem.Text = "DTC";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.DTCNumberStatus,
            this.DTCNumberStatusCount,
            this.DIDNumerStatus,
            this.DIDNumerStatusCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1252, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(1100, 16);
            // 
            // DTCNumberStatus
            // 
            this.DTCNumberStatus.Name = "DTCNumberStatus";
            this.DTCNumberStatus.Size = new System.Drawing.Size(33, 17);
            this.DTCNumberStatus.Text = "DTC:";
            // 
            // DTCNumberStatusCount
            // 
            this.DTCNumberStatusCount.Name = "DTCNumberStatusCount";
            this.DTCNumberStatusCount.Size = new System.Drawing.Size(12, 17);
            this.DTCNumberStatusCount.Text = "*";
            // 
            // DIDNumerStatus
            // 
            this.DIDNumerStatus.Name = "DIDNumerStatus";
            this.DIDNumerStatus.Size = new System.Drawing.Size(26, 17);
            this.DIDNumerStatus.Text = "DID";
            // 
            // DIDNumerStatusCount
            // 
            this.DIDNumerStatusCount.Name = "DIDNumerStatusCount";
            this.DIDNumerStatusCount.Size = new System.Drawing.Size(12, 17);
            this.DIDNumerStatusCount.Text = "*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Pliki XML (*.xml)|*.xml";
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextAdd,
            this.contextEdit,
            this.contextDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // contextAdd
            // 
            this.contextAdd.Name = "contextAdd";
            this.contextAdd.Size = new System.Drawing.Size(107, 22);
            this.contextAdd.Text = "Add";
            this.contextAdd.Click += new System.EventHandler(this.contextAdd_Click);
            // 
            // contextEdit
            // 
            this.contextEdit.Name = "contextEdit";
            this.contextEdit.Size = new System.Drawing.Size(107, 22);
            this.contextEdit.Text = "Edit";
            this.contextEdit.Click += new System.EventHandler(this.contextEdit_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(107, 22);
            this.contextDelete.Text = "Delete";
            this.contextDelete.Click += new System.EventHandler(this.contextDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 636);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "ODX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ToolStripMenuItem makezipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextAdd;
        private System.Windows.Forms.ToolStripMenuItem contextEdit;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.ToolStripStatusLabel DTCNumberStatus;
        private System.Windows.Forms.ToolStripStatusLabel DTCNumberStatusCount;
        private System.Windows.Forms.ToolStripStatusLabel DIDNumerStatus;
        private System.Windows.Forms.ToolStripStatusLabel DIDNumerStatusCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_DTCNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_DTCShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_DTCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_DTCdisplayTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseItemNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn InDataTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutDataTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffSetCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultPrecisionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormulaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompareValueCol;
    }
}

