namespace MetadaneORTO
{
    partial class EdytorAtrybutow
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
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okButton = new System.Windows.Forms.Button();
            this.anulujButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.AllowUserToResizeRows = false;
            this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.mainDataGridView.Location = new System.Drawing.Point(12, 12);
            this.mainDataGridView.MultiSelect = false;
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(565, 287);
            this.mainDataGridView.TabIndex = 0;
            this.mainDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nazwa";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Wartość";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(420, 310);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // anulujButton
            // 
            this.anulujButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.anulujButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.anulujButton.Location = new System.Drawing.Point(501, 310);
            this.anulujButton.Name = "anulujButton";
            this.anulujButton.Size = new System.Drawing.Size(75, 23);
            this.anulujButton.TabIndex = 2;
            this.anulujButton.Text = "Anuluj";
            this.anulujButton.UseVisualStyleBackColor = true;
            // 
            // EdytorAtrybutow
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.anulujButton;
            this.ClientSize = new System.Drawing.Size(588, 345);
            this.Controls.Add(this.anulujButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mainDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EdytorAtrybutow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edytor atrybutów - MetadaneORTO";
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button anulujButton;
    }
}