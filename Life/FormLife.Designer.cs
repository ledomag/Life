namespace Life
{
    partial class FormLife
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLife));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIsMoving = new System.Windows.Forms.ToolStripButton();
            this.tsBtnZoomUp = new System.Windows.Forms.ToolStripButton();
            this.tsBtnZoomDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnStart = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStop = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNextStep = new System.Windows.Forms.ToolStripButton();
            this.tsBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSharp = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbGameSpeed = new System.Windows.Forms.ToolStripComboBox();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.tGame = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(504, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "&Игра";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newToolStripMenuItem.Text = "&Новая";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openToolStripMenuItem.Text = "&Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveToolStripMenuItem.Text = "&Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.optionsToolStripMenuItem.Text = "&Параметры";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "&Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextStepToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.actionToolStripMenuItem.Text = "&Действие";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.startToolStripMenuItem.Text = "&Старт";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.P)));
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.stopToolStripMenuItem.Text = "С&топ";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // nextStepToolStripMenuItem
            // 
            this.nextStepToolStripMenuItem.Name = "nextStepToolStripMenuItem";
            this.nextStepToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.nextStepToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.nextStepToolStripMenuItem.Text = "Следующий &шаг";
            this.nextStepToolStripMenuItem.Click += new System.EventHandler(this.nextStepToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.clearToolStripMenuItem.Text = "&Очистить";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.sharpToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewToolStripMenuItem.Text = "&Вид";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.toolBarToolStripMenuItem.Text = "&Панель инструментов";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.toolBarToolStripMenuItem_Click);
            // 
            // sharpToolStripMenuItem
            // 
            this.sharpToolStripMenuItem.Checked = true;
            this.sharpToolStripMenuItem.CheckOnClick = true;
            this.sharpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sharpToolStripMenuItem.Name = "sharpToolStripMenuItem";
            this.sharpToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.sharpToolStripMenuItem.Text = "&Сетка";
            this.sharpToolStripMenuItem.Click += new System.EventHandler(this.sharpToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "&Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "&О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSaveAs,
            this.tsBtnIsMoving,
            this.tsBtnZoomUp,
            this.tsBtnZoomDown,
            this.toolStripSeparator2,
            this.tsBtnStart,
            this.tsBtnStop,
            this.tsBtnNextStep,
            this.tsBtnClear,
            this.toolStripSeparator1,
            this.tsBtnSharp,
            this.toolStripLabel1,
            this.tscbGameSpeed});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(504, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsBtnSaveAs
            // 
            this.tsBtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSaveAs.Image = global::Life.Properties.Resources.Save;
            this.tsBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaveAs.Name = "tsBtnSaveAs";
            this.tsBtnSaveAs.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSaveAs.Text = "Сохранить как";
            this.tsBtnSaveAs.Click += new System.EventHandler(this.tsBtnSaveAs_Click);
            // 
            // tsBtnIsMoving
            // 
            this.tsBtnIsMoving.CheckOnClick = true;
            this.tsBtnIsMoving.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnIsMoving.Image = global::Life.Properties.Resources.Move;
            this.tsBtnIsMoving.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIsMoving.Name = "tsBtnIsMoving";
            this.tsBtnIsMoving.Size = new System.Drawing.Size(23, 22);
            this.tsBtnIsMoving.Text = "Переместить карту";
            this.tsBtnIsMoving.CheckedChanged += new System.EventHandler(this.tsBtnIsMoving_CheckedChanged);
            // 
            // tsBtnZoomUp
            // 
            this.tsBtnZoomUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnZoomUp.Image = global::Life.Properties.Resources.ZoomUp;
            this.tsBtnZoomUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomUp.Name = "tsBtnZoomUp";
            this.tsBtnZoomUp.Size = new System.Drawing.Size(23, 22);
            this.tsBtnZoomUp.Text = "Увеличить";
            this.tsBtnZoomUp.Click += new System.EventHandler(this.tsBtnZoomUp_Click);
            // 
            // tsBtnZoomDown
            // 
            this.tsBtnZoomDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnZoomDown.Image = global::Life.Properties.Resources.ZoomDown;
            this.tsBtnZoomDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomDown.Name = "tsBtnZoomDown";
            this.tsBtnZoomDown.Size = new System.Drawing.Size(23, 22);
            this.tsBtnZoomDown.Text = "Уменьшить";
            this.tsBtnZoomDown.Click += new System.EventHandler(this.tsBtnZoomDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnStart
            // 
            this.tsBtnStart.CheckOnClick = true;
            this.tsBtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStart.Image = global::Life.Properties.Resources.Play;
            this.tsBtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStart.Name = "tsBtnStart";
            this.tsBtnStart.Size = new System.Drawing.Size(23, 22);
            this.tsBtnStart.Text = "Старт";
            this.tsBtnStart.Click += new System.EventHandler(this.tsBtnStart_Click);
            // 
            // tsBtnStop
            // 
            this.tsBtnStop.Checked = true;
            this.tsBtnStop.CheckOnClick = true;
            this.tsBtnStop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStop.Image = global::Life.Properties.Resources.Stop;
            this.tsBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStop.Name = "tsBtnStop";
            this.tsBtnStop.Size = new System.Drawing.Size(23, 22);
            this.tsBtnStop.Text = "Стоп";
            this.tsBtnStop.Click += new System.EventHandler(this.tsBtnStop_Click);
            // 
            // tsBtnNextStep
            // 
            this.tsBtnNextStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNextStep.Image = global::Life.Properties.Resources.NextStep;
            this.tsBtnNextStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNextStep.Name = "tsBtnNextStep";
            this.tsBtnNextStep.Size = new System.Drawing.Size(23, 22);
            this.tsBtnNextStep.Text = "Следующий шаг";
            this.tsBtnNextStep.Click += new System.EventHandler(this.tsBtnNextStep_Click);
            // 
            // tsBtnClear
            // 
            this.tsBtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnClear.Image = global::Life.Properties.Resources.Refresh;
            this.tsBtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClear.Name = "tsBtnClear";
            this.tsBtnClear.Size = new System.Drawing.Size(23, 22);
            this.tsBtnClear.Text = "Очистить карту";
            this.tsBtnClear.Click += new System.EventHandler(this.tsBtnClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnSharp
            // 
            this.tsBtnSharp.Checked = true;
            this.tsBtnSharp.CheckOnClick = true;
            this.tsBtnSharp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnSharp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSharp.Image = global::Life.Properties.Resources.Sharp;
            this.tsBtnSharp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSharp.Name = "tsBtnSharp";
            this.tsBtnSharp.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSharp.Text = "Сетка";
            this.tsBtnSharp.CheckedChanged += new System.EventHandler(this.tsBtnSharp_CheckedChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "Скорость";
            // 
            // tscbGameSpeed
            // 
            this.tscbGameSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbGameSpeed.Name = "tscbGameSpeed";
            this.tscbGameSpeed.Size = new System.Drawing.Size(75, 25);
            this.tscbGameSpeed.SelectedIndexChanged += new System.EventHandler(this.tscbGameSpeed_SelectedIndexChanged);
            // 
            // pnlDraw
            // 
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDraw.Location = new System.Drawing.Point(3, 3);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(89, 75);
            this.pnlDraw.TabIndex = 0;
            this.pnlDraw.Visible = false;
            this.pnlDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseMove);
            this.pnlDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseDown);
            this.pnlDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseUp);
            // 
            // tGame
            // 
            this.tGame.Interval = 1000;
            this.tGame.Tick += new System.EventHandler(this.tGame_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDraw);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 49);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(504, 315);
            this.pnlMain.TabIndex = 2;
            // 
            // FormLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 364);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormLife";
            this.Text = "Жизнь";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsBtnStart;
        private System.Windows.Forms.ToolStripButton tsBtnStop;
        private System.Windows.Forms.ToolStripButton tsBtnNextStep;
        private System.Windows.Forms.ToolStripButton tsBtnClear;
        private System.Windows.Forms.ToolStripComboBox tscbGameSpeed;
        private System.Windows.Forms.Timer tGame;
        private System.Windows.Forms.ToolStripButton tsBtnSharp;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsBtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnIsMoving;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.ToolStripButton tsBtnZoomUp;
        private System.Windows.Forms.ToolStripButton tsBtnZoomDown;
        private System.Windows.Forms.Panel pnlMain;
    }
}

