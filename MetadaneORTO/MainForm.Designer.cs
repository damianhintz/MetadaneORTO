namespace MetadaneORTO
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.schemaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowySchematMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajSchematMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszSchematMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujSchematMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plikMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujZasięgiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujPunktyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importujAtrybutyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujAtrybutyKolumnowoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.eksportujMetadaneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.edytujAtrybutyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mListView = new System.Windows.Forms.ListView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edytorAtrybutowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Menu;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schemaMenuItem,
            this.plikMenuItem,
            this.pomocMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(1093, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // schemaMenuItem
            // 
            this.schemaMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowySchematMenuItem,
            this.wczytajSchematMenuItem,
            this.zapiszSchematMenuItem,
            this.edytujSchematMenuItem,
            this.toolStripSeparator2,
            this.zakończMenuItem});
            this.schemaMenuItem.Name = "schemaMenuItem";
            this.schemaMenuItem.Size = new System.Drawing.Size(39, 24);
            this.schemaMenuItem.Text = "Plik";
            // 
            // nowySchematMenuItem
            // 
            this.nowySchematMenuItem.Name = "nowySchematMenuItem";
            this.nowySchematMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nowySchematMenuItem.Size = new System.Drawing.Size(255, 26);
            this.nowySchematMenuItem.Text = "Nowy schemat";
            this.nowySchematMenuItem.ToolTipText = "Utwórz nowy schemat bazy";
            this.nowySchematMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // wczytajSchematMenuItem
            // 
            this.wczytajSchematMenuItem.Name = "wczytajSchematMenuItem";
            this.wczytajSchematMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.wczytajSchematMenuItem.Size = new System.Drawing.Size(255, 26);
            this.wczytajSchematMenuItem.Text = "Otwórz schemat...";
            this.wczytajSchematMenuItem.ToolTipText = "Wczytaj schemat bazy z pliku";
            this.wczytajSchematMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // zapiszSchematMenuItem
            // 
            this.zapiszSchematMenuItem.Name = "zapiszSchematMenuItem";
            this.zapiszSchematMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.zapiszSchematMenuItem.Size = new System.Drawing.Size(255, 26);
            this.zapiszSchematMenuItem.Text = "Zapisz schemat...";
            this.zapiszSchematMenuItem.ToolTipText = "Zapisz schemat do pliku";
            this.zapiszSchematMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // edytujSchematMenuItem
            // 
            this.edytujSchematMenuItem.Name = "edytujSchematMenuItem";
            this.edytujSchematMenuItem.Size = new System.Drawing.Size(255, 26);
            this.edytujSchematMenuItem.Text = "Edytuj schemat...";
            this.edytujSchematMenuItem.ToolTipText = "Zmień schemat bazy";
            this.edytujSchematMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(252, 6);
            // 
            // zakończMenuItem
            // 
            this.zakończMenuItem.Name = "zakończMenuItem";
            this.zakończMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.zakończMenuItem.Size = new System.Drawing.Size(255, 26);
            this.zakończMenuItem.Text = "Zakończ";
            this.zakończMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // plikMenuItem
            // 
            this.plikMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importujZasięgiMenuItem,
            this.importujPunktyMenuItem,
            this.toolStripSeparator3,
            this.importujAtrybutyMenuItem,
            this.importujAtrybutyKolumnowoMenuItem,
            this.toolStripSeparator1,
            this.eksportujMetadaneMenuItem,
            this.toolStripSeparator4,
            this.edytujAtrybutyMenuItem});
            this.plikMenuItem.Name = "plikMenuItem";
            this.plikMenuItem.Size = new System.Drawing.Size(85, 24);
            this.plikMenuItem.Text = "Metadane";
            // 
            // importujZasięgiMenuItem
            // 
            this.importujZasięgiMenuItem.Name = "importujZasięgiMenuItem";
            this.importujZasięgiMenuItem.Size = new System.Drawing.Size(251, 26);
            this.importujZasięgiMenuItem.Text = "Importuj zasięgi...";
            this.importujZasięgiMenuItem.ToolTipText = "Wczytaj zasięgi zdjęć";
            this.importujZasięgiMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // importujPunktyMenuItem
            // 
            this.importujPunktyMenuItem.Name = "importujPunktyMenuItem";
            this.importujPunktyMenuItem.Size = new System.Drawing.Size(251, 26);
            this.importujPunktyMenuItem.Text = "Importuj punkty...";
            this.importujPunktyMenuItem.ToolTipText = "Wczytaj środki zdjęć i atrybuty";
            this.importujPunktyMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(248, 6);
            // 
            // importujAtrybutyMenuItem
            // 
            this.importujAtrybutyMenuItem.Name = "importujAtrybutyMenuItem";
            this.importujAtrybutyMenuItem.Size = new System.Drawing.Size(251, 26);
            this.importujAtrybutyMenuItem.Text = "Importuj atrybuty...";
            this.importujAtrybutyMenuItem.ToolTipText = "Wczytaj atrybuty dla zasięgów";
            this.importujAtrybutyMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // importujAtrybutyKolumnowoMenuItem
            // 
            this.importujAtrybutyKolumnowoMenuItem.Name = "importujAtrybutyKolumnowoMenuItem";
            this.importujAtrybutyKolumnowoMenuItem.Size = new System.Drawing.Size(251, 26);
            this.importujAtrybutyKolumnowoMenuItem.Text = "Importuj stałe atrybuty...";
            this.importujAtrybutyKolumnowoMenuItem.ToolTipText = "Wczytaj atrybuty takie same dla wszystkich zasięgów";
            this.importujAtrybutyKolumnowoMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // eksportujMetadaneMenuItem
            // 
            this.eksportujMetadaneMenuItem.Name = "eksportujMetadaneMenuItem";
            this.eksportujMetadaneMenuItem.Size = new System.Drawing.Size(251, 26);
            this.eksportujMetadaneMenuItem.Text = "Eksportuj metadane...";
            this.eksportujMetadaneMenuItem.ToolTipText = "Eksportuj metadane zgodnie ze schematem bazy";
            this.eksportujMetadaneMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(248, 6);
            // 
            // edytujAtrybutyMenuItem
            // 
            this.edytujAtrybutyMenuItem.Name = "edytujAtrybutyMenuItem";
            this.edytujAtrybutyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F7)));
            this.edytujAtrybutyMenuItem.Size = new System.Drawing.Size(251, 26);
            this.edytujAtrybutyMenuItem.Text = "Edytuj atrybuty...";
            this.edytujAtrybutyMenuItem.Click += new System.EventHandler(this.EdytorAtrybutow);
            // 
            // pomocMenuItem
            // 
            this.pomocMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacjeMenuItem});
            this.pomocMenuItem.Name = "pomocMenuItem";
            this.pomocMenuItem.Size = new System.Drawing.Size(64, 24);
            this.pomocMenuItem.Text = "Pomoc";
            // 
            // informacjeMenuItem
            // 
            this.informacjeMenuItem.Name = "informacjeMenuItem";
            this.informacjeMenuItem.Size = new System.Drawing.Size(278, 26);
            this.informacjeMenuItem.Text = "Informacje o MetadaneORTO";
            this.informacjeMenuItem.Click += new System.EventHandler(this.WykonajPolecenieDlaMenu);
            // 
            // mListView
            // 
            this.mListView.ContextMenuStrip = this.contextMenu;
            this.mListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mListView.FullRowSelect = true;
            this.mListView.Location = new System.Drawing.Point(0, 28);
            this.mListView.Margin = new System.Windows.Forms.Padding(4);
            this.mListView.MultiSelect = false;
            this.mListView.Name = "mListView";
            this.mListView.Size = new System.Drawing.Size(1093, 441);
            this.mListView.TabIndex = 1;
            this.mListView.UseCompatibleStateImageBehavior = false;
            this.mListView.View = System.Windows.Forms.View.Details;
            this.mListView.DoubleClick += new System.EventHandler(this.EdytorAtrybutow);
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.SystemColors.Menu;
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edytorAtrybutowToolStripMenuItem});
            this.contextMenu.Name = "mainContextMenuStrip";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(199, 30);
            this.contextMenu.Click += new System.EventHandler(this.EdytorAtrybutow);
            // 
            // edytorAtrybutowToolStripMenuItem
            // 
            this.edytorAtrybutowToolStripMenuItem.Name = "edytorAtrybutowToolStripMenuItem";
            this.edytorAtrybutowToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.edytorAtrybutowToolStripMenuItem.Text = "Edytuj atrybuty...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 469);
            this.Controls.Add(this.mListView);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MetadaneORTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem plikMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importujZasięgiMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem schemaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujSchematMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importujAtrybutyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eksportujMetadaneMenuItem;
        private System.Windows.Forms.ListView mListView;
        private System.Windows.Forms.ToolStripMenuItem nowySchematMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajSchematMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszSchematMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importujAtrybutyKolumnowoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem zakończMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importujPunktyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem edytujAtrybutyMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem edytorAtrybutowToolStripMenuItem;
    }
}

